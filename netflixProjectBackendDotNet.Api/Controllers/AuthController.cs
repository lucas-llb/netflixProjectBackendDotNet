using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Models.Request;
using netflixProjectBackendDotNet.Domain.Repositories;

namespace netflixProjectBackendDotNet.Api.Controllers;
[ApiController]
[Route("/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody]RegisterRequest request)
    {
        var result = await _userRepository.RegisterAsync(request.CreateUser());

        return result is null ?
            BadRequest("User already exists") :
            Ok(result);
    }

}
