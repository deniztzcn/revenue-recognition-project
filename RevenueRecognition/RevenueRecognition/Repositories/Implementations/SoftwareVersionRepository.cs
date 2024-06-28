using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Data;
using RevenueRecognition.Repositories.Abstractions;

namespace RevenueRecognition.Repositories.Implementations;

public class SoftwareVersionRepository: ISoftwareVersionRepository
{
    private readonly AppDbContext _dbContext;

    public SoftwareVersionRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string?> GetLastVersionBySoftwareId(int softwareId)
    {
        return await _dbContext.SoftwareVersions.Where(sv => sv.SoftwareVersionId == softwareId)
            .OrderByDescending(sv => sv.ReleaseDate)
            .Select(sv => sv.Version)
            .FirstOrDefaultAsync();
    }
}