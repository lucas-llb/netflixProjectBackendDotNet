using netflixProjectBackendDotNet.Domain.Entities.Like;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Likes;

public class LikeResponse
{
    public int UserId { get; set; }
    public int SerieId { get; set; }

    public static LikeResponse? ToResponse(LikeEntity entity) =>
    entity is null ?
    default :
    new LikeResponse
    {
        UserId = entity.UserId,
        SerieId = entity.SerieId,
    };
}
