using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Favorite;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class FavoriteRepository : IFavoriteRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<FavoriteEntity> _dbSet;
    public FavoriteRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<FavoriteEntity>();
    }
}
