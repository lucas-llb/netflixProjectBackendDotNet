using netflixProjectBackendDotNet.IoC;

namespace netflixProjectBackendDotNet.Api.Extensions;

public static class ApiServicesExtension
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration) =>
        services.SetProjectsConfig(configuration);

}
