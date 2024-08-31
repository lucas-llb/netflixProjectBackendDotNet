using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Extensions;
using netflixProjectBackendDotNet.Api.Models.Request.Favorites;
using netflixProjectBackendDotNet.Api.Models.Responses.Favorites;
using netflixProjectBackendDotNet.Domain.Repositories;

namespace netflixProjectBackendDotNet.Api.Controllers;
[ApiController]
[Route("/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly IFavoriteRepository _favoriteRepository;

    public FavoritesController(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFavoriteAsync(CreateFavoriteRequest request)
    {
        var userId = HttpContext.GetUserId();

        if (userId is null)
        {
            return BadRequest("UserNotFound");
        }

        var result = await _favoriteRepository.CreateFavoriteAsync(userId.Value, request.SerieId);

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(FavoriteResponse), 200)]
    public async Task<IActionResult> GetFavoritesAsync()
    {
        var userId = HttpContext.GetUserId();
        if (userId is null)
        {
            return BadRequest("UserNotFound");
        }

        var result = await _favoriteRepository.GetFavoritesByUserIdAsync(userId.Value);

        return Ok(FavoriteResponse.ToResponse(result));
    }

    [HttpDelete("{serieId:int}")]
    public async Task<IActionResult> DeleteFavoriteAsync([FromRoute] int serieId)
    {
        var userId = HttpContext.GetUserId();
        if (userId is null)
        {
            return BadRequest("UserNotFound");
        }

        var result = await _favoriteRepository.RemoveFavoriteAsync(userId.Value, serieId);

        return result ?
            Ok() :
            BadRequest("Favorite Not Found");
    }
}
