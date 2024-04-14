namespace netflixProjectBackendDotNet.Domain.Filters;

public record PaginatedFilter
{
    public int PerPage { get; init; }
    public int Page { get; init; }
}
