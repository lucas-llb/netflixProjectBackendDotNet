using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Like;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class LikeRepository : ILikeRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<LikeEntity> _dbSet;
    public LikeRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<LikeEntity>();
    }

    public async Task<LikeEntity> CreateLikeAsync(int userId, int serieId)
    {
        var like = await _dbSet.AddAsync(new LikeEntity
        {
            UserId = userId,
            SerieId = serieId,
            CreatedAt = DateTime.UtcNow,
        });
        await _context.SaveChangesAsync();

        return like.Entity;
    }

    public async Task<bool> IsLikedAsync(int userId, int serieId)
    {
        var like = await GetLikeAsync(userId, serieId);

        return like is not null;
    }

    public async Task<bool> RemoveAsync(int userId, int serieId)
    {
        var actualLike = await GetLikeAsync(userId, serieId);
        if(actualLike is not null)
        {
            var deleted = _dbSet.Remove(actualLike);
            await _context.SaveChangesAsync();

            return deleted is not null;
        }

        return false;
    }

    private async Task<LikeEntity?> GetLikeAsync(int userId, int serieId) =>
        await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId && x.SerieId == serieId);
}
