using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Extensions;
using netflixProjectBackendDotNet.Api.Models.Request.Likes;
using netflixProjectBackendDotNet.Api.Models.Responses.Likes;
using netflixProjectBackendDotNet.Domain.Repositories;

namespace netflixProjectBackendDotNet.Api.Controllers;
[ApiController]
[Route("/[controller]")]
public class LikesController : ControllerBase
{
    private readonly ILikeRepository _likeRepository;

    public LikesController(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLikeAsync(CreateLikeRequest request)
    {
        var userId = HttpContext.GetUserId();

        if (userId is null)
        {
            return BadRequest("UserNotFound");
        }

        var result = await _likeRepository.CreateLikeAsync(userId.Value, request.SerieId);

        return Ok(LikeResponse.ToResponse(result));
    }

    [HttpDelete("{serieId:int}")]
    public async Task<IActionResult> DeleteFavoriteAsync([FromRoute] int serieId)
    {
        var userId = HttpContext.GetUserId();
        if (userId is null)
        {
            return BadRequest("UserNotFound");
        }

        var result = await _likeRepository.RemoveAsync(userId.Value, serieId);

        return result ?
            Ok() :
            BadRequest("Favorite Not Found");
    }

}
