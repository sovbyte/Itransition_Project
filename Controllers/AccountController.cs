using Itransition_Project.Data.DTOs;
using Itransition_Project.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Itransition_Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<StatusMessageDto>> Register([FromBody] RegisterDto registerDto)
    {
        var result = await authService.RegisterAsync(registerDto);
        if (!result.IsSuccess)
        {
            return BadRequest(new { errors = result.Errors });
        }
        
        return Ok(new StatusMessageDto { Message = "Successfully registered. Check your email to verify your account" });
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto loginDto)
    {
        var result = await authService.LoginAsync(loginDto);
        if (!result.IsSuccess)
        {
            return BadRequest(new { errors = result.Errors });
        }
        
        return Ok(new AuthResponseDto { Token = result.Token ?? string.Empty });
    }

    [HttpGet("confirm-email")]
    public async Task<ActionResult<StatusMessageDto>> ConfirmEmail([FromQuery] string email, [FromQuery] string token)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
        {
            return BadRequest(new { errors = (string[])["Invalid email or token"] });
        }

        var result = await authService.ConfirmEmailAsync(email, token);
        if (!result.IsSuccess)
        {
            return BadRequest(new { errors = result.Errors });
        }
        
        return Ok(new StatusMessageDto { Message = "Email confirmed successfully. You can now log in" });
    }

    [HttpPost("forgot-password")]
    public async Task<ActionResult<StatusMessageDto>> ForgotPassword([FromBody] string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return BadRequest(new { errors = (string[])["Email is required."] });
        }
        
        var result = await authService.ForgotPasswordAsync(email); 
        if (!result.IsSuccess)
        {
            return BadRequest(new { errors = result.Errors });
        }
        
        return Ok(new StatusMessageDto { Message = "If the email matches an account, a password reset link has been sent." });
    }
    
    [HttpPost("reset-password")]
    public async Task<ActionResult<StatusMessageDto>> ResetPassword([FromQuery] string email, [FromQuery] string token, [FromBody] string newPassword)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(newPassword))
        {
            return BadRequest(new { errors = (string[])["Invalid password reset attempt data missing."] });
        }

        var result = await authService.ResetPasswordAsync(email, token, newPassword);
        if (!result.IsSuccess)
        {
            return BadRequest(new { errors = result.Errors });
        }

        return Ok(new StatusMessageDto { Message = "Password has been reset successfully." });
    }

    [HttpPost("external-login")]
    public async Task<ActionResult<AuthResponseDto>> ExternalLogin([FromQuery] string provider, [FromBody] string token)
    {
        if (string.IsNullOrWhiteSpace(provider) || string.IsNullOrWhiteSpace(token))
        {
            return BadRequest(new { errors = (string[])["Provider and token are required."] });
        }

        var result = await authService.ExternalLoginAsync(provider, token);
        if (!result.IsSuccess)
        {
            return BadRequest(new { errors = result.Errors });
        }

        return Ok(new AuthResponseDto { Token = result.Token ?? string.Empty });
    }
}