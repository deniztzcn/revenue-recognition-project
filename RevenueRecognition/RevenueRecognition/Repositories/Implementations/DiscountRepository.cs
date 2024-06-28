using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Data;
using RevenueRecognition.Models.Domain;
using RevenueRecognition.Repositories.Abstractions;

namespace RevenueRecognition.Repositories.Implementations;

public class DiscountRepository: IDiscountRepository
{
    private readonly AppDbContext _dbContext;

    public DiscountRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Discount>> GetValidDiscounts()
    {
        return await _dbContext.Discounts.Where(d => d.StartDate <= DateTime.Now && DateTime.Now <= d.EndDate).ToListAsync();
    }
}