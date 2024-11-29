using Bookworm_Society_API.Data;
using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Repositories;
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
        public async Task<Result<Post>> CreatePostAsync(CreatePostDto postDto)
        {
            if (!await _baseRepository.UserExistsAsync(postDto.UserId))
            {
                return Result<Post>.FailureResult(
                    $"No user exists with the following ID: {postDto.UserId}",
                    ErrorType.NotFound
                );
            }
            if (!await _baseRepository.BookClubExistsAsync(postDto.BookClubId))
            {
                return Result<Post>.FailureResult(
                    $"No book club exists with the following ID: {postDto.BookClubId}",
                    ErrorType.NotFound
                );
            }
            if (!await _postRepository.IsUserAllowedToPost(postDto.BookClubId, postDto.UserId))
            {
                return Result<Post>.FailureResult(
                    "User is not a member or host of this book club.",
                    ErrorType.Conflict
                );
            }

            Post post = new()
            {
                Content = postDto.Content,
                IsPinned = false, 
                IsEdited = false, 
                BookClubId = postDto.BookClubId,
                UserId = postDto.UserId
            };

            var newPost = await _postRepository.CreatePostAsync(post);
            return Result<Post>.SuccessResult(newPost);
        }
        //Update post 
        public async Task<Result<Post>> UpdatePostAsync(Post post, int postId)
        {

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

            return Result<Post>.SuccessResult(null);
        }
    }
}
