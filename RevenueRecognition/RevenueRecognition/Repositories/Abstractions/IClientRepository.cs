using RevenueRecognition.Models.Domain;
using RevenueRecognition.Models.Requests;

namespace RevenueRecognition.Repositories.Abstractions;

public interface IClientRepository
{
    Task<int> CreateIndividualClientAsync(IndividualClient client);
    Task<int> CreateCompanyClientAsync(CompanyClient krs);
    Task<IndividualClient?> GetIndividualClientByPeselAsync(string pesel);
    Task<CompanyClient?> GetCompanyClientByKrsAsync(string krs);

    Task<IndividualClient?> GetIndividualClientByIdAsync(int clientId);
    Task<CompanyClient?> GetCompanyClientByIdAsync(int clientId);
    Task<IndividualClient> UpdateIndividualClientAsync(IndividualClient individualClient, UpdateIndividiualClientDto requestDto);
    Task<CompanyClient> UpdateCompanyClientAsync(CompanyClient companyClient, UpdateCompanyClientDto requestDto);
    Task SoftDeleteClientAsync(IndividualClient client);
}