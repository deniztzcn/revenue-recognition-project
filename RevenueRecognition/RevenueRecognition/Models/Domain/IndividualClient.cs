namespace RevenueRecognition.Models.Domain;

public class IndividualClient : Client
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PESEL { get; set; }
    
    public byte[] RowVersion { get; set; }
}