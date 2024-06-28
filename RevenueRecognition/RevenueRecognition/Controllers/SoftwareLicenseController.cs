using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognition.Repositories.Abstractions;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Controllers;

[ApiController]
[Route("api/software-licenses")]
[Authorize]
public class SoftwareLicenseController: ControllerBase
{
    private readonly ISoftwareLicenseService _softwareLicenseService;

    public SoftwareLicenseController(ISoftwareLicenseService softwareLicenseService)
    {
        _softwareLicenseService = softwareLicenseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSoftwareLicenses()
    {
        var list = await _softwareLicenseService.GetSoftwareLicensesAsync();
        return Ok(list);
    }

    [HttpGet("{softwareLicenseId}")]
    public async Task<IActionResult> GetSoftwareLicenseById(int softwareLicenseId)
    {
        var softwareLicense = await _softwareLicenseService.GetSoftwareLicenseByIdAsync(softwareLicenseId);
        return Ok(softwareLicense);
    }
}