namespace netflixProjectBackendDotNet.Api.Models.Request.Episodes;

public abstract class EpisodeRequestBase
{
    public string? Name { get; set; }
    public string? Synopsis { get; set; }
    public int Order { get; set; }
    public int SecondsLong { get; set; }
    public int SerieId { get; set; }
}
