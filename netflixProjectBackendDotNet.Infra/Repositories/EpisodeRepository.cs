using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class EpisodeRepository : IEpisodeRepository
{
    private readonly ContextDB _context;
    private readonly DbSet<EpisodeEntity> _dbSet;
    public EpisodeRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<EpisodeEntity>();
    }

    public async Task<EpisodeEntity> CreateAsync(EpisodeEntity episode)
    {
        var created = await _dbSet.AddAsync(episode);

        await _context.SaveChangesAsync();

        return created.Entity;
    }

    public async Task<EpisodeEntity?> UpdateAsync(EpisodeEntity episode)
    {
        var actualEpisode = await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == episode.Id);

        if(actualEpisode is not null)
        {
            actualEpisode.Order = episode.Order;
            actualEpisode.SerieId = episode.SerieId;
            actualEpisode.Synopsis = episode.Synopsis;
            actualEpisode.Name = episode.Name;
            actualEpisode.VideoUrl = episode.VideoUrl;
            actualEpisode.ThumbnailUrl = episode.ThumbnailUrl;
            actualEpisode.UpdateAt = DateTime.Now;
            actualEpisode.SecondsLong = episode.SecondsLong;

            var updated = _dbSet.Update(actualEpisode);
            await _context.SaveChangesAsync();

            return updated.Entity;
        }

        return null;
    }
}
