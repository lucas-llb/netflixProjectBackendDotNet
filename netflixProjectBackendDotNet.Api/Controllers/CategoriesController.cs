using Microsoft.AspNetCore.Mvc;
using netflixProjectBackendDotNet.Api.Models.Request;
using netflixProjectBackendDotNet.Api.Models.Responses.Categories;
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
    [ProducesResponseType(typeof(CategoryPaginatedResponse), 200)]
    public async Task<IActionResult> GetPaginatedAsync([FromQuery] CategoriesPaginatedRequest request)
    {
        var result = await _categoryRepository.GetPaginatedAsync(request.ToFIlter());
        return Ok(CategoryPaginatedResponse.From(result));
    }

    [HttpGet("{categoryId:int}")]
    [ProducesResponseType(typeof(CategoryByIdWIthSeriesResponse), 200)]
    public async Task<IActionResult> GetById([FromRoute] int categoryId)
    {
        var result = await _categoryRepository.GetById(categoryId);
        return result is null ?
            BadRequest("Category not found") :
            Ok(CategoryByIdWIthSeriesResponse.ToResponse(result));
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryRequest request)
    {
        var result = await _categoryRepository.CreateAsync(request.Create());
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        var deleted = await _categoryRepository.DeleteAsync(id);
        return deleted ?
            Ok() :
            BadRequest("Category not found");
    }
}
