using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<Comment> DeleteCommentAsync(int commentId);
        Task<bool> PostExistAsync(int postId);
    }
}
