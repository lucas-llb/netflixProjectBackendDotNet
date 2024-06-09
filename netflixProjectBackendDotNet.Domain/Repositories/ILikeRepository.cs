using netflixProjectBackendDotNet.Domain.Entities.Like;

namespace netflixProjectBackendDotNet.Domain.Repositories;

public interface ILikeRepository
{
    Task<bool> IsLikedAsync(int userId, int serieId);
    Task<LikeEntity> CreateLikeAsync(int userId, int serieId);
    Task<bool> RemoveAsync(int userId, int serieId);
}
