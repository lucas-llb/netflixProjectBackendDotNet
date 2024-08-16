using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflixProjectBackendDotNet.Domain.Dtos;

public class PaginatedDto<T>
{
    public IEnumerable<T> Items { get; set; }
    public int Page { get; set; }
    public int TotalItems { get; set; }
    public int PerPage { get; set; }
}
