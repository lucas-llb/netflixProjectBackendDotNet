using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.WatchTime;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class WatchTimeRepository : IWatchTimeRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<WatchTimeEntity> _dbSet;
    public WatchTimeRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<WatchTimeEntity>();
    }

    public async Task<WatchTimeEntity?> GetWatchTimeAsync(int userId, int episodeId)
    {
        var watchTime = await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId && x.EpisodeId == episodeId);

        return watchTime;
    }

    public async Task<WatchTimeEntity> SetWatchTimeAsync(int userId, int episodeId, int seconds)
    {
        var watchTimeActual = await GetWatchTimeAsync(userId, episodeId);

        if(watchTimeActual is not null)
        {
            watchTimeActual.SecondsLong = seconds;
            watchTimeActual.UpdatedAt = DateTime.UtcNow;
            var entityEntrie = _dbSet.Update(watchTimeActual);
            await _context.SaveChangesAsync();
            return entityEntrie.Entity;
        }
        else
        {
            var watchTime = await _dbSet.AddAsync(new WatchTimeEntity
            {
                UserId = userId,
                EpisodeId = episodeId,
                SecondsLong = seconds,
                CreatedAt = DateTime.UtcNow,
            });

            await _context.SaveChangesAsync();
            return watchTime.Entity;
        }
    } 
}
