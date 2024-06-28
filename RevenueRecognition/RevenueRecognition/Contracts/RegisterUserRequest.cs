using System.ComponentModel.DataAnnotations;

namespace RevenueRecognition.Contracts;

public class RegisterUserRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Role { get; set; }
}