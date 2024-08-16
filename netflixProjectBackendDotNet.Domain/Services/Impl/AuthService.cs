using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using netflixProjectBackendDotNet.Domain.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace netflixProjectBackendDotNet.Domain.Services.Impl;

public class AuthService(IUserRepository userRepository, IConfiguration config) : IAuthService
{
    public async Task<string?> LoginAsync(string userEmail, string password)
    {
        var loggedIn = await userRepository.LoginAsync(userEmail, password);

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
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(claims: claims, issuer: config["Jwt:Issuer"], signingCredentials: credentials, expires: DateTime.Now.AddDays(1));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
