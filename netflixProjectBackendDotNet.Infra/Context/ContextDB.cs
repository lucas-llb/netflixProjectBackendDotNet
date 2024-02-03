using Microsoft.EntityFrameworkCore;
using netflixProjectBackendDotNet.Domain.Entities.Category;
using netflixProjectBackendDotNet.Domain.Entities.Serie;

namespace netflixProjectBackendDotNet.Infra.Context;

public class ContextDB : DbContext
{
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<SerieEntity> Series { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextDB).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Default");
        }
    }
}
