using System.IdentityModel.Tokens.Jwt;
using RevenueRecognition.Contracts;

namespace RevenueRecognition.Services.Abstractions;

public interface IAuthService
{
    void RegisterUser(RegisterUserRequest request);
    (string accessToken, string refreshToken) LoginUser(LoginUserRequest request);
}