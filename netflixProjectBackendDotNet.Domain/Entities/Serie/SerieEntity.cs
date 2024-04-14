using netflixProjectBackendDotNet.Domain.Entities.Category;

namespace netflixProjectBackendDotNet.Domain.Entities.Serie;

public class SerieEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Synopsis { get; set; }
    public string ThumbnailUrl { get; set; }
    public bool Featured { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; }
}
