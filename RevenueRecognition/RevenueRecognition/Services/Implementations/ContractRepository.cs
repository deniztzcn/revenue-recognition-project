using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Data;
using RevenueRecognition.Models.Domain;
using RevenueRecognition.Models.Requests;
using RevenueRecognition.Repositories.Abstractions;

namespace RevenueRecognition.Services.Implementations;

public class ContractRepository : IContractRepository
{
    private readonly AppDbContext _dbContext;

    public ContractRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SignContract(Contract contract)
    {
        contract.IsSigned = true;
        await _dbContext.SaveChangesAsync();
    }

    public Task<int> CreateContract(CreateContractDto createContractDto)
    {
        throw new NotImplementedException();
    }

    public async Task<Contract?> GetContractByClientIdAndSoftwareLicenseId(int clientId, int softwareLicenseId)
    {
        return await _dbContext.Contracts
            .Where(c => c.ClientId == clientId)
            .Where(c => c.SoftwareId == softwareLicenseId)
            .Where(c => c.IsSigned == true)
            .FirstOrDefaultAsync();
    }
    
    public async Task<bool> HasAnyContract(int clientId)
    {
        return await _dbContext.Contracts.AnyAsync(c => c.ClientId == clientId && c.IsSigned == true);
    }

    public async Task<int> AddContractAsync(Contract contractToAdd)
    {
        _dbContext.Contracts.Add(contractToAdd);
        await _dbContext.SaveChangesAsync();
        return contractToAdd.ContractId;
    }

    public async Task<Contract?> GetContractByIdAsync(int contractId)
    {
        return await _dbContext.Contracts.FindAsync(contractId);
    }

    public async Task<List<Contract>> GetAllSignedContracts()
    {
        return await _dbContext.Contracts.Where(c => c.IsSigned).ToListAsync();
    }

    public async Task<List<Contract>> GetSignedContractsBySoftwareIdAsync(int softwareLicenseId)
    {
        return await _dbContext.Contracts.Where(c => c.IsSigned).Where(c => c.SoftwareId == softwareLicenseId)
            .ToListAsync();
    }

    public async Task<List<Contract>> GetContracts()
    {
        return await _dbContext.Contracts.ToListAsync();
    }

    public async Task<List<Contract>> GetContractsBySoftwareIdAsync(int softwareLicenseId)
    {
        return await _dbContext.Contracts.Where(c => c.SoftwareId == softwareLicenseId).ToListAsync();
    }
}