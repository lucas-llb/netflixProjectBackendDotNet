using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netflixProjectBackendDotNet.Domain.Repositories;
using netflixProjectBackendDotNet.Infra.Context;
using netflixProjectBackendDotNet.Infra.Repositories;

namespace netflixProjectBackendDotNet.Infra.Extensions;

public static class InfraExtension
{
    private const string ConnectionString = "Default";
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration) =>
        services
        .AddContext(configuration)
        .AddRepositories()
        .RunMigrations();

    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString);

        services.AddDbContext<ContextDB>(options => options.UseNpgsql(connectionString));
        return services;
    }

    private static IServiceCollection RunMigrations(this IServiceCollection services)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ContextDB>();
        //context.Database.Migrate();
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>()
            .AddScoped<ISerieRepository, SerieRepository>()
            .AddScoped<IEpisodeRepository, EpisodeRepository>()
            .AddScoped<IWatchTimeRepository, WatchTimeRepository>()
            .AddScoped<IFavoriteRepository, FavoriteRepository>()
            .AddScoped<ILikeRepository, LikeRepository>();
}
