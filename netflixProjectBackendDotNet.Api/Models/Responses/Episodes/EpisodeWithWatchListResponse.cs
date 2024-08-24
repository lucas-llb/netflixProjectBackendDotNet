using netflixProjectBackendDotNet.Api.Models.Responses.Series;
using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Entities.WatchTime;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Episodes;

public class EpisodeWithWatchListResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public int Order { get; set; }
    public string VideoUrl { get; set; }
    public string ThumbnailUrl { get; set; }
    public int SecondsLong { get; set; }
    public int SerieId { get; set; }
    public SerieFeaturedResponse Serie { get; set; }

    public WatchTimeEntity WatchTime { get; set; }

    public static IEnumerable<EpisodeWithWatchListResponse> ToResponse(IEnumerable<EpisodeEntity> episodes)
    {
        if (episodes is null)
        {
            return default;
        }

        return episodes.Select(x =>
        {
            return new EpisodeWithWatchListResponse
            {
                Id = x.Id,
                Name = x.Name,
                Synopsis = x.Synopsis,
                Order = x.Order,
                VideoUrl = x.VideoUrl,
                ThumbnailUrl = x.ThumbnailUrl,
                SecondsLong = x.SecondsLong,
                SerieId = x.SerieId,
                WatchTime = x.WatchTime,
                Serie = new SerieFeaturedResponse
                {
                    Id = x.Serie.Id,
                    Name = x.Serie.Name,
                    Synopsis = x.Serie.Synopsis,
                    ThumbnailUrl = x.Serie.ThumbnailUrl,
                }
            };
        });
    }
}
