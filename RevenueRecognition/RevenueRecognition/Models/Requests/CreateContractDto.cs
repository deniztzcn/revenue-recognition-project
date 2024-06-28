using System.ComponentModel.DataAnnotations;

namespace RevenueRecognition.Models.Requests;

public class CreateContractDto
{
    [Required]
    public int PaymentDuration { get; set; }
    [Required]
    public int ClientId { get; set; }
    [Required]
    public int SoftwareLicenseId { get; set; }
    
    [Required]
    public int ContractDuration { get; set; }
    
    [Required]
    public int? AdditionalSupport { get; set; }
}