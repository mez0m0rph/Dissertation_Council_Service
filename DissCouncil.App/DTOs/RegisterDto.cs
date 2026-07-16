using System.ComponentModel.DataAnnotations;

namespace DissCouncil.App.DTOs;

public class RegisterDto
{
    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }
    [Required]
    [MinLength(6)]
    public required string Password { get; set; }
}