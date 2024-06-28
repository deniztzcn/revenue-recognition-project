namespace RevenueRecognition.Services.Abstractions;

public interface IRevenueService
{
    Task<float> GetRevenueForAllContractsAsync();
    Task<float> GetRevenueForSoftwareLicenseById(int softwareLicenseId);
    Task<float> GetPredictedRevenueForAllContracts();
    Task<float> GetPredictedRevenueForSoftwareLicenseById(int softwareLicenseId);
}