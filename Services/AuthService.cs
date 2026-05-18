using Itransition_Project.Data.DTOs;
using Itransition_Project.Models;
using Itransition_Project.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Itransition_Project.Services;

public class AuthService(UserManager<User> userManager, IEmailSender<User> emailSender, IConfiguration config)
    : IAuthService
{
    private readonly UserManager<User>  _userManager = userManager;
    private readonly IEmailSender<User> _emailSender = emailSender;
    private readonly IConfiguration _config = config;


    public Task<AuthResult> RegisterAsync(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResult> LoginAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
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