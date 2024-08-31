using netflixProjectBackendDotNet.Domain.Filters;
using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request;

public class PaginatedRequest : IValidatableObject
{
    public int PerPage { get; set; } = 10;
    public int Page { get; set; } = 0;
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (PerPage < 0 || PerPage > 50)
        {
            yield return new ValidationResult("PerPage must be between 0 and 50");
        }

        if (Page < 0)
        {
            yield return new ValidationResult("Page must be greater than 0");
        }
    }

    public static explicit operator PaginatedFilter(PaginatedRequest request)
    {
        return new PaginatedFilter
        {
            Page = request.Page,
            PerPage = request.PerPage,
        };
    }
}
