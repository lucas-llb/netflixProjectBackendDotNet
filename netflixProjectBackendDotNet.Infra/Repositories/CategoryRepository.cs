using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Category;
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
}
