namespace RevenueRecognition.Models.Domain;

public class Contract
{
    public int ContractId { get; set; }
    public int SoftwareId { get; set; }
    public int ClientId { get; set; }
    public int? DiscountId { get; set; }
    public float Price { get; set; }
    public DateTime PaymentStartDate { get; set; }
    public DateTime PaymentEndDate { get; set; }
    public DateTime ContractStartDate { get; set; }
    public DateTime ContractEndDate { get; set; }
    public bool IsSigned { get; set; }
    public DateTime AdditionalSupportEndDate { get; set; }
    
    public SoftwareLicense SoftwareLicense { get; set; }
    public Client Client { get; set; }
    public Discount Discount { get; set; }
    
    public ICollection<Payment> Payments { get; set; }
}