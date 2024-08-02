using netflixProjectBackendDotNet.Domain.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace netflixProjectBackendDotNet.Domain.Services.Impl;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string?> LoginAsync(string userEmail, string password)
    {
        var loggedIn = await _userRepository.LoginAsync(userEmail, password);

        if (loggedIn)
        {
            return BuildToken(userEmail);
        }

        return null;
    }

    private string BuildToken(string userEmail)
    {
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Email, userEmail),
        };

        var token = new JwtSecurityToken(claims: claims);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
