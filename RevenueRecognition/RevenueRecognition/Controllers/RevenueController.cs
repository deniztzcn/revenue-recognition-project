using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Controllers;

[ApiController]
[Route("api/revenues")]
[Authorize]
public class RevenueController: ControllerBase
{
    private readonly IRevenueService _revenueService;
    private readonly IExchangeService _exchangeService;

    public RevenueController(IRevenueService revenueService)
    {
        _revenueService = revenueService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRevenueForAllContracts([FromQuery] string? currency)
    {
        var totalRevenue = await _revenueService.GetRevenueForAllContractsAsync();
        if (currency.IsNullOrEmpty())
        {
            return Ok(new {TotalRevenue = totalRevenue});
        }

        var rate = await _exchangeService.GetRate(currency);
        var revenueInForeignCurrency = totalRevenue * rate;
        return Ok(new { Currency = currency, TotalRevenue = revenueInForeignCurrency });
    }

    [HttpGet("{softwareLicenseId}")]
    public async Task<IActionResult> GetRevenueForSoftwareLicenceById(int softwareLicenseId, [FromQuery] string? currency)
    {
        var totalRevenue = await _revenueService.GetRevenueForSoftwareLicenseById(softwareLicenseId);
        
        if (currency.IsNullOrEmpty())
        {
            return Ok(new {TotalRevenue = totalRevenue});
        }

        var rate = await _exchangeService.GetRate(currency);
        var revenueInForeignCurrency = totalRevenue * rate;
        return Ok(new { Currency = currency, TotalRevenue = revenueInForeignCurrency });
    }

    [HttpGet("predicted")]
    public async Task<IActionResult> GetPredictedRevenueForAllContracts([FromQuery] string? currency)
    {
        var predictedRevenue = await _revenueService.GetPredictedRevenueForAllContracts();
        
        if (currency.IsNullOrEmpty())
        {
            return Ok(new {PredictedRevenue = predictedRevenue});
        }

        var rate = await _exchangeService.GetRate(currency);
        var revenueInForeignCurrency = predictedRevenue * rate;
        return Ok(new { Currency = currency, PredictedRevenue = revenueInForeignCurrency });
    }
    
    [HttpGet("predicted/{softwareLicenseId}")]
    public async Task<IActionResult> GetPredictedRevenueForSoftwareLicenseById(int softwareLicenseId,[FromQuery] string? currency)
    {
        var predictedRevenue = await _revenueService.GetPredictedRevenueForSoftwareLicenseById(softwareLicenseId);
        
        if (currency.IsNullOrEmpty())
        {
            return Ok(new {PredictedRevenue = predictedRevenue});
        }

        var rate = await _exchangeService.GetRate(currency);
        var revenueInForeignCurrency = predictedRevenue * rate;
        return Ok(new { Currency = currency, PredictedRevenue = revenueInForeignCurrency });
    }
}   