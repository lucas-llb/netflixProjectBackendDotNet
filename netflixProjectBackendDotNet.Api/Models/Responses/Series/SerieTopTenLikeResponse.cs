using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Series;

public class SerieTopTenLikeResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ThumbnailUrl { get; set; }
    public int Likes { get; set; }

    public static IEnumerable<SerieTopTenLikeResponse> ToResponse(IEnumerable<SerieEntity> series)
    {
        if (series is null)
        {
            return default;
        }

        return series.Select(x => new SerieTopTenLikeResponse
        {
            Id = x.Id,
            Name = x.Name,
            Synopsis = x.Synopsis,
            ThumbnailUrl = x.ThumbnailUrl,
        });
    }
}
