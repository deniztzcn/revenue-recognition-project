using System.Collections;

namespace RevenueRecognition.Models.Domain;

public abstract class Client
{
    public int ClientId { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Contract> Contracts { get; set; }
}