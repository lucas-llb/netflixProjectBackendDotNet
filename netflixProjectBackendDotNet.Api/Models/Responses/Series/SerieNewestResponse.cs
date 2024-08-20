using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Series;

public class SerieNewestResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ThumbnailUrl { get; set; }
    public bool Featured { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int CategoryId { get; set; }
    public virtual IEnumerable<EpisodeEntity> Episodes { get; set; }

    public static IEnumerable<SerieNewestResponse> ToResponse(IEnumerable<SerieEntity> series)
    {
        if(series is null)
        {
            return default;
        }

        return series.Select(x => new SerieNewestResponse
        {
            Id = x.Id,
            Name = x.Name,
            Synopsis = x.Synopsis,
            ThumbnailUrl = x.ThumbnailUrl,
            Featured = x.Featured,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
            CategoryId = x.CategoryId,
            Episodes = x.Episodes,
        });
    }
}
