﻿using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Entities.User;

namespace netflixProjectBackendDotNet.Domain.Entities.WatchTime;

public class WatchTimeEntity
{
    public int UserId { get; set; }
    public int EpisodeId { get; set; }
    public int SecondsLong { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public UserEntity User { get; set; }
    public EpisodeEntity Episode { get; set; }
}
