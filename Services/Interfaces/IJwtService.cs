using Itransition_Project.Models;

namespace Itransition_Project.Services.Interfaces;

public interface IJwtService
{
    Task<string> GenerateJwtTokenAsync(User user);
}