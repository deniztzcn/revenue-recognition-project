using System.ComponentModel.DataAnnotations;

namespace RevenueRecognition.Models.Requests;

public class PaymentContractDto
{
    [Required]
    public float Amount { get; set; }
}