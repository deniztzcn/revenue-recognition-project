using RevenueRecognition.Contracts;

namespace RevenueRecognition.Repositories.Abstractions;

public interface IAppUserRepository
{
    void RegisterUser(RegisterUserRequest request);
    (string accessToken, string refreshToken) LoginUser(LoginUserRequest request);
}