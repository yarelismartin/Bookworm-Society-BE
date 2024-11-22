using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public BaseRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }

        public async Task<bool> UserExistsAsync(int userId)
        {
            return await dbContext.Users.AnyAsync(u => u.Id == userId);
        }
        public async Task<bool> BookExistsAsync(int bookId)
        {
            return await dbContext.Books.AnyAsync(u => u.Id == bookId);
        }

        public async Task<BookClub?> GetSingleBookClubAsync(int bookClubId)
        {
            return await dbContext.BookClubs.SingleOrDefaultAsync(bc => bc.Id == bookClubId);
        }
    }
}
