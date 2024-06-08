using netflixProjectBackendDotNet.Domain.Entities.User;

namespace netflixProjectBackendDotNet.Api.Models.Responses.User;

public class UpdateUserResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public DateTime Birth { get; set; }
    public string Email { get; set; }

    public static UpdateUserResponse? ToResponse(UserEntity entity) =>
        entity is null ?
        default :
        new UpdateUserResponse
        {
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Phone = entity.Phone,
            Birth = entity.Birth,
            Email = entity.Email,
        };
}
