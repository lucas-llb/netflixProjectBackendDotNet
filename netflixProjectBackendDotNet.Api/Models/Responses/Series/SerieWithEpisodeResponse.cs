using netflixProjectBackendDotNet.Api.Models.Responses.Episodes;
using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Series;

internal class SerieWithEpisodeResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ThumbnailUrl { get; set; }
    public bool Favorited {  get; set; }
    public bool Liked { get; set; }

    public IEnumerable<EpisodeSerieResponse> Episodes { get; set; }

    public static SerieWithEpisodeResponse ToResponse(SerieEntity serie, bool favorited, bool liked)
    {
        if (serie == null)
        {
            return default;
        }

        return new SerieWithEpisodeResponse
        {
            Id = serie.Id,
            Name = serie.Name,
            Synopsis = serie.Synopsis,
            ThumbnailUrl = serie.ThumbnailUrl,
            Liked = liked,
            Favorited = favorited,
            Episodes = serie.Episodes.Select(x =>
            {
                return new EpisodeSerieResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Synopsis = x.Synopsis,
                    Order = x.Order,
                    SecondsLong = x.SecondsLong,
                    VideoUrl = x.VideoUrl,
                };
            }),
        };
    }
}
