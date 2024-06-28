using RevenueRecognition.Models.Requests;

namespace RevenueRecognition.Services.Abstractions;

public interface IContractService
{
    Task<int> CreateContract(CreateContractDto createContractDto);
    Task<int> AddPaymentContract(int contractId, PaymentContractDto requestDto);
}