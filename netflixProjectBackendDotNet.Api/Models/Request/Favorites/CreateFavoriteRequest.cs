using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request.Favorites;

public class CreateFavoriteRequest
{
    /// <summary>
    /// SerieId
    /// </summary>
    [Required]
    public int SerieId { get; set; }
}
