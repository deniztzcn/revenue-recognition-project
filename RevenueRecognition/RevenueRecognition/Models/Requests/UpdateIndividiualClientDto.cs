using System.ComponentModel.DataAnnotations;

namespace RevenueRecognition.Models.Requests;

public class UpdateIndividiualClientDto
{
    [Required]
    [MaxLength(100)]
    public string? Address { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [Phone]
    public string? PhoneNumber { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string? FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; }
}