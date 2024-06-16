using Application.Common.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Extensions
{
    public static class PaginationExtension
    {
        public static Task<PaginatedList<IDestination>> PaginatedListAsync<IDestination>(this IQueryable<IDestination> queryable, int pageNumber, int pageSize)
            => PaginatedList<IDestination>.CreateAsync(queryable, pageNumber, pageSize);
    }
}
