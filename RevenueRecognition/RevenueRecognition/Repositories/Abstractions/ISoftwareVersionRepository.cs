namespace RevenueRecognition.Repositories.Abstractions;

public interface ISoftwareVersionRepository
{
    Task<string?> GetLastVersionBySoftwareId(int softwareId);
}