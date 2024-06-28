namespace RevenueRecognition.Models.Responses;

public class SoftwareLicenseResponseDto
{
    public required int SoftwareId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required string CurrentVersion { get; set; }
    public required float Price { get; set; }
}