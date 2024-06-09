using netflixProjectBackendDotNet.Domain.Entities.WatchTime;

namespace netflixProjectBackendDotNet.Domain.Repositories;

public interface IWatchTimeRepository
{
    Task<WatchTimeEntity?> GetWatchTimeAsync(int userId, int episodeId);
    Task<WatchTimeEntity> SetWatchTimeAsync(int userId, int episodeId, int seconds);
}
