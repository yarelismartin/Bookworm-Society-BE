using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public BookRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
