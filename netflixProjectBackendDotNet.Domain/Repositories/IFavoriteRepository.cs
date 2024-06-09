using netflixProjectBackendDotNet.Domain.Entities.Favorite;

namespace netflixProjectBackendDotNet.Domain.Repositories;

public interface IFavoriteRepository
{
    Task<FavoriteEntity> CreateFavoriteAsync(int userId, int serieId);
    Task<bool> RemoveFavoriteAsync(int userId, int serieId);
    Task<bool> IsFavoriteAsync(int userId, int serieId);
    Task<IEnumerable<FavoriteEntity>> GetFavoritesByUserIdAsync(int userId);
}
