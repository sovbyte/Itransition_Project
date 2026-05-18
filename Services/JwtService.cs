using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Itransition_Project.Models;
using Itransition_Project.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Itransition_Project.Services;

public class JwtService(UserManager<User> userManager) : IJwtService
{
    public async Task<string> GenerateJwtTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty)
        };

        var roles = await userManager.GetRolesAsync(user);
        
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var keyString = Environment.GetEnvironmentVariable("JWT_KEY") 
            ?? throw new InvalidOperationException("JWT_KEY variable is missing from the environment.");
            
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiryMinutesStr = Environment.GetEnvironmentVariable("JWT_EXPIRY_MINUTES");
        var expiryMinutes = double.TryParse(expiryMinutesStr, out var exp) ? exp : 60;

        var token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
            audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}