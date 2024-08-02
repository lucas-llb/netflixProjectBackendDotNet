using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netflixProjectBackendDotNet.Domain.Services;
using netflixProjectBackendDotNet.Domain.Services.Impl;
using netflixProjectBackendDotNet.Infra.Extensions;

namespace netflixProjectBackendDotNet.IoC;

public static class IoC
{
    public static IServiceCollection SetProjectsConfig(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddInfra(configuration)
            .AddBusiness();

    private static IServiceCollection AddBusiness(this IServiceCollection services) =>
        services.AddScoped<IAuthService, AuthService>();
}
