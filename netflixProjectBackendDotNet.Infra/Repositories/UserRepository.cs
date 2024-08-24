using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Entities.User;
using netflixProjectBackendDotNet.Domain.Entities.WatchTime;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;
using BC = BCrypt.Net.BCrypt;


namespace netflixProjectBackendDotNet.Infra.Repositories;

internal class UserRepository : IUserRepository
{
    private const int HashFactor = 12;
    private readonly ContextDB _context;
    private readonly DbSet<UserEntity> _dbSet;
    public UserRepository(ContextDB context)
    {
        _context = context;
        _dbSet = context.Set<UserEntity>();
    }

    public async Task<UserEntity?> RegisterAsync(UserEntity newUser)
    {
        var actualUser = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == newUser.Email);

        if (actualUser is null)
        {
            newUser.Password = BC.HashPassword(newUser.Password, HashFactor);
            var entity = await _dbSet.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        return null;
    }

    public async Task<UserEntity?> GetByEmailAsync(string email) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

    public async Task<bool> CheckPasswordAsync(int id, string password)
    {
        var userPassword = await _dbSet.AsNoTracking().Where(x => x.Id == id).Select(x => x.Password).FirstOrDefaultAsync();
        if (userPassword is null)
        {
            return false;
        }

        return CheckPassword(userPassword, password);
    }

    public async Task<bool> LoginAsync(string email,  string password)
    {
        var user = await GetByEmailAsync(email);
        if (user is null)
        {
            return false;
        }

        return CheckPassword(password, user.Password);
    }


    public async Task<UserEntity?> UpdateAsync(UserEntity newUser)
    {
        var user = await GetByIdAsync(newUser.Id);
        if (user is null)
        {
            return null;
        }

        user.Phone = newUser.Phone;
        user.Email = newUser.Email;
        user.FirstName = newUser.FirstName;
        user.LastName = newUser.LastName;
        user.Birth = newUser.Birth;

        var entryEntity = _dbSet.Update(user);
        await _context.SaveChangesAsync();

        return entryEntity.Entity;
    }

    public async Task<UserEntity?> UpdatePasswordAsync(int id, string password)
    {
        var user = await GetByIdAsync(id);
        if (user is null)
        {
            return null;
        }

        user.Password = BC.HashPassword(password, HashFactor);

        var entryEntity = _dbSet.Update(user);
        await _context.SaveChangesAsync();

        return entryEntity.Entity;
    }

    public async Task<IEnumerable<EpisodeEntity>?> GetUserWithWatchListAsync(int id)
    {
        var data =  await _dbSet.AsNoTracking()
            .Include(x => x.WatchTimes)
                .ThenInclude(x => x.Episode)
                .ThenInclude(x => x.Serie)
            .Include(x => x.WatchTimes)
                .ThenInclude(x => x.Episode)
                .ThenInclude(x => x.WatchTime)
            .FirstOrDefaultAsync(x => x.Id == id);

        var episodes = data!.WatchTimes.Select(x => x.Episode);

        return FilterLastEpisodesBySerie(episodes.OrderByDescending(x => x.WatchTime.UpdatedAt));
    }

    private async Task<UserEntity?> GetByIdAsync(int id) => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    private static bool CheckPassword(string currentPassword, string password)
    {
        var passwordMatch = BC.Verify(currentPassword, password);

        if (passwordMatch)
        {
            return true;
        }

        return false;
    }

    public IEnumerable<EpisodeEntity> FilterLastEpisodesBySerie(IEnumerable<EpisodeEntity>? episodes)
    {
        var seriesOnList = new HashSet<int>();
        var lastEpisodes = new List<EpisodeEntity>();

        foreach (var episode in episodes)
        {
            if (!seriesOnList.Contains(episode.SerieId))
            {
                seriesOnList.Add(episode.SerieId);
                lastEpisodes.Add(episode);
                continue;
            }

            var episodeFromSameSerie = lastEpisodes.FirstOrDefault(ep => ep.SerieId == episode.SerieId);
            if (episodeFromSameSerie != null && episodeFromSameSerie.Order > episode.Order)
            {
                continue;
            }

            lastEpisodes = lastEpisodes.Where(ep => ep.SerieId != episode.SerieId).ToList();
            lastEpisodes.Add(episode);
        }

        return lastEpisodes;
    }
}
