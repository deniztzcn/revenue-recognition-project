using RevenueRecognition.Models.Domain;
using RevenueRecognition.Models.Requests;

namespace RevenueRecognition.Repositories.Abstractions;

public interface IContractRepository
{
    Task<int> CreateContract(CreateContractDto createContractDto);
    Task<Contract?> GetContractByClientIdAndSoftwareLicenseId(int clientId, int softwareLicenseId);
    Task<bool> HasAnyContract(int clientId);
    Task<int> AddContractAsync(Contract contractToAdd);
    Task<Contract?> GetContractByIdAsync(int contractId);
    Task SignContract(Contract contract);
    Task<List<Contract>> GetAllSignedContracts();
    Task<List<Contract>> GetSignedContractsBySoftwareIdAsync(int softwareLicenseId);
    Task<List<Contract>> GetContracts();
    Task<List<Contract>> GetContractsBySoftwareIdAsync(int softwareLicenseId);
}