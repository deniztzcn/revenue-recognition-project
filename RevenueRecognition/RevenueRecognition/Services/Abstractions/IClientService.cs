using RevenueRecognition.Models.Domain;
using RevenueRecognition.Models.Requests;
using RevenueRecognition.Models.Responses;

namespace RevenueRecognition.Services.Abstractions;

public interface IClientService
{
    Task<int> CreateIndividualClientAsync(CreateIndividualClientDto createIndividualClientDto);
    Task<int> CreateCompanyClientAsync(CreateCompanyClientDto requestDto);

    Task<IndividualClient> GetIndividualClientByIdAsync(int clientId);
    Task<CompanyClient> GetCompanyClientByIdAsync(int clientId);
    Task<IndividualClientResponseDto> UpdateIndividualClientAsync(IndividualClient client, UpdateIndividiualClientDto requestDto);
    Task<CompanyClientResponseDto> UpdateCompanyClientAsync(CompanyClient client, UpdateCompanyClientDto requestDto);
    Task DeleteIndividualClientByIdAsync(int clientId);
}