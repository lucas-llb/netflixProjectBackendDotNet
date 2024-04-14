using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request;

public class PaginatedRequest : IValidatableObject
{
    public int PerPage { get; set; }
    public int Page { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if(PerPage < 1 || PerPage > 50)
        {
            yield return new ValidationResult("PerPage must be between 1 and 50");
        }

        if(Page < 0)
        {
            yield return new ValidationResult("Page must be greater than 0");
        }
    }
}
