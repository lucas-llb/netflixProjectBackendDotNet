using netflixProjectBackendDotNet.Domain.Entities.Category;
using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Categories;

public class CategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Position { get; set; }
    public virtual IEnumerable<SerieEntity> Series { get; set; }

    public static implicit operator CategoryResponse(CategoryEntity category)
    {
        if(category is null ){
            return default;
        }

        return new CategoryResponse 
        {
            Id = category.Id,
            Name = category.Name,
            Position = category.Position,
            Series = category.Series,
        };
    }
}
