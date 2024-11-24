using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IBookRepository

    {
        Task<Book> GetSingleBookAsync(int bookId);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetMostPopularBookAsync();
/*        Task<List<Book>> SearchBooksAsync();
*/    }
}
