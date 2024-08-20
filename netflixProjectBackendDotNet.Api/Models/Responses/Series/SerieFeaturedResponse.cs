using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Series;

public record SerieFeaturedResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ThumbnailUrl { get; set; }

    public static IEnumerable<SerieFeaturedResponse> ToResponse(IEnumerable<SerieEntity> series)
    {
        if (series == null)
        {
            return default;
        }

        return series.Select(x =>
        {
            return new SerieFeaturedResponse
            {
                Id = x.Id,
                Name = x.Name,
                Synopsis = x.Synopsis,
                ThumbnailUrl = x.ThumbnailUrl,
            };
        });
    }
}
