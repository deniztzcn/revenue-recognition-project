using System.ComponentModel.DataAnnotations;

namespace RevenueRecognition.Models.Requests;

public class UpdateCompanyClientDto
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
    [MaxLength(100)]
    public string? CompanyName { get; set; }
}