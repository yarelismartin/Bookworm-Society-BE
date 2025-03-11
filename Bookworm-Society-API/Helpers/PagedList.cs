using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Helpers
{
    public class PagedList<T>
    {
        public PagedList(List<T> items, int pageNumber, int pageSize, int totalCount)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public List<T> Items { get; set; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public bool HasNextPage => PageNumber * PageSize < TotalCount;
        public bool HasPreviousPage => PageNumber > 1;

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int pageNumber, int pageSize)
        {
            // 1. Get the total count of items in the query
            var totalCount = await query.CountAsync();

            // 2. Fetch the paginated slice of data (using Skip and Take)
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            // 3. Return a new PagedList instance with the fetched data and pagination metadata
            return new(items, pageNumber, pageSize, totalCount);
        }
    }
}
