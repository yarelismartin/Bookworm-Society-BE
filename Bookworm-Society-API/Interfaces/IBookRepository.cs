﻿using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Helpers;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IBookRepository

    {
        Task<Book> GetSingleBookAsync(int bookId);
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book?>> GetMostPopularBookAsync();
        Task<PagedList<Book>> GetPaginatedBooksAsync(int pageNumber, int pageSize);
/*        Task<List<Book>> SearchBooksAsync();
*/    }
}
