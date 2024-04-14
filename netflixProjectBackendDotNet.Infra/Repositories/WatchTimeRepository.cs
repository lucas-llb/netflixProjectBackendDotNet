using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.WatchTime;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class WatchTimeRepository : IWatchTimeRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<WatchTimeEntity> _dbSet;
    public WatchTimeRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<WatchTimeEntity>();
    }
}
