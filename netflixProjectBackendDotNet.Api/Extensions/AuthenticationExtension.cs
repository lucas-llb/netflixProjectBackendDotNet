using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace netflixProjectBackendDotNet.Api.Extensions;

public static class AuthenticationExtension
{
    public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        return services;
    }
}
