using netflixProjectBackendDotNet.Api.Models.Responses.Series;
using netflixProjectBackendDotNet.Domain.Entities.Category;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Categories;

public class CategoryByIdWIthSeriesResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<SerieCategoryResponse> Series { get; set; }

    public static CategoryByIdWIthSeriesResponse ToResponse(CategoryEntity category)
    {
        if (category is null)
        {
            return default;
        }

        return new()
        {
            Id = category.Id,
            Name = category.Name,
            Series = category.Series.Select(x => new SerieCategoryResponse
            {
                Id = x.Id,
                Name = x.Name,
                Synopsis = x.Synopsis,
                ThumbnailUrl = x.ThumbnailUrl,
            })
        };
    }
}
