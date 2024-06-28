using RevenueRecognition.Contracts;
using RevenueRecognition.Repositories.Abstractions;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Services.Implementations;

public class AuthService: IAuthService
{
    private readonly IAppUserRepository _appUserRepository;

    public AuthService(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public void RegisterUser(RegisterUserRequest request)
    {
        _appUserRepository.RegisterUser(request);
    }

    public (string accessToken, string refreshToken) LoginUser(LoginUserRequest request)
    {
        return _appUserRepository.LoginUser(request);
    }
}