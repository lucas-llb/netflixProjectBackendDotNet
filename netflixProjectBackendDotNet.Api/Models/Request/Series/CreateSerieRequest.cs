using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request.Series;

public class CreateSerieRequest : SerieRequestBase
{
    [Required]
    public int CategoryId { get; set; }
}
