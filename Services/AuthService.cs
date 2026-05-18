using Itransition_Project.Data.DTOs;
using Itransition_Project.Models;
using Itransition_Project.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Itransition_Project.Services;

public class AuthService(UserManager<User> userManager, IEmailSender<User> emailSender, IConfiguration config, JwtService jwtService)
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
        var confirmationLink = $"{frontendUrl}/confirm-email?email={Uri.EscapeDataString(user.Email)}&token={Uri.EscapeDataString(token)}";

        try
        {
            await emailSender.SendConfirmationLinkAsync(user, user.Email, confirmationLink);
        }
        catch (Exception e)
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
        
        var token =  await jwtService.GenerateJwtTokenAsync(user);

        return new AuthResult()
        {
            IsSuccess = true,
            Token = token
        };
    }

    public Task<AuthResult> ConfirmEmailAsync(string email, string token)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResult> ForgotPasswordAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResult> ResetPasswordAsync(string email, string token, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResult> ExternalLoginAsync(string provider, string token)
    {
        throw new NotImplementedException();
    }
}