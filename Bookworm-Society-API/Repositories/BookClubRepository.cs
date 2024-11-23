﻿using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;


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
            return await dbContext.BookClubs
                .Include(bc => bc.Host)
                .Include(bc => bc.Book)
                .Include(bc => bc.Members)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);
         }

        public async Task<BookClub> CreateBookClubAsync(BookClub bookClub)
            {
                await dbContext.BookClubs.AddAsync(bookClub);
                await dbContext.SaveChangesAsync();
                return bookClub;
            }

        public async Task<BookClub> UpdateBookClubAsync(BookClub bookClub, int bookClubId)
        {
            var bookClubToUpdate = await dbContext.BookClubs.SingleOrDefaultAsync(bc => bc.Id == bookClubId);

            if (bookClubToUpdate == null)
            {
                return null;
            }

            bookClubToUpdate.Name = bookClub.Name;
            bookClubToUpdate.MeetUpType = bookClub.MeetUpType;
            bookClubToUpdate.Description = bookClub.Description;
            bookClubToUpdate.ImageUrl = bookClub.ImageUrl;
            bookClubToUpdate.HostId = bookClub.HostId;
            bookClubToUpdate.BookId = bookClub.BookId;

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

    }
}
