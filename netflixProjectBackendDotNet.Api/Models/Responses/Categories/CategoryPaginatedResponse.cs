using netflixProjectBackendDotNet.Domain.Dtos;
using netflixProjectBackendDotNet.Domain.Entities.Category;
using System.Runtime.CompilerServices;

namespace netflixProjectBackendDotNet.Api.Models.Responses.Categories;

public class CategoryPaginatedResponse
{
    public int PerPage { get; set; }
    public int Total { get; set; }
    public int Page { get; set; }
    public IEnumerable<CategoryResponse> Categories { get; set; }
    public static CategoryPaginatedResponse From(PaginatedDto<CategoryEntity> categories)
    {
        if (categories == null)
        {
            return default;
        }

        return new CategoryPaginatedResponse
        {
            Categories = categories.Items.Select(x => (CategoryResponse)x),
            Total = categories.TotalItems,
            Page = categories.Page,
            PerPage = categories.PerPage,
        };
    }
}


