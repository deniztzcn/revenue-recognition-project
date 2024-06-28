using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Repositories.Abstractions;

public interface ISoftwareLicenseRepository
{
    Task<List<SoftwareLicense>> GetSoftwareLicensesAsync();
    Task<SoftwareLicense?> GetSoftwareLicenseByIdAsync(int softwareLicenseId);
}