using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Serie;
using netflixProjectBackendDotNet.Domain.Filters;
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
        _dbSet = _context.Set<SerieEntity>();
    }

    public async Task<IEnumerable<SerieEntity?>> GetTopTenNewestAsync()
    {
        var series = await _dbSet
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedAt)
            .Take(10)
            .ToListAsync();

        return series;
    }

    public async Task<IEnumerable<SerieEntity?>> GetRandomFeaturedSeriesAsync()
    {
        var series = await _dbSet
            .AsNoTracking()
            .Where(x => x.Featured == true)
            .ToListAsync();

        return series.Take(3);
    }

    public async Task<SerieEntity?> GetByIdWithEpisodesAsync(int id)
    {
        var serie = await _dbSet
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Include(x => x.Episodes.OrderBy(x => x.Order))
            .FirstOrDefaultAsync();

        return serie;
    }

    public async Task<IEnumerable<SerieEntity>> FindByNameAsync(string name, PaginatedFilter filter)
    {
        var series = await _dbSet
            .AsNoTracking()
            .Where(x => EF.Functions.ILike(x.Name, $"%{name}%"))
            .Skip(filter.PerPage * filter.Page)
            .Take(filter.PerPage)
            .ToListAsync();

        return series;
    }
}
