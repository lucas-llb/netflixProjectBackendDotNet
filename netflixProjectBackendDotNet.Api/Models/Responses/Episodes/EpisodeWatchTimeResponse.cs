using netflixProjectBackendDotNet.Domain.Entities.WatchTime;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Episodes;

public class EpisodeWatchTimeResponse
{
    public int Seconds { get; set; }

    public static EpisodeWatchTimeResponse ToResponse(WatchTimeEntity episodeWatchTime)
    {
        if(episodeWatchTime == null)
        {
            return new()
            {
                Seconds = 0,
            };
        }

        return new()
        {
            Seconds = episodeWatchTime.SecondsLong,
        };
    }
}
