using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Models.Request;
using netflixProjectBackendDotNet.Api.Models.Responses;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Domain.Services;

namespace netflixProjectBackendDotNet.Api.Controllers;
[ApiController]
[Route("/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public AuthController(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
    {
        var result = await _userRepository.RegisterAsync(request.CreateUser());

        return result is null ?
            BadRequest("User already exists") :
            Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password);

        return string.IsNullOrEmpty(token) ?
            BadRequest("Email or password is incorrect") :
            Ok(new LoginResponse(token));
    }

}
