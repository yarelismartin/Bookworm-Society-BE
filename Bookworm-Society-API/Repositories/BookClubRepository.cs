using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Repositories
{
    public class BookClubService : IBookClubRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public BookClubService(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
