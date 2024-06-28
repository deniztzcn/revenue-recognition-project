namespace RevenueRecognition.Models.Domain;

public class CompanyClient : Client
{
    public string CompanyName { get; set; }
    public string KRS { get; set; }
    
    public byte[] RowVersion { get; set; }
}