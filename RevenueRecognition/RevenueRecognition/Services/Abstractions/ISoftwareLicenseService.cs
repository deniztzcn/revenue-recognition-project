using System.Collections;
using RevenueRecognition.Models.Responses;

namespace RevenueRecognition.Services.Abstractions;

public interface ISoftwareLicenseService
{
    Task<List<SoftwareLicenseResponseDto>> GetSoftwareLicensesAsync();
    Task<SoftwareLicenseResponseDto> GetSoftwareLicenseByIdAsync(int softwareLicenseId);
}