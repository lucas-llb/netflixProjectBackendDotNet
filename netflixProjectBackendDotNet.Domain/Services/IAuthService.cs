namespace netflixProjectBackendDotNet.Domain.Services;

public interface IAuthService
{
    Task<string?> LoginAsync(string userEmail, string password);
}
