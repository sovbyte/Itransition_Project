using Google.Apis.Auth;
using Itransition_Project.Data.DTOs;
using Itransition_Project.Models;
using Itransition_Project.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Itransition_Project.Services;

public class AuthService(
    UserManager<User> userManager,
    IEmailSender<User> emailSender,
    IConfiguration config,
    JwtService jwtService)
    : IAuthService
{
    private readonly IConfiguration _config = config;

    public async Task<AuthResult> RegisterAsync(RegisterDto registerDto)
    {
        var existingUser = await userManager.FindByEmailAsync(registerDto.Email);
        if (existingUser != null)
        {
            return new AuthResult
            {
                IsSuccess = false,
                Errors = ["Email is already taken."]
            };
        }

        var user = new User
        {
            Email = registerDto.Email,
            UserName = registerDto.Username,
        };

        var result = await userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            return new AuthResult()
            {
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        //todo move this
        var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? "http://localhost:5173";
        var confirmationLink =
            $"{frontendUrl}/confirm-email?email={Uri.EscapeDataString(user.Email)}&token={Uri.EscapeDataString(token)}";

        try
        {
            await emailSender.SendConfirmationLinkAsync(user, user.Email, confirmationLink);
        }
        catch (Exception)
        {
            return new AuthResult()
            {
                IsSuccess = true,
                Errors = ["Account created, but we failed to send the confirmation email. Please request a new link."]
            };
        }

        return new AuthResult
        {
            IsSuccess = true
        };
    }

    public async Task<AuthResult> LoginAsync(LoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);

        if (user == null)
        {
            return new AuthResult
            {
                IsSuccess = false,
                Errors = ["Invalid email or password."]
            };
        }

        var isPasswordValid = await userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!isPasswordValid)
        {
            return new AuthResult
            {
                IsSuccess = false,
                Errors = ["Invalid email or password."]
            };
        }

        if (!user.EmailConfirmed)
        {
            return new AuthResult
            {
                IsSuccess = false,
                Errors = ["You must confirm your email before logging in."]
            };
        }

        var token = await jwtService.GenerateJwtTokenAsync(user);

        return new AuthResult()
        {
            IsSuccess = true,
            Token = token
        };
    }

    public async Task<AuthResult> ConfirmEmailAsync(string email, string token)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return new AuthResult
            {
                IsSuccess = false,
                Errors = ["User not found."]
            };
        }

        var result = await userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            return new AuthResult
            {
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        return new AuthResult
        {
            IsSuccess = true,
        };
    }

    public async Task<AuthResult> ForgotPasswordAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return new AuthResult
            {
                //security concern: don't reveal that user does not exist
                IsSuccess = true
            };
        }

        var token = await userManager.GeneratePasswordResetTokenAsync(user);

        var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") ?? "http://localhost:5173";
        var resetLink =
            $"{frontendUrl}/reset-password?email={Uri.EscapeDataString(user.Email!)}&token={Uri.EscapeDataString(token)}";

        try
        {
            await emailSender.SendPasswordResetLinkAsync(user, user.Email!, resetLink);
        }
        catch (Exception)
        {
            return new AuthResult()
            {
                IsSuccess = false,
                Errors = ["Failed to send password reset email. Please try again later."]
            };
        }

        return new AuthResult { IsSuccess = true };
    }

    public async Task<AuthResult> ResetPasswordAsync(string email, string token, string newPassword)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return new AuthResult
            {
                IsSuccess = false,
                Errors = ["Invalid request."]
            };
        }

        var result = await userManager.ResetPasswordAsync(user, token, newPassword);
        if (!result.Succeeded)
        {
            return new AuthResult
            {
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        return new AuthResult { IsSuccess = true };
    }

    public async Task<AuthResult> ExternalLoginAsync(string provider, string token)
    {
        string email;
        string username;
        string providerKey;

        if (provider.Equals("Google", StringComparison.OrdinalIgnoreCase))
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = [Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID")]
                };
                
                var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);
                
                email =  payload.Email;
                username = payload.Name ?? payload.Email;
                providerKey = payload.Subject;
            }
            catch (Exception)
            {
                return new AuthResult { IsSuccess = false,  Errors = ["Invalid Google token."] };
            }
        }
        else if (provider.Equals("Facebook", StringComparison.OrdinalIgnoreCase))
        {
            throw new NotImplementedException("Facebook verification not implemented yet.");
        }
        else
        {
            return new AuthResult { IsSuccess = false, Errors = ["Unsupported provider."] };
        }
        
        var user = await userManager.FindByLoginAsync(provider, providerKey) ?? (await userManager.FindByEmailAsync(email) ?? new User()
        {
            Email = email,
            UserName = email,
            EmailConfirmed = true
        });
        
        var createResult = await userManager.CreateAsync(user);
        if (!createResult.Succeeded)
        {
            return new AuthResult { IsSuccess = false, Errors = createResult.Errors.Select(e => e.Description) };
        }
        
        var userLoginInfo = new  UserLoginInfo(provider, username, providerKey);
        var linkResult = await userManager.AddLoginAsync(user, userLoginInfo);

        if (!linkResult.Succeeded)
        {
            return new AuthResult { IsSuccess = false, Errors = ["Failed to link external account."] };
        }
        
        var jwtToken = await jwtService.GenerateJwtTokenAsync(user);
        
        return new AuthResult { IsSuccess = true, Token = jwtToken };
    }
}