using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Data;
using RevenueRecognition.Models.Domain;
using RevenueRecognition.Repositories.Abstractions;

namespace RevenueRecognition.Repositories.Implementations;

public class SoftwareLicenseRepository: ISoftwareLicenseRepository
{
    private readonly AppDbContext _dbContext;

    public SoftwareLicenseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SoftwareLicense>> GetSoftwareLicensesAsync()
    {
        return await _dbContext.SoftwareLicenses.ToListAsync();
    }

    public async Task<SoftwareLicense?> GetSoftwareLicenseByIdAsync(int softwareLicenseId)
    {
        return await _dbContext.SoftwareLicenses.FindAsync(softwareLicenseId);
    }
}