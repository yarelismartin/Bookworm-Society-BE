﻿using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Bookworm_Society_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public UserRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            User user = await dbContext.Users
                .SingleOrDefaultAsync(u => u.Id == userId);
            
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<bool> UserUidAlreadyInUseAsync(string userUid)
        {
            return await dbContext.Users.AnyAsync(u => u.Uid == userUid);
        }
        public async Task<User> CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user, int userId)
        {
            var userToUpdate = await dbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Username = user.Username;
            userToUpdate.ImageUrl = user.ImageUrl;

            await dbContext.SaveChangesAsync();
            return userToUpdate;


        }
    }
}
