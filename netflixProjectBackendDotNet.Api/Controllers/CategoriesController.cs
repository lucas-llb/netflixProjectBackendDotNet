using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Models.Request;
using netflixProjectBackendDotNet.Domain.Repositories;

namespace netflixProjectBackendDotNet.Api.Controllers;
[ApiController]
[Route("/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("index")]
    public async Task<IActionResult> GetPaginatedAsync([FromQuery] CategoriesPaginatedRequest request)
    {
        var result = await _categoryRepository.GetPaginatedAsync(request.ToFIlter());
        return Ok(result);
    }

    [HttpGet("show")]
    public async Task<IActionResult> GetById([FromQuery] int categoryId)
    {
        var result = await _categoryRepository.GetById(categoryId);
        return result is null ?
            BadRequest("Category not found") :
            Ok(result);
    }
}
