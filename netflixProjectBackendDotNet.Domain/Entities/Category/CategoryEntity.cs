using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Domain.Entities.Category;

public class CategoryEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
    public virtual IEnumerable<SerieEntity> Series { get; set; }
}
