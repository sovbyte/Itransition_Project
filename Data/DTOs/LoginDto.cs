using System.ComponentModel.DataAnnotations;

namespace Itransition_Project.Data.DTOs;

public class LoginDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}