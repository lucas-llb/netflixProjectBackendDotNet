using netflixProjectBackendDotNet.Domain.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace netflixProjectBackendDotNet.Api.Middlewares;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _requestDelegate;
    private readonly IUserRepository _userRepository;

    public AuthenticationMiddleware(RequestDelegate requestDelegate, IUserRepository userRepository)
    {
        _requestDelegate = requestDelegate;
        _userRepository = userRepository;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            var token = authHeader.ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var email = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Email).Value;
            var user = await _userRepository.GetByEmailAsync(email);
            if (user is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.Phone),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.DateOfBirth, user.Birth.ToString()),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                };

                var identity = new ClaimsIdentity(claims);
                context.User = new ClaimsPrincipal(identity);
            }
        }

        await _requestDelegate(context);
    }
}
