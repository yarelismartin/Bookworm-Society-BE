using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Repositories;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBaseRepository _baseRepository;

        public CommentService(ICommentRepository commentRepository, IBaseRepository baseRepository)
        {
            _commentRepository = commentRepository;
            _baseRepository = baseRepository;
        }

        public async Task<Result<Comment>> CreateCommentAsync(Comment comment)
        {
            if (!await _baseRepository.UserExistsAsync(comment.UserId))
            {
                return Result<Comment>.FailureResult($"No user was found with the following id: {comment.UserId}", ErrorType.NotFound);
            }
            if (!await _commentRepository.PostExistAsync(comment.PostId))
            {
                return Result<Comment>.FailureResult($"No post was found with the following id: {comment.PostId}", ErrorType.NotFound);
            }

            Comment commentObj = new()
            {
                Content = comment.Content,
                PostId = comment.PostId,
                UserId = comment.UserId
            };

            var newComment = await _commentRepository.CreateCommentAsync(commentObj);

            return Result<Comment>.SuccessResult(newComment);

        }
        public async Task<Result<Comment>> DeleteCommentAsync(int commentId)
        {
            var commentToDelete = await _commentRepository.DeleteCommentAsync(commentId);

            if ( commentToDelete == null)
            {
                return Result<Comment>.FailureResult($"No comemnt was found with the following id: {commentId}", ErrorType.NotFound);
            }

            return Result<Comment>.SuccessResult(null);  

        }
    }
}
