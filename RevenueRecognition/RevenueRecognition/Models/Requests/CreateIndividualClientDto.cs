using System.ComponentModel.DataAnnotations;

namespace RevenueRecognition.Models.Requests;

public class CreateIndividualClientDto
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

    [Required]
    [RegularExpression("^[0-9]{11}$", ErrorMessage = "PESEL must be exactly 11 digits")]
    public string? PESEL { get; set; }
}