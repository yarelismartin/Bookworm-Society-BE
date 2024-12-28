using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Bookworm_Society_API.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public CommentRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }
        public async Task<Comment> DeleteCommentAsync(int commentId)
        {
            var commentToDelete = await dbContext.Comments.SingleOrDefaultAsync(c => c.Id == commentId);

            if (commentToDelete == null) 
            {
                return null;
            }

            dbContext.Comments.Remove(commentToDelete);
            await dbContext.SaveChangesAsync();
            return commentToDelete;
        }

        public async Task<bool> PostExistAsync(int postId)
        {
            return await dbContext.Posts.AnyAsync(p => p.Id == postId); 
        }
    }
}
