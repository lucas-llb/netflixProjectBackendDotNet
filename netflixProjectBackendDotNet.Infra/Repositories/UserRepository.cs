using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.User;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<UserEntity> _dbSet;
    public UserRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<UserEntity>();
    }
}
