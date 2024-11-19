using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}
