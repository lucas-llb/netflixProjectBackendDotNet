using netflixProjectBackendDotNet.Domain.Entities.Category;
using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request;

public class CreateCategoryRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int Position { get; set; }

    public CategoryEntity Create() =>
        new CategoryEntity
        {
            Name = Name,
            Position = Position,
        };
}
