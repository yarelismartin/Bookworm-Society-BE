using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Interfaces
{
    public interface IPostRepository

    {
        Task<Post?> GetPostByIdAsync(int  postId);
        Task<Post> CreatePostAsync(Post post);
        Task<Post> UpdatePostAsync(Post post, int postId);
        Task<Post> DeletePostAsync(int postId);
    }
}
