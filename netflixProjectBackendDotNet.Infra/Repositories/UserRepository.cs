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

    public async Task<UserEntity?> RegisterAsync(UserEntity newUser)
    {
        var actualUser = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == newUser.Email);

        if (actualUser is null)
        {
            var entity = await _dbSet.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        return null;
    }
}
