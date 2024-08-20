using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Series;

public class SerieCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ThumbnailUrl { get; set; }
}
