using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IPostService

    {
        //Get single post
        Task<Result<object?>> GetPostByIdAsync(int postId);
        //Create post
        Task<Result<Post>> CreatePostAsync(Post post);
        //Update post 
        Task<Result<Post>> UpdatePostAsync(Post post, int postId);
        //Delete post
        Task<Result<Post>> DeletePostAsync(int postId);
    }
}
