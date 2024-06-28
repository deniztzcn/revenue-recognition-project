using RevenueRecognition.Repositories.Abstractions;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Services.Implementations;

public class RevenueService: IRevenueService
{
    private readonly IContractRepository _contractRepository;

    public RevenueService(IContractRepository contractRepository)
    {
        _contractRepository = contractRepository;
    }

    public async Task<float> GetRevenueForAllContractsAsync()
    {
        var contracts = await _contractRepository.GetAllSignedContracts();
        var totalRevenue = contracts.Sum(c => c.Price);
        return totalRevenue;
    }

    public async Task<float> GetRevenueForSoftwareLicenseById(int softwareLicenseId)
    {
        var contracts = await _contractRepository.GetSignedContractsBySoftwareIdAsync(softwareLicenseId);
        var totalRevenue = contracts.Sum(c => c.Price);
        return totalRevenue;
    }

    public async Task<float> GetPredictedRevenueForAllContracts()
    {
        var contracts = await _contractRepository.GetContracts();
        var totalPredictedRevenue = contracts.Sum(c => c.Price);
        return totalPredictedRevenue;
    }

    public async Task<float> GetPredictedRevenueForSoftwareLicenseById(int softwareLicenseId)
    {
        var contracts = await _contractRepository.GetContractsBySoftwareIdAsync(softwareLicenseId);
        var totalPredictedRevenue = contracts.Sum(c => c.Price);
        return totalPredictedRevenue;
    }
}