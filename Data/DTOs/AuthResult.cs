namespace Itransition_Project.Data.DTOs;

public class AuthResult
{
    public bool IsSuccess { get; set; }
    public string? Token { get; set; }
    public IEnumerable<string> Errors { get; set; } =  [];
}