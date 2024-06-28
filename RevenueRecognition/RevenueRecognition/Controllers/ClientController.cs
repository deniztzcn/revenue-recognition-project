using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognition.Models.Requests;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Controllers;

[ApiController]
[Route("api/clients")]
[Authorize]
public class ClientController: ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost("individuals")]
    public async Task<IActionResult> AddIndividualClient([FromBody] CreateIndividualClientDto requestDto)
    {
        var clientId = await _clientService.CreateIndividualClientAsync(requestDto);
        return Created($"api/clients/individuals/{clientId}",new {ClientId = clientId});
    }

    [HttpPost("companies")]
    public async Task<IActionResult> AddCompanyClient([FromBody] CreateCompanyClientDto requestDto)
    {
        var clientId = await _clientService.CreateCompanyClientAsync(requestDto);
        return Created($"api/clients/companies/{clientId}", new {ClientId = clientId});
    }

    [HttpPut("individiuals/{clientId:int}")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> UpdateIndividualClient(int clientId,[FromBody] UpdateIndividiualClientDto requestDto)
    {
        var client = await _clientService.GetIndividualClientByIdAsync(clientId);
        var clientDto = await _clientService.UpdateIndividualClientAsync(client, requestDto);
        return Ok(clientDto);
    }
    
    [HttpPut("companies/{clientId:int}")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> UpdateCompanyClient(int clientId,[FromBody] UpdateCompanyClientDto requestDto)
    {
        var client = await _clientService.GetCompanyClientByIdAsync(clientId);
        var clientDto = await _clientService.UpdateCompanyClientAsync(client, requestDto);
        return Ok(clientDto);
    }

    [HttpDelete("individiuals/{clientId}")]
    [Authorize(Policy = "AdminPolicy")]
    public async Task<IActionResult> DeleteIndividualClient(int clientId)
    {
        await _clientService.DeleteIndividualClientByIdAsync(clientId);
        return NoContent();
    }
}