using RevenueRecognition.Exceptions;
using RevenueRecognition.Mappers;
using RevenueRecognition.Models.Domain;
using RevenueRecognition.Models.Requests;
using RevenueRecognition.Models.Responses;
using RevenueRecognition.Repositories.Abstractions;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Services.Implementations;

public class ClientService: IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<int> CreateIndividualClientAsync(CreateIndividualClientDto requestDto)
    {
        var getClient = await _clientRepository.GetIndividualClientByPeselAsync(requestDto.PESEL);
        if (getClient is not null)
        {
            throw new PeselExistsException(requestDto.PESEL);
        }
        
        var client = new IndividualClient
        {
            FirstName = requestDto.FirstName,
            LastName = requestDto.LastName,
            PhoneNumber = requestDto.PhoneNumber,
            Address = requestDto.Address,
            Email = requestDto.Email,
            PESEL = requestDto.PESEL
        };

        return await _clientRepository.CreateIndividualClientAsync(client);
    }

    public async Task<int> CreateCompanyClientAsync(CreateCompanyClientDto requestDto)
    {
        var existsClient = await _clientRepository.GetCompanyClientByKrsAsync(requestDto.KRS);
        if (existsClient is not null)
        {
            throw new KrsExistsException(requestDto.KRS);
        }
        
        var client = new CompanyClient
        {
            CompanyName = requestDto.CompanyName,
            PhoneNumber = requestDto.PhoneNumber,
            Address = requestDto.Address,
            Email = requestDto.Email,
            KRS = requestDto.KRS,
        };

        return await _clientRepository.CreateCompanyClientAsync(client);
    }

    public async Task<IndividualClient> GetIndividualClientByIdAsync(int clientId)
    {
        var client = await _clientRepository.GetIndividualClientByIdAsync(clientId)
                     ?? throw new IndividualClientNotFound(clientId);
        return client;
    }
    public async Task<CompanyClient> GetCompanyClientByIdAsync(int clientId)
    {
        var client = await _clientRepository.GetCompanyClientByIdAsync(clientId)
            ?? throw new CompanyClientNotFound(clientId);
        return client;
    }

    public async Task<IndividualClientResponseDto> UpdateIndividualClientAsync(IndividualClient individiualClient, UpdateIndividiualClientDto requestDto)
    {
        var client = await _clientRepository.UpdateIndividualClientAsync(individiualClient, requestDto);
        return client.ToInvidividualClientResponseDto();
    }
    
    public async Task<CompanyClientResponseDto> UpdateCompanyClientAsync(CompanyClient companyClient, UpdateCompanyClientDto requestDto)
    {
        var client = await _clientRepository.UpdateCompanyClientAsync(companyClient, requestDto);
        return client.ToCompanyClientResponseDto();
    }

    public async Task DeleteIndividualClientByIdAsync(int clientId)
    {
        var client = await GetIndividualClientByIdAsync(clientId) ?? throw new IndividualClientNotFound(clientId);
        await _clientRepository.SoftDeleteClientAsync(client);
    }
}