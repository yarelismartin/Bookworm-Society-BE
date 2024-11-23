using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;
        public PostRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            var post = await dbContext.Posts
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .Include(p => p.User)
                .SingleOrDefaultAsync(p => p.Id == postId);
            if (post == null)
            {
                return null;
            }
            return post;
        }
        public async Task<Post> CreatePostAsync(Post post)
        {
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return post;
        }
        public async Task<Post> UpdatePostAsync(Post post, int postId)
        {
            var postToUpdate = await dbContext.Posts.SingleOrDefaultAsync(p => p.Id == postId);
            if (postToUpdate == null)
            {
                return null;
            }

            postToUpdate.Content = post.Content;
            postToUpdate.IsEdited = true;

            dbContext.SaveChangesAsync();

            return postToUpdate;
        }
        public async Task<Post> DeletePostAsync(int postId)
        {
            var postToDelete = await dbContext.Posts.SingleOrDefaultAsync(p => p.Id == postId);
            
            if (postToDelete == null)
            {
                return null;
            }

            dbContext.Posts.Remove(postToDelete);

            await dbContext.SaveChangesAsync();
            return postToDelete;
        }

        public async Task<bool> IsUserAllowedToPost(int bookClubId, int  userId)
        {
            var bookClub = await dbContext.BookClubs
                .Include(bc => bc.Members)
                .Include(bc => bc.Host)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);

            bool isHost = bookClub.Host.Id == userId;
            bool isMember = bookClub.Members?.Any(m => m.Id == userId) == true;

            return isHost || isMember;
        }

    }
}
