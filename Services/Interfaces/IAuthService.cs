using Itransition_Project.Data.DTOs;

namespace Itransition_Project.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterDto registerDto);
    Task<AuthResult> LoginAsync(LoginDto loginDto);
    Task<AuthResult> ConfirmEmailAsync(string email, string token);
    Task<AuthResult> ForgotPasswordAsync(string email);
    Task<AuthResult> ResetPasswordAsync(string email, string token, string newPassword);
    Task<AuthResult> ExternalLoginAsync(string provider, string token);
}