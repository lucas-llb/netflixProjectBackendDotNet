using System.Security.Claims;

namespace netflixProjectBackendDotNet.Api.Extensions;

public static class HttpContextExtensions
{
    public static int? GetUserId(this HttpContext context)
    {
        var id = context.User.FindFirstValue(ClaimTypes.Sid);
        return id is null ?
            null :
            int.Parse(id);
    }
}
