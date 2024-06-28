using System.ComponentModel.DataAnnotations;

namespace RevenueRecognition.Models.Requests;

//.."To force clients to set a value, make the property nullable and set the Required attribute.."
//source: https://learn.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api
public class CreateCompanyClientDto
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
    [Required]
    [RegularExpression("^[0-9]{10}$", ErrorMessage = "KRS number must be exactly 10 digits.")]
    public string? KRS { get; set; }
}