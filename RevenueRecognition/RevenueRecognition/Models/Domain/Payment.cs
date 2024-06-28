namespace RevenueRecognition.Models.Domain;

public class Payment
{
    public int PaymentId { get; set; }
    public int ContractId { get; set; }
    public float Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public bool IsFinalPayment { get; set; }

    public Contract Contract { get; set; }
}