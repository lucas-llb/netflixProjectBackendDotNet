using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Category;
using netflixProjectBackendDotNet.Domain.Filters;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class CategoryRepository : ICategoryRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<CategoryEntity> _dbSet;
    public CategoryRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<CategoryEntity>();
    }

    public async Task<IEnumerable<CategoryEntity>> GetPaginatedAsync(PaginatedFilter filter)
    {
        return await _dbSet
            .AsNoTracking()
            .Skip(filter.Page * filter.PerPage)
            .Take(filter.PerPage)
            .ToListAsync();
    }

    public async Task<CategoryEntity?> GetById(int id)
    {
        return await _dbSet
            .AsNoTracking().Include(x => x.Series)
            .FirstOrDefaultAsync(x => x.Id == id);
    } 
}
