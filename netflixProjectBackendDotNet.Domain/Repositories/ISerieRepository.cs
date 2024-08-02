using netflixProjectBackendDotNet.Domain.Entities.Serie;
using netflixProjectBackendDotNet.Domain.Filters;

namespace netflixProjectBackendDotNet.Domain.Repositories;

public interface ISerieRepository
{
    Task<IEnumerable<SerieEntity?>> GetTopTenNewestAsync();
    Task<IEnumerable<SerieEntity?>> GetRandomFeaturedSeriesAsync();
    Task<SerieEntity?> GetByIdWithEpisodesAsync(int id);
    Task<IEnumerable<SerieEntity>> FindByNameAsync(string name, PaginatedFilter filter);
    Task<SerieEntity> CreateAsync(SerieEntity entity);
    Task<SerieEntity?> UpdateAsync(SerieEntity serie);
    Task<IEnumerable<SerieEntity>> GetTopTenByLikesAsync();
}
