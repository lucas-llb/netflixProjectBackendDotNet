using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request.Series;

public abstract class SerieRequestBase
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Synopsis { get; set; }
    [Required]
    public bool Featured { get; set; }
}
