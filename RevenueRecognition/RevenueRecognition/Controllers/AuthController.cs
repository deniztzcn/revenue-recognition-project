using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevenueRecognition.Contracts;
using RevenueRecognition.Services.Abstractions;

namespace RevenueRecognition.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        _authService.RegisterUser(request);
        return Ok();
    }
    
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginUserRequest request)
    {
        var (accessToken, refreshToken) = _authService.LoginUser(request);
        return Ok(new
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        });
    }
}