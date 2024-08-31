using netflixProjectBackendDotNet.Api.Models.Responses.Series;
using netflixProjectBackendDotNet.Domain.Entities.Favorite;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Favorites;

public class FavoriteResponse
{
    public int UserId { get; set; }
    public IEnumerable<SerieCategoryResponse> Series {  get; set; }

    public static FavoriteResponse? ToResponse(IEnumerable<FavoriteEntity> entities) =>
        entities is null ?
        default :
        new FavoriteResponse
        {
            UserId = entities.First().UserId,
            Series = entities.Select(x =>
            {
                return new SerieCategoryResponse
                {
                    Id = x.Serie.Id,
                    Name = x.Serie.Name,
                    Synopsis = x.Serie.Synopsis,
                    ThumbnailUrl = x.Serie.ThumbnailUrl,
                };
            })
        };

}
