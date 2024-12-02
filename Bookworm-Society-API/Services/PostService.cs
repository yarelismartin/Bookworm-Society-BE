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
        public async Task<Result<PostDetailDTO?>> GetPostByIdAsync(int postId)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);

            if (post == null)
            {
                return Result<PostDetailDTO?>.FailureResult($"No post was found with the following id: {postId}", ErrorType.NotFound);
            }

            return Result<PostDetailDTO>.SuccessResult(new PostDetailDTO(post));

        }
        //Create post
        public async Task<Result<PostDetailDTO>> CreatePostAsync(CreatePostDto postDto)
        {
            if (!await _baseRepository.UserExistsAsync(postDto.UserId))
            {
                return Result<PostDetailDTO>.FailureResult(
                    $"No user exists with the following ID: {postDto.UserId}",
                    ErrorType.NotFound
                );
            }
            if (!await _baseRepository.BookClubExistsAsync(postDto.BookClubId))
            {
                return Result<PostDetailDTO>.FailureResult(
                    $"No book club exists with the following ID: {postDto.BookClubId}",
                    ErrorType.NotFound
                );
            }
            if (!await _postRepository.IsUserAllowedToPost(postDto.BookClubId, postDto.UserId))
            {
                return Result<PostDetailDTO>.FailureResult(
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
            return Result<PostDetailDTO>.SuccessResult(new PostDetailDTO(newPost));
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
