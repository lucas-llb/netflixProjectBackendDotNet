﻿namespace netflixProjectBackendDotNet.Api.Models.Responses.Episodes;

public record EpisodeSerieResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Synopsis { get; set; }
    public int Order { get; set; }
    public string? VideoUrl { get; set; }
    public int SecondsLong { get; set; }
}
