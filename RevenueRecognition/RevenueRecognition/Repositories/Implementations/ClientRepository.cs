using System.Data;
using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Data;
using RevenueRecognition.Models.Domain;
using RevenueRecognition.Models.Requests;
using RevenueRecognition.Repositories.Abstractions;

namespace RevenueRecognition.Repositories.Implementations;

public class ClientRepository: IClientRepository
{
    private readonly AppDbContext _dbContext;

    public ClientRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateIndividualClientAsync(IndividualClient client)
    {
        _dbContext.IndividualClients.Add(client);
        await _dbContext.SaveChangesAsync();
        return client.ClientId;
    }

    public async Task<int> CreateCompanyClientAsync(CompanyClient client)
    {
        _dbContext.CompanyClients.Add(client);
        await _dbContext.SaveChangesAsync();
        return client.ClientId;
    }

    public async Task<IndividualClient?> GetIndividualClientByPeselAsync(string pesel)
    {
        return await _dbContext.IndividualClients.Where(ic => ic.PESEL == pesel && ic.IsDeleted == false).FirstOrDefaultAsync();
    }

    public async Task<CompanyClient?> GetCompanyClientByKrsAsync(string krs)
    {
        return await _dbContext.CompanyClients.Where(cc => cc.KRS == krs && cc.IsDeleted == false).FirstOrDefaultAsync();
    }

    public async Task<IndividualClient?> GetIndividualClientByIdAsync(int clientId)
    {
        return await _dbContext.IndividualClients.Where(ic => ic.ClientId == clientId && ic.IsDeleted == false).FirstOrDefaultAsync();
    }

    public async Task<CompanyClient?> GetCompanyClientByIdAsync(int clientId)
    {
        return await _dbContext.CompanyClients.Where(cc => cc.ClientId == clientId && cc.IsDeleted == false).FirstOrDefaultAsync();
    }

    public async Task<IndividualClient> UpdateIndividualClientAsync(IndividualClient individualClient, UpdateIndividiualClientDto requestDto)
    {
        if (requestDto.FirstName is not null)
        {
            individualClient.FirstName = requestDto.FirstName;
        }
        if (requestDto.LastName is not null)
        {
            individualClient.LastName = requestDto.LastName;
        }
        if (requestDto.PhoneNumber is not null)
        {
            individualClient.PhoneNumber = requestDto.PhoneNumber;
        }
        if (requestDto.Address is not null)
        {
            individualClient.Address = requestDto.Address;
        }
        if (requestDto.Email is not null)
        {
            individualClient.Email = requestDto.Email;
        }
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            await _dbContext.Entry(individualClient).ReloadAsync();
            throw;
        }
        
        return individualClient;
    }

    public async Task<CompanyClient> UpdateCompanyClientAsync(CompanyClient companyClient, UpdateCompanyClientDto requestDto)
    {
        if (requestDto.PhoneNumber is not null)
        {
            companyClient.PhoneNumber = requestDto.PhoneNumber;
        }
        if (requestDto.Address is not null)
        {
            companyClient.Address = requestDto.Address;
        }
        if (requestDto.Email is not null)
        {
            companyClient.Email = requestDto.Email;
        }
        if (requestDto.CompanyName is not null)
        {
            companyClient.CompanyName = requestDto.CompanyName;
        }

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            await _dbContext.Entry(companyClient).ReloadAsync();
            throw;
        }
        return companyClient;
    }

    public async Task SoftDeleteClientAsync(IndividualClient client)
    {
        client.IsDeleted = true;
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            await _dbContext.Entry(client).ReloadAsync();
            throw;
        }
    }
}