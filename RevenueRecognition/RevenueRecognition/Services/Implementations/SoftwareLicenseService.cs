using RevenueRecognition.Exceptions;
using RevenueRecognition.Mappers;
using RevenueRecognition.Models.Responses;
using RevenueRecognition.Repositories.Abstractions;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Services.Implementations;

public class SoftwareLicenseService: ISoftwareLicenseService
{
    private readonly ISoftwareLicenseRepository _softwareLicenseRepository;
    private readonly ISoftwareVersionRepository _softwareVersionRepository;

    public SoftwareLicenseService(ISoftwareLicenseRepository softwareLicenseRepository,ISoftwareVersionRepository softwareVersionRepository)
    {
        _softwareVersionRepository = softwareVersionRepository;
        _softwareLicenseRepository = softwareLicenseRepository;
    }

    public async Task<SoftwareLicenseResponseDto> GetSoftwareLicenseByIdAsync(int softwareLicenseId)
    {
        var softwareLicense = await _softwareLicenseRepository.GetSoftwareLicenseByIdAsync(softwareLicenseId)
                              ?? throw new SoftwareLicenseNotFound(softwareLicenseId);
        var currentVersion = await _softwareVersionRepository.GetLastVersionBySoftwareId(softwareLicenseId);

        return softwareLicense.SoftwareLicenseResponseDto(currentVersion!);
    }

    public async Task<List<SoftwareLicenseResponseDto>> GetSoftwareLicensesAsync()
    {
        var rawList = await _softwareLicenseRepository.GetSoftwareLicensesAsync();
        var dtoList = new List<SoftwareLicenseResponseDto>();
        foreach (var softwareLicense in rawList)
        {
            var currentVersion =
                await _softwareVersionRepository.GetLastVersionBySoftwareId(softwareLicense.SoftwareId);
            dtoList.Add(softwareLicense.SoftwareLicenseResponseDto(currentVersion!));
        }
        return dtoList;
    }
}