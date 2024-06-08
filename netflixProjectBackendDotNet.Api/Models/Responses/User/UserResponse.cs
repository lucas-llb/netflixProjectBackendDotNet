using netflixProjectBackendDotNet.Domain.Entities.User;

namespace netflixProjectBackendDotNet.Api.Models.Responses.User;

public class UserResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Birth { get; set; }
    public string Email { get; set; }

    public static UserResponse? ToResponse(UserEntity user) =>
        user is null ?
        default :
        new UserResponse
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Birth = user.Birth.ToString(),
            Email = user.Email,
            Phone = user.Phone,
        };
}
