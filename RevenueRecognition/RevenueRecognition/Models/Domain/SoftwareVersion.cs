namespace RevenueRecognition.Models.Domain;

public class SoftwareVersion
{
    public int SoftwareVersionId { get; set; }
    public int SoftwareLicenseId { get; set; }
    public string Version { get; set; }
    public string ReleaseNotes { get; set; }
    public DateTime ReleaseDate { get; set; }
    
    public SoftwareLicense SoftwareLicense { get; set; }
}