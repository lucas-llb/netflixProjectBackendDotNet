using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request.Likes;

public class CreateLikeRequest
{
    /// <summary>
    /// SerieId
    /// </summary>
    [Required]
    public int SerieId { get; set; }
}
