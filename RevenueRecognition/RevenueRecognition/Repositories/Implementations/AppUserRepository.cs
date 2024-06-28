using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RevenueRecognition.Contracts;
using RevenueRecognition.Data;
using RevenueRecognition.Exceptions;
using RevenueRecognition.Helpers;
using RevenueRecognition.Models.Domain;
using RevenueRecognition.Repositories.Abstractions;

namespace RevenueRecognition.Repositories.Implementations;

public class AppUserRepository: IAppUserRepository
{
    private readonly AppDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public AppUserRepository(AppDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }
    
    public void RegisterUser(RegisterUserRequest request)
    {
        var isUsernameExists = _dbContext.AppUsers.Any(u => string.Equals(u.Username,request.Username,StringComparison.OrdinalIgnoreCase));
        if (isUsernameExists)
        {
            throw new UsernameAlreadyExistsException(request.Username);
        }
        var (hashedPassword, salt) = SecurityHelpers.GetHashedPasswordAndSalt(request.Password);

        var userToAdd = new AppUser
        {
            Username = request.Username,
            Password = hashedPassword,
            Type = request.Role,
            Salt = salt,
        };

        _dbContext.AppUsers.Add(userToAdd);
        _dbContext.SaveChanges();
    }
    
    public (string accessToken, string refreshToken) LoginUser(LoginUserRequest request)
    {
        var user = _dbContext.AppUsers.FirstOrDefault(u => u.Username == request.Username);
        if (user == null)
        {
            throw new UserNotFound(request.Username);
        }
        
        var hashedPassword = SecurityHelpers.GetHashedPasswordWithSalt(request.Password, user.Salt);
        if (user.Password != hashedPassword)
        {
            throw new InvalidPassword();
        }
        
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.IdUser)),
            new Claim(ClaimTypes.Name, $"{user.Username}"),
            new Claim(ClaimTypes.Role,user.Type)
        };
        
        var accessToken = GenerateAccessToken(userClaims);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExp = DateTime.UtcNow.AddDays(30);

        return (accessToken, refreshToken);
    }
    private string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var sskey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:SecretKey"]));
        var credentials = new SigningCredentials(sskey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Auth:ValidIssuer"],
            audience: _configuration["Auth:ValidAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}