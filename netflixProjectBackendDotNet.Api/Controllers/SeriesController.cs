using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Extensions;
using netflixProjectBackendDotNet.Api.Models.Request;
using netflixProjectBackendDotNet.Api.Models.Request.Series;
using netflixProjectBackendDotNet.Api.Models.Responses.Series;
using netflixProjectBackendDotNet.Domain.Entities.Serie;
using netflixProjectBackendDotNet.Domain.Filters;
using netflixProjectBackendDotNet.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Controllers;
[ApiController]
[Route("/[controller]")]
public class SeriesController(ISerieRepository serieRepository, IWebHostEnvironment environment, IFavoriteRepository favoriteRepository, ILikeRepository likeRepository) : ControllerBase
{
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] CreateSerieRequest request,[FromForm][Required] IFormFile image)
    {
        if (image.FileName is null || image.Length == 0)
        {
            return BadRequest("Image not possible to be saved");
        }
        string path = await SaveImageAsync(request, image);
        var result = await serieRepository.CreateAsync(new SerieEntity
        {
            Name = request.Name,
            Synopsis = request.Synopsis,
            CategoryId = request.CategoryId,
            Featured = request.Featured,
            CreatedAt = DateTime.Now,
            ThumbnailUrl = path,
        });

        return result is not null ?
            Ok(result) :
            BadRequest("An error occurred during saving a serie");
    }

    [HttpPut("{serieId:int}")]
    [Authorize]
    public async Task<IActionResult> UpdateAsync([FromRoute]int serieId, [FromBody] UpdateSerieRequest request, [FromForm] IFormFile image)
    {
        if (image.FileName is null || image.Length == 0)
        {
            return BadRequest("Image not possible to be saved");
        }
        string path = await SaveImageAsync(request, image);

        var result = await serieRepository.UpdateAsync(new SerieEntity
        {
            Name = request.Name,
            Synopsis = request.Synopsis,
            ThumbnailUrl = path,
            Id = serieId,
        });


        return result is null ?
            Ok(result) :
            BadRequest("An error occurred during updating a serie");
    }

    [HttpGet("{serieId:int}")]
    [ProducesResponseType(typeof(SerieWithEpisodeResponse), 200)]
    [Authorize]
    public async Task<IActionResult> GetWithEpisodesAsync([FromRoute] int serieId)
    {
        var userId = HttpContext.GetUserId();
        var serie = await serieRepository.GetByIdWithEpisodesAsync(serieId);
        var liked = await likeRepository.IsLikedAsync(userId!.Value, serieId);
        var favorited = await favoriteRepository.IsFavoriteAsync(userId!.Value, serieId);


        return serie is not null ?
            Ok(SerieWithEpisodeResponse.ToResponse(serie, favorited, liked)) :
            BadRequest("Serie not found");
    }

    [HttpGet("featured")]
    [ProducesResponseType(typeof(IEnumerable<SerieFeaturedResponse>), 200)]
    [Authorize]
    public async Task<IActionResult> GetFeaturedSeriesAsync()
    {
        var serie = await serieRepository.GetRandomFeaturedSeriesAsync();

        return serie is not null ?
            Ok(SerieFeaturedResponse.ToResponse(serie)) :
            BadRequest("Series not found");
    }

    [HttpGet("newest")]
    [ProducesResponseType(typeof(SerieNewestResponse), 200)]

    public async Task<IActionResult> GetNewestSeriesAsync()
    {
        var serie = await serieRepository.GetTopTenNewestAsync();

        return serie is not null ?
            Ok(SerieNewestResponse.ToResponse(serie)) :
            BadRequest("Series not found");
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(SerieSearchResponse), 200)]

    [Authorize]
    public async Task<IActionResult> GetSeriesByNameAsync([FromQuery]string name, [FromQuery]PaginatedRequest paginatedRequest)
    {
        var serie = await serieRepository.FindByNameAsync(name, (PaginatedFilter)paginatedRequest);

        return Ok(SerieSearchResponse.ToResponse(serie));
    }

    [HttpGet("popular")]
    [ProducesResponseType(typeof(SerieTopTenLikeResponse), 200)]
    [Authorize]
    public async Task<IActionResult> GetTopTenSeriesByLikeAsync()
    {
        var serie = await serieRepository.GetTopTenByLikesAsync();

        return Ok(SerieTopTenLikeResponse.ToResponse(serie));
    }

    private async Task<string> SaveImageAsync(SerieRequestBase request, IFormFile image)
    {
        var path = Path.Combine(environment.WebRootPath, "thumbnails/", $"serie-{request.Name}/", image.FileName);

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            await image.CopyToAsync(stream);
            stream.Close();
        }

        return path;
    }
}
