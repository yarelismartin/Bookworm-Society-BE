using Bookworm_Society_API.Data;
using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Helpers;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBaseRepository _baseRepository;

        public BookService(IBookRepository bookRepository, IBaseRepository baseRepository)
        {
            _bookRepository = bookRepository;
            _baseRepository = baseRepository;
        }
        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();

            return books.Select(book => new BookDTO(book)).ToList();
        }

        public async Task<PagedList<BookDTO>> GetPaginatedBooksAsync(int pageNumber, int pageSize)
        {
            var pagedBooks = await _bookRepository.GetPaginatedBooksAsync(pageNumber, pageSize);
            
            // Map the list of Books to BookDTOs
            var bookDTOs = pagedBooks.Items.Select(book => new BookDTO(book)).ToList();

            // Return a PagedList<BookDTO> with metadata and transformed items
            return new PagedList<BookDTO>(bookDTOs, pagedBooks.PageNumber, pagedBooks.PageSize, pagedBooks.TotalCount);
        }

        public async Task<Result<object>> GetSingleBookAsync(int bookId)
        {
            if(! await _baseRepository.BookExistsAsync(bookId))
            {
                return Result<object>.FailureResult($"No book was found with the following id: {bookId}", ErrorType.NotFound);
            }

            var book = await _bookRepository.GetSingleBookAsync(bookId);

            var bookObj = new
            {
                book.Id,
                book.Title,
                book.Description,
                Author = $"{book.Author.FirstName} {book.Author.LastName}",
                Genre = book.Genre.Name,
                book.ImageUrl,
                Reviews = book.Reviews?
                .OrderBy(r => r.CreatedDate)
                .Select(r => new {
                    r.Id,
                    r.Content,
                    r.CreatedDate,
                    r.Rating,
                    User = new UserDTO(r.User)
                }).ToList(),

            };

            return Result<object>.SuccessResult(bookObj);
        }
        public async Task<List<BookDTO?>> GetMostPopularBookAsync()
        {
            var books = await _bookRepository.GetMostPopularBookAsync();

            return books.Select(book => new BookDTO(book)).ToList();
        }
        /*public async Task<Result<List<BookDTO>>> SearchBooksAsync()
        {
            
        }*/
    }
}
