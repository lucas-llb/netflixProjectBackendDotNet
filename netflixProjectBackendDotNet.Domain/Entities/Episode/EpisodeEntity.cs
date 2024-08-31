using netflixProjectBackendDotNet.Domain.Entities.Serie;
using netflixProjectBackendDotNet.Domain.Entities.WatchTime;
using System.ComponentModel.DataAnnotations.Schema;

namespace netflixProjectBackendDotNet.Domain.Entities.Episode;

public class EpisodeEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public int Order { get; set; }
    public string VideoUrl { get; set; }
    public string ThumbnailUrl { get; set; }
    public int SecondsLong { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public int SerieId { get; set; }
    public SerieEntity Serie { get; set; }
    [NotMapped]
    public virtual WatchTimeEntity WatchTime { get; set; }
}
