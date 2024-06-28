using RevenueRecognition.Models.Domain;
using RevenueRecognition.Models.Responses;

namespace RevenueRecognition.Mappers;

public static class SoftwareLicenseMapper
{
    public static SoftwareLicenseResponseDto SoftwareLicenseResponseDto(this SoftwareLicense softwareLicense, string currentVersion)
    {
        return new SoftwareLicenseResponseDto
        {
            SoftwareId = softwareLicense.SoftwareId,
            Name = softwareLicense.Name,
            Category = softwareLicense.Category,
            Description = softwareLicense.Description,
            CurrentVersion = currentVersion,
            Price = softwareLicense.Price
        };
    }
}