using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IBookService

    {
        Task<Result<object>> GetSingleBookAsync(int bookId);
        Task<List<BookDTO>> GetAllBooksAsync();
        Task<BookDTO?> GetMostPopularBookAsync();
        Task<List<BookDTO>> GetPaginatedBooksAsync(int pageNumber, int pageSize);
/*        Task<Result<List<BookDTO>>> SearchBooksAsync();
*/    }
}
