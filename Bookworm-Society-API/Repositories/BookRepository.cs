using Bookworm_Society_API.Data;
using Bookworm_Society_API.Helpers;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace Bookworm_Society_API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public BookRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await dbContext.Books
                .Include(b => b.Author)
                .ToListAsync();
        }

        public async Task<PagedList<Book>> GetPaginatedBooksAsync(int pageNumber, int pageSize)
        {
            var bookResponses = dbContext.Books
                .Include(b => b.Author);

            var books = await PagedList<Book>.CreateAsync(bookResponses, pageNumber, pageSize);

            return books;
        }

        public async Task<Book> GetSingleBookAsync(int bookId)
        {
            var book = await dbContext.Books
                .Include(b => b.Reviews)
                .ThenInclude(r => r.User)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .SingleOrDefaultAsync(b => b.Id == bookId);


            return book;

        }
        public async Task<List<Book?>> GetMostPopularBookAsync()
        {
            return await dbContext.Books
                .Include(b => b.Reviews)
                .Include(b => b.Author)
                .Where(b => b.Reviews.Any() && b.Reviews.Average(r => r.Rating) >= 4.0)
                .OrderByDescending(b => b.Reviews.Average(r => r.Rating))
                .Take(10)
                .ToListAsync(); 
        }
        /*public async Task<List<Book>> SearchBooksAsync()
        {

        }*/
    }
}
