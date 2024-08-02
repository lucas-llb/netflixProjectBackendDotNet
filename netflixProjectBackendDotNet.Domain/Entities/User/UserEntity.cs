using netflixProjectBackendDotNet.Domain.Constants;
using netflixProjectBackendDotNet.Domain.Entities.WatchTime;

namespace netflixProjectBackendDotNet.Domain.Entities.User;

public class UserEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
    public DateTime Birth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual IEnumerable<WatchTimeEntity> WatchTimes { get; set; }
}
