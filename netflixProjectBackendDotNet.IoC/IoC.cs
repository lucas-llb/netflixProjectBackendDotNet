using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netflixProjectBackendDotNet.Infra.Extensions;

namespace netflixProjectBackendDotNet.IoC;

public static class IoC
{
    public static IServiceCollection SetProjectsConfig(this IServiceCollection services, IConfiguration configuration) =>
        services.AddInfra(configuration);
}
