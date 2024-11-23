using Bookworm_Society_API.Data;
using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IBaseRepository _baseRepository;

        public PostService(IPostRepository postRepository, IBaseRepository baseRepository)
        {
            _postRepository = postRepository;
            _baseRepository = baseRepository;
        }

        //Get single post
        public async Task<Result<object?>> GetPostByIdAsync(int postId)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);

            if (post == null)
            {
                return Result<object>.FailureResult($"No post was found with the following id: {postId}", ErrorType.NotFound);
            }

            var postObj = new
            {
                post.Id,
                post.Content,
                post.CreatedDate,
                post.IsPinned,
                post.IsEdited,
                User = new UserDTO(post.User),
                Comments = post.Comments?
                .OrderBy(c => c.CreatedDate)
                .Select(c => new
                {
                    c.Id,
                    c.Content,
                    c.CreatedDate,
                    User = new UserDTO(c.User),
                })
            };


            return Result<object>.SuccessResult(postObj);

        }
        //Create post
        public async Task<Result<Post>> CreatePostAsync(Post post)
        {
            if(!await _baseRepository.UserExistsAsync(post.UserId))
            {
                return Result<Post>.FailureResult($"No user exist with the following id: {post.UserId}", ErrorType.NotFound);
            }
            if (!await _baseRepository.BookClubExistsAsync(post.BookClubId))
            {
                return Result<Post>.FailureResult($"No book club exist with the following id: {post.BookClubId}", ErrorType.NotFound);
            }

            Post postObj = new()
            {
                Content = post.Content,
                IsPinned = false,
                IsEdited = false,
                BookClubId = post.BookClubId,
                UserId = post.UserId
            };

            var newPost = await _postRepository.CreatePostAsync(postObj);
            return Result<Post>.SuccessResult(newPost);
        }
        //Update post 
        public async Task<Result<Post>> UpdatePostAsync(Post post, int postId)
        {
           /* if (!await _baseRepository.UserExistsAsync(post.UserId))
            {
                return Result<Post>.FailureResult($"No user exist with the following id: {post.UserId}", ErrorType.NotFound);
            }

            if (!await _baseRepository.BookClubExistsAsync(post.BookClubId))
            {
                return Result<Post>.FailureResult($"No book club exist with the following id: {post.BookClubId}", ErrorType.NotFound);
            }*/

            var postToUpdate = await _postRepository.UpdatePostAsync(post, postId);

            if (postToUpdate == null)
            {
                return Result<Post>.FailureResult($"No post was found with the following id: {postId}", ErrorType.NotFound);
            }

            return Result<Post>.SuccessResult(postToUpdate);
        }
        //Delete post
        public async Task<Result<Post>> DeletePostAsync(int postId)
        {
            var postToDelete = await _postRepository.DeletePostAsync(postId);

            if (postToDelete == null)
            {
                return Result<Post>.FailureResult($"No post was found with the following id: {postId}", ErrorType.NotFound);
            }

            return Result<Post>.SuccessResult(postToDelete);
        }
    }
}
