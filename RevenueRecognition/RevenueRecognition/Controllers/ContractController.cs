using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognition.Models.Requests;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Controllers;

[ApiController]
[Route("api/contracts")]
[Authorize]
public class ContractController: ControllerBase
{
    private readonly IContractService _contractService;

    public ContractController(IContractService contractService)
    {
        _contractService = contractService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContract(CreateContractDto requestDto)
    {
        var contractId = await _contractService.CreateContract(requestDto);
        return Created($"api/contracts/{contractId}", new { ContractId = contractId });
    }

    [HttpPost("{contractId}/payments")]
    public async Task<IActionResult> AddPaymentContract(int contractId,PaymentContractDto requestDto)
    {
        var paymentId = await _contractService.AddPaymentContract(contractId, requestDto);
        return Created($"api/contracts/{contractId}/payments/{paymentId}", new { PaymentId = paymentId });
    }
}