using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Favorite;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class FavoriteRepository : IFavoriteRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<FavoriteEntity> _dbSet;
    public FavoriteRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<FavoriteEntity>();
    }

    public async Task<FavoriteEntity> CreateFavoriteAsync(int userId, int serieId)
    {
        var favorite = await _dbSet.AddAsync(new FavoriteEntity
        {
            UserId = userId,
            SerieId = serieId,
            CreatedAt = DateTime.UtcNow
        });
        await _context.SaveChangesAsync();

        return favorite.Entity;
    }

    public async Task<bool> RemoveFavoriteAsync(int userId, int serieId)
    {
        var entity = await GetFavoriteAsync(userId, serieId);
        if(entity is not null)
        {
            var deleted = _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return deleted is not null;
        }

        return false;
    }

    public async Task<bool> IsFavoriteAsync(int userId, int serieId)
    {
        var entity = await GetFavoriteAsync(userId, serieId);

        return entity is not null;
    }

    public async Task<IEnumerable<FavoriteEntity>> GetFavoritesByUserIdAsync(int userId)
    {
        var favorites = await _dbSet.AsNoTracking()
            .Where(x => x.UserId == userId)
            .Include(x=> x.Serie)
            .ToListAsync();

        return favorites;
    }

    private async Task<FavoriteEntity?> GetFavoriteAsync(int userId, int serieId) => await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId && x.SerieId == serieId);
}
