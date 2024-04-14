using netflixProjectBackendDotNet.Domain.Entities.User;
using BC = BCrypt.Net.BCrypt;

namespace netflixProjectBackendDotNet.Infra.Context.SeedData;

internal static class UserSeedData
{
    public static List<UserEntity> UserData = new List<UserEntity>
    {
        new UserEntity
        {
            Id = 1,
            FirstName = "Admin",
            LastName = "User",
            Phone = "(31) 99999-9999",
            Birth = DateTime.Parse("01-01-1991").ToUniversalTime(),
            Email = "admin@email.com",
            Role = Domain.Constants.RoleEnum.Admin,
            Password = BC.HashPassword("123456", 12),
            CreatedAt = DateTime.UtcNow,
        }
    };
}
