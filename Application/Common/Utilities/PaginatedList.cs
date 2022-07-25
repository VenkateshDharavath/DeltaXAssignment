using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utilities
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            Items = items;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public bool HasPreviousPage => PageNumber > 0;

        public bool HasNextpage => PageNumber < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
