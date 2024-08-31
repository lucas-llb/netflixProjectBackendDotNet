using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Extensions;
using netflixProjectBackendDotNet.Api.Models.Request.Episodes;
using netflixProjectBackendDotNet.Api.Models.Responses.Episodes;
using netflixProjectBackendDotNet.Domain.Entities.Episode;
using netflixProjectBackendDotNet.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Controllers;
[ApiController]
[Route("/[controller]")]
public class EpisodesController(IWatchTimeRepository watchTimeRepository, IEpisodeRepository episodeRepository, IWebHostEnvironment environment) : ControllerBase
{
    private IWebHostEnvironment _env = environment;
    [HttpPost("{id:int}/watchtime")]
    [Authorize]
    public async Task<IActionResult> SetWatchTimeAsync([FromRoute] int id, [FromBody] int seconds)
    {
        var userId = HttpContext.GetUserId();

        if (userId is null)
        {
            return BadRequest("UserNotFound");
        }

        var result = await watchTimeRepository.SetWatchTimeAsync(userId.Value, id, seconds);

        return result is null ?
            BadRequest("Episode not found") :
            Ok(result);
    }

    [HttpGet("{id:int}/watchtime")]
    [ProducesResponseType(typeof(EpisodeWatchTimeResponse), 200)]
    [Authorize]
    public async Task<IActionResult> GetWatchTimeAsync([FromRoute] int id)
    {
        var userId = HttpContext.GetUserId();

        if (userId is null)
        {
            return BadRequest("UserNotFound");
        }

        var result = await watchTimeRepository.GetWatchTimeAsync(userId.Value, id);

        return Ok(EpisodeWatchTimeResponse.ToResponse(result));
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] CreateEpisodeRequest request, [FromForm][Required] IFormFile video)
    {
        if (video.FileName is null || video.Length == 0)
        {
            return BadRequest("Video not possible to be saved");
        }
        string path = await SaveVideoAsync(request, video);
        var result = await episodeRepository.CreateAsync(new EpisodeEntity
        {
            Name = request.Name,
            Order = request.Order,
            Synopsis = request.Synopsis,
            CreatedAt = DateTime.Now,
            SecondsLong = request.SecondsLong,
            SerieId = request.SerieId,
            VideoUrl = path,
        });

        return result is not null ?
            Ok(result) :
            BadRequest("An error occurred during saving an episode");
    }

    [HttpPut("{episodeId:int}")]
    [Authorize]
    public async Task<IActionResult> UpdateAsync([FromRoute] int episodeId, [FromBody] UpdateEpisodeRequest request, [FromForm][Required] IFormFile video)
    {
        if (video.FileName is null || video.Length == 0)
        {
            return BadRequest("Video not possible to be saved");
        }
        string path = await SaveVideoAsync(request, video);
        var result = await episodeRepository.UpdateAsync(new EpisodeEntity
        {
            Id = episodeId,
            Name = request.Name,
            Order = request.Order,
            Synopsis = request.Synopsis,
            SecondsLong = request.SecondsLong,
            SerieId = request.SerieId,
            VideoUrl = path,
        });

        return result is not null ?
            Ok(result) :
            BadRequest("An error occurred during updating an episode");
    }

    [HttpGet("stream")]
    public async Task<IActionResult> StreamEpisodeToResponse([FromQuery] string videoUrl, [FromHeader] string range)
    {
        var webRootPath = _env.WebRootPath.Replace("\\", "/");
        var filePath = webRootPath+ videoUrl;
        var fileInfo = new FileInfo(filePath);

        if (!fileInfo.Exists)
        {
            return NotFound();
        }

        var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        var fileLength = fileInfo.Length;

        if (!string.IsNullOrEmpty(range))
        {
            var rangeParts = range.Replace("bytes=", "").Split('-');
            var start = long.Parse(rangeParts[0]);

            var end = !string.IsNullOrWhiteSpace(rangeParts[1]) ? long.Parse(rangeParts[1]) : fileLength - 1;
            var chunkSize = end - start + 1;

            Response.Headers.Add("Content-Range", $"bytes {start}-{end}/{fileLength}");
            Response.Headers.Add("Accept-Ranges", "bytes");
            Response.Headers.Add("Content-Length", chunkSize.ToString());
            Response.Headers.Add("Content-Type", "video/mp4");

            fileStream.Seek(start, SeekOrigin.Begin);
            return File(fileStream, "video/mp4", enableRangeProcessing: true);
        }
        else
        {
            Response.Headers.Add("Content-Length", fileLength.ToString());
            Response.Headers.Add("Content-Type", "video/mp4");

            return File(fileStream, "video/mp4");
        }
    }

    private async Task<string> SaveVideoAsync(EpisodeRequestBase request, IFormFile video)
    {
        var path = Path.Combine(_env.WebRootPath, "videos/", $"serie-{request.SerieId}/", video.FileName);

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            await video.CopyToAsync(stream);
            stream.Close();
        }

        return path;
    }
}
