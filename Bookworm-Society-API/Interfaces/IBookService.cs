using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Helpers;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IBookService

    {
        Task<Result<object>> GetSingleBookAsync(int bookId);
        Task<List<BookDTO>> GetAllBooksAsync();
        Task<List<BookDTO?>> GetMostPopularBookAsync();
        Task<PagedList<BookDTO>> GetPaginatedBooksAsync(int pageNumber, int pageSize);
/*        Task<Result<List<BookDTO>>> SearchBooksAsync();
*/    }
}
