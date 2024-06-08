using netflixProjectBackendDotNet.Domain.Entities.Category;
using netflixProjectBackendDotNet.Domain.Filters;

namespace netflixProjectBackendDotNet.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryEntity>> GetPaginatedAsync(PaginatedFilter filter);
    Task<CategoryEntity?> GetById(int id);
    Task<CategoryEntity> CreateAsync(CategoryEntity category);
    Task<bool> DeleteAsync(int id);
}
