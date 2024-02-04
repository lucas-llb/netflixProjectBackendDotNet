using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netflixProjectBackendDotNet.Infra.Context;

namespace netflixProjectBackendDotNet.Infra.Extensions;

public static class InfraExtension
{
    private const string ConnectionString = "Default";
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration) =>
        services
        .AddContext(configuration)
        .AddRepositories();

    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString);

        services.AddDbContext<ContextDB>(options => options.UseNpgsql(connectionString));
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services;
}
