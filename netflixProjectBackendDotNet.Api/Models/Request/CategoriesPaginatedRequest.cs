using netflixProjectBackendDotNet.Domain.Filters;

namespace netflixProjectBackendDotNet.Api.Models.Request
{
    public class CategoriesPaginatedRequest : PaginatedRequest
    {

        public PaginatedFilter ToFIlter() =>
            new PaginatedFilter
            {
                Page = Page,
                PerPage = PerPage,
            };
    }
}
