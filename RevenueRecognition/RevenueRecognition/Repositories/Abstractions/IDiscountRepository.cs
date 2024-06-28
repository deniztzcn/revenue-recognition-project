using RevenueRecognition.Models.Domain;

namespace RevenueRecognition.Repositories.Abstractions;

public interface IDiscountRepository
{
    Task<List<Discount>> GetValidDiscounts();
}