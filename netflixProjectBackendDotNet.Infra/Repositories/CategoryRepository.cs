using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Dtos;
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

    public async Task<PaginatedDto<CategoryEntity>> GetPaginatedAsync(PaginatedFilter filter)
    {
        var data = await _dbSet
            .AsNoTracking()
            .OrderBy(x => x.Position)
            .Skip(filter.Page * filter.PerPage)
            .Take(filter.PerPage)
            .ToListAsync();

        var totalItems = await _dbSet.AsNoTracking().CountAsync();

        return new PaginatedDto<CategoryEntity>
        {
            Items = data,
            TotalItems = totalItems,
            Page = filter.Page,
            PerPage = filter.PerPage,
        };
    }

    public async Task<CategoryEntity?> GetById(int id)
    {
        return await _dbSet
            .Include(x => x.Series)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<CategoryEntity> CreateAsync(CategoryEntity category)
    {
        var entity = await _dbSet.AddAsync(category);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if(entity is not null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
