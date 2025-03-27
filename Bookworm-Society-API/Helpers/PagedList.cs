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

        // Asynchronous version for production (EF or other async operations)
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int pageNumber, int pageSize)
            {
                // Get the total count of items in the query asynchronously
                var totalCount = await query.CountAsync();

                // Fetch the paginated slice of data asynchronously (using Skip and Take)
                var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

                // Return a new PagedList instance with the fetched data and pagination metadata
                return new PagedList<T>(items, pageNumber, pageSize, totalCount);
            }

        // Synchronous version for unit testing (using in-memory collections)
        public static PagedList<T> Create(List<T> items, int pageNumber, int pageSize)
            {
                var totalCount = items.Count; // Using Count() for in-memory collections

                // Fetch the paginated slice of data (using Skip and Take)
                var paginatedItems = items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                // Return a new PagedList instance with the fetched data and pagination metadata
                return new PagedList<T>(paginatedItems, pageNumber, pageSize, totalCount);
            }
    }
}
