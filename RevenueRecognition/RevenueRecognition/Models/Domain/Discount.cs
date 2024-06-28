namespace RevenueRecognition.Models.Domain;

public class Discount
{
    public int DiscountId { get; set; }
    public string Description { get; set; }
    public float DiscountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<Contract> Contracts { get; set; }
}