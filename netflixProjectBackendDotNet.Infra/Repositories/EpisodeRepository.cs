using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class EpisodeRepository : IEpisodeRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<EpisodeEntity> _dbSet;
    public EpisodeRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<EpisodeEntity>();
    }
}
