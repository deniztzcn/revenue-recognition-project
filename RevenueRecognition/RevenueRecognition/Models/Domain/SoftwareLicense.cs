using System.Collections;

namespace RevenueRecognition.Models.Domain;

public class SoftwareLicense
{
    public int SoftwareId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public float Price { get; set; }
    
    public ICollection<Contract> Contracts { get; set; }
    public ICollection<SoftwareVersion> SoftwareVersions { get; set; }
}