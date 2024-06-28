namespace RevenueRecognition.Services.Abstractions;

public interface IExchangeService
{
    Task<float> GetRate(string currency);
}