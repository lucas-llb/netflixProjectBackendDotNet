using netflixProjectBackendDotNet.Domain.Entities.Episode;

namespace netflixProjectBackendDotNet.Domain.Repositories;

public interface IEpisodeRepository
{
    Task<EpisodeEntity> CreateAsync(EpisodeEntity episode);
    Task<EpisodeEntity?> UpdateAsync(EpisodeEntity episode);
}
