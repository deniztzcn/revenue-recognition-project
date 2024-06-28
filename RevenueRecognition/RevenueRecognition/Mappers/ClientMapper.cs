using RevenueRecognition.Models.Domain;
using RevenueRecognition.Models.Responses;

namespace RevenueRecognition.Mappers;

public static class ClientMapper
{
    public static IndividualClientResponseDto ToInvidividualClientResponseDto(this IndividualClient client)
    {
        return new IndividualClientResponseDto
        {
            ClientId = client.ClientId,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Address = client.Address,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            PESEL = client.PESEL
        };
    }
    
    public static CompanyClientResponseDto ToCompanyClientResponseDto(this CompanyClient client)
    {
        return new CompanyClientResponseDto
        {
            ClientId = client.ClientId,
            Address = client.Address,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            CompanyName = client.CompanyName,
            KRS = client.KRS
        };
    }
}