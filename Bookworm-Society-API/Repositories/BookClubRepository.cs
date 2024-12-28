using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


namespace Bookworm_Society_API.Repositories
{
    public class BookClubRepository : IBookClubRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public BookClubRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }

        public async Task<List<BookClub>> GetBookClubsAsync()
        {
            return await dbContext.BookClubs
                .OrderByDescending(bc => bc.Members.Count())
                .ToListAsync();
        }

        public async Task<BookClub?> GetBookClubByIdAsync(int bookClubId)
        {
            var bookClub =  await dbContext.BookClubs
                .Include(bc => bc.Host)
                .Include(bc => bc.Book)
                .Include(bc => bc.Members)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);
           
            return bookClub;
         }

        public async Task<BookClub> CreateBookClubAsync(BookClub bookClub)
            {
                await dbContext.BookClubs.AddAsync(bookClub);
                await dbContext.SaveChangesAsync();
                return bookClub;
            }

        public async Task<BookClub> UpdateBookClubAsync(BookClub bookClub, int bookClubId)
        {
            var bookClubToUpdate = await dbContext.BookClubs
                .Include(bc => bc.Members)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);

            if (bookClubToUpdate == null)
            {
                return null;
            }

            bookClubToUpdate.Name = bookClub.Name;
            bookClubToUpdate.MeetUpType = bookClub.MeetUpType;
            bookClubToUpdate.Description = bookClub.Description;
            bookClubToUpdate.ImageUrl = bookClub.ImageUrl;
           

            if (bookClubToUpdate.HostId != bookClub.HostId)
            {
                var newHost = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == bookClub.HostId);
                bookClubToUpdate.Members?.Remove(newHost);
            }

            bookClubToUpdate.HostId = bookClub.HostId;
            await dbContext.SaveChangesAsync();
            return bookClubToUpdate;
        }
        public async Task<BookClub> DeleteBookClubAsync(int bookClubId)
            {
                var bookClubToDelete = await dbContext.BookClubs.SingleOrDefaultAsync(bc => bc.Id == bookClubId);

                if (bookClubToDelete == null)
                {
                    return null;
                }

                dbContext.BookClubs.Remove(bookClubToDelete);

                await dbContext.SaveChangesAsync();
                return bookClubToDelete;
            }

        public async Task<BookClub> GetABookClubHaveReadAsync(int bookClubId)
        {
            var bookClub = await dbContext.BookClubs
                .Include(bc => bc.HaveRead)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);

            return bookClub;
        }
        public async Task<BookClub> GetABookClubPostsAsync(int bookClubId)
        {
            var bookClub = await dbContext.BookClubs
                .Include(bc => bc.Posts)
                .ThenInclude(p => p.User)
                .Include(bc => bc.Posts)
                .ThenInclude(p => p.Comments)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);

            if (bookClub == null)
            {
                return null;
            }

            bookClub.Posts = bookClub.Posts?
                .OrderByDescending(post => post.IsPinned)
                .ThenByDescending(post => post.CreatedDate)
                .ToList();

            return bookClub;
        }

        public async Task<BookClub?> GetBookClubWithMembersAsync(int bookClubId)
        {
            return await dbContext.BookClubs
                .Include(bc => bc.Members)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);
        }

        public async Task<BookClub> AddUserToBookClubAsync( BookClub bookClub, int userId)
        {
            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Id  == userId);

            bookClub.Members?.Add(user);   
            await dbContext.SaveChangesAsync();

            return bookClub;

        }
        public async Task<BookClub> RemoveUserFromBookClubAsync(BookClub bookClub, int userId)
        {
            var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

            bookClub.Members?.Remove(user);
            await dbContext.SaveChangesAsync();

            return bookClub;
        }

    }
}
