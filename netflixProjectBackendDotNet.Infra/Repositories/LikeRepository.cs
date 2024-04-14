using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Like;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class LikeRepository : ILikeRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<LikeEntity> _dbSet;
    public LikeRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<LikeEntity>();
    }
}
