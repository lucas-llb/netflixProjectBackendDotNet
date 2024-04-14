using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Category;
using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Entities.Favorite;
using netflixProjectBackendDotNet.Domain.Entities.Like;
using netflixProjectBackendDotNet.Domain.Entities.Serie;
using netflixProjectBackendDotNet.Domain.Entities.User;
using netflixProjectBackendDotNet.Domain.Entities.WatchTime;
using netflixProjectBackendDotNet.Infra.Context.SeedData;

namespace netflixProjectBackendDotNet.Infra.Context;

public class ContextDB(DbContextOptions<ContextDB> options) : DbContext(options)
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<SerieEntity> Series { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<EpisodeEntity> Episodes { get; set; }
    public DbSet<WatchTimeEntity> WatchTimes { get; set; }
    public DbSet<FavoriteEntity> Favorites { get; set; }
    public DbSet<LikeEntity> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextDB).Assembly);

        modelBuilder.Entity<CategoryEntity>().HasData(CategorySeedData.CategoryData);
        modelBuilder.Entity<UserEntity>().HasData(UserSeedData.UserData);
        modelBuilder.Entity<SerieEntity>().HasData(SerieSeedData.SerieData);
        base.OnModelCreating(modelBuilder);
    }
}
