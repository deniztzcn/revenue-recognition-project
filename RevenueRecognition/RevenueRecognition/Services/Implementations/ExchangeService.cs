using Newtonsoft.Json;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Services.Implementations;

public class ExchangeService: IExchangeService
{
    private readonly HttpClient _httpClient;

    public ExchangeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<float> GetRate(string currency)
    {
        string apiKey = "e245e0dbfa97cd0a1f0a5563";
        string requestUri = $"https://v6.exchangerate-api.com/v6/{apiKey}/latest/PLN";
        
        var response = await _httpClient.GetAsync(requestUri);
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ExchangeRateResponse>(jsonResponse);

            if (data != null && data.ConversionRates.ContainsKey(currency.ToUpper()))
            {
                return data.ConversionRates[currency.ToUpper()];
            }
            else
            {
                throw new Exception("Invalid currency code or conversion rate not found.");
            }
        }
        else
        {
            throw new HttpRequestException("Failed to fetch data from the exchange rate API.");
        }
    }
    
    private class ExchangeRateResponse
    {
        [JsonProperty("conversion_rates")]
        public Dictionary<string, float> ConversionRates { get; set; }
    }
}