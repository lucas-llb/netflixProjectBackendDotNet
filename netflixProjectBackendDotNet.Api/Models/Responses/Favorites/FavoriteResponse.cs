using netflixProjectBackendDotNet.Domain.Entities.Favorite;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Favorites;

public class FavoriteResponse
{
    public int UserId { get; set; }
    public int SerieId { get; set; }

    public static FavoriteResponse? ToResponse(FavoriteEntity entity) =>
        entity is null ?
        default :
        new FavoriteResponse
        {
            UserId = entity.UserId,
            SerieId = entity.SerieId,
        };

}
