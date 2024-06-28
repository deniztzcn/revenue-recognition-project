using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Repositories.Abstractions;

public interface IPaymentRepository
{
    Task<List<Payment>> GetPaymentsByContractId(int contractId);
    Task<int> AddPaymentAsync(Payment payment);
}