using netflixProjectBackendDotNet.Domain.Entities.WatchTime;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Episodes;

public class EpisodeWatchTimeResponse
{
    public int Seconds { get; set; }

    public static EpisodeWatchTimeResponse ToResponse(WatchTimeEntity episodeWatchTime)
    {
        if(episodeWatchTime == null)
        {
            return default;
        }

        return new()
        {
            Seconds = episodeWatchTime.SecondsLong,
        };
    }
}
