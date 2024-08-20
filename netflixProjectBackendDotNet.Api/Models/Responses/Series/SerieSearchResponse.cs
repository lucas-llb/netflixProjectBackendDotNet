using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Series;

public class SerieSearchResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ThumbnailUrl { get; set; }

    public static IEnumerable<SerieSearchResponse> ToResponse(IEnumerable<SerieEntity> series)
    {
        if (series == null)
        {
            return default;
        }

        return series.Select(x =>
        {
            return new SerieSearchResponse
            {
                Id = x.Id,
                Name = x.Name,
                Synopsis = x.Synopsis,
                ThumbnailUrl = x.ThumbnailUrl,
            };
        });
    }
}
