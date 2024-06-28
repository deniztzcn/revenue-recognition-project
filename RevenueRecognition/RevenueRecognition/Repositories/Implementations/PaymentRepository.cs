using Microsoft.EntityFrameworkCore;
using RevenueRecognition.Data;
using RevenueRecognition.Models.Domain;
using RevenueRecognition.Repositories.Abstractions;

namespace RevenueRecognition.Repositories.Implementations;

public class PaymentRepository: IPaymentRepository
{
    private readonly AppDbContext _dbContext;

    public PaymentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Payment>> GetPaymentsByContractId(int contractId)
    {
        return await _dbContext.Payments.Where(p => p.ContractId == contractId).ToListAsync();
    }

    public async Task<int> AddPaymentAsync(Payment payment)
    {
        await _dbContext.Payments.AddAsync(payment);
        await _dbContext.SaveChangesAsync();
        return payment.PaymentId;
    }
}