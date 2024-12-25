using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IPostRepository

    {
        Task<Post?> GetPostByIdAsync(int  postId);
        Task<Post> CreatePostAsync(Post post);
        Task<Post> UpdatePostAsync(Post post, int postId);
        Task<Post> DeletePostAsync(int postId);
        Task<bool> IsUserAllowedToPost(int bookClubId, int userId);
        Task<bool> TogglePinPostAsync(int postId);
    }
}
