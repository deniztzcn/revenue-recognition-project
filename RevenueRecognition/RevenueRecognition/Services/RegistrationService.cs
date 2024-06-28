using RevenueRecognition.Repositories.Abstractions;
using RevenueRecognition.Repositories.Implementations;
using RevenueRecognition.Services.Abstractions;
using RevenueRecognition.Services.Implementations;

namespace RevenueRecognition.Services;

public static class RegistrationService
{
    public static void RegisterServices(this IServiceCollection app)
    {
        app.AddScoped<IClientService,ClientService>();
        app.AddScoped<IContractService,ContractService>();
        app.AddScoped<ISoftwareLicenseService, SoftwareLicenseService>();
        app.AddScoped<IExchangeService, ExchangeService>();
        app.AddScoped<IRevenueService, RevenueService>();
        app.AddScoped<IAuthService, AuthService>();
        app.AddScoped<IExchangeService, ExchangeService>();
    }

    public static void RegisterRepositories(this IServiceCollection app)
    {
        app.AddScoped<IClientRepository, ClientRepository>();
        app.AddScoped<IContractRepository, ContractRepository>();
        app.AddScoped<IDiscountRepository, DiscountRepository>();
        app.AddScoped<IPaymentRepository, PaymentRepository>();
        app.AddScoped<ISoftwareLicenseRepository, SoftwareLicenseRepository>();
        app.AddScoped<ISoftwareVersionRepository, SoftwareVersionRepository>();
        app.AddScoped<IAppUserRepository,AppUserRepository>();
    }
}