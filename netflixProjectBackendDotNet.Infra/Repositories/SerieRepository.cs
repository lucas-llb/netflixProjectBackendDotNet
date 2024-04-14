using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Serie;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class SerieRepository : ISerieRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<SerieEntity> _dbSet;
    public SerieRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<SerieEntity>();
    }
}
