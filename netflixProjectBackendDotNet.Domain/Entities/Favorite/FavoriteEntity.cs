using netflixProjectBackendDotNet.Domain.Entities.Serie;
using netflixProjectBackendDotNet.Domain.Entities.User;

namespace netflixProjectBackendDotNet.Domain.Entities.Favorite;

public class FavoriteEntity
{
    public int UserId { get; set; }
    public int SerieId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public UserEntity User { get; set; }
    public SerieEntity Serie { get; set; }
}
