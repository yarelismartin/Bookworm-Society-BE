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
            return await dbContext.BookClubs.ToListAsync();
        }

        public async Task<BookClub?> GetBookClubByIdAsync(int bookClubId)
        {
            return await dbContext.BookClubs
                .Include(bc => bc.Host)
                .Include(bc => bc.Book)
                .Include(bc => bc.Members)
                .Include(bc => bc.HaveRead)
                // I'm not include post here because i think this would be too much data being returned
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
                throw new NotImplementedException();
            }

    }
}
