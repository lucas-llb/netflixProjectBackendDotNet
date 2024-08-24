using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Entities.User;

namespace netflixProjectBackendDotNet.Domain.Repositories;

public interface IUserRepository
{
    Task<UserEntity?> RegisterAsync(UserEntity newUser);
    Task<bool> LoginAsync(string email, string password);
    Task<UserEntity?> GetByEmailAsync(string email);
    Task<UserEntity?> UpdateAsync(UserEntity newUser);
    Task<UserEntity?> UpdatePasswordAsync(int id, string password);
    Task<bool> CheckPasswordAsync(int id, string password);
    Task<IEnumerable<EpisodeEntity>> GetUserWithWatchListAsync(int id);
}
