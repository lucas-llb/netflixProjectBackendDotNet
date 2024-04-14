using netflixProjectBackendDotNet.Domain.Entities.User;

namespace netflixProjectBackendDotNet.Domain.Repositories;

public interface IUserRepository
{
    Task<UserEntity?> RegisterAsync(UserEntity newUser);
}
