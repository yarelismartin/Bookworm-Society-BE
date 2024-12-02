using Bookworm_Society_API.Data;
using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Repositories;
using Bookworm_Society_API.Result;


namespace Bookworm_Society_API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IBaseRepository _baseRepository;

        public ReviewService(IReviewRepository reviewRepository, IBaseRepository baseRepository)
        {
            _reviewRepository = reviewRepository;
            _baseRepository = baseRepository;
        }

        public async Task<Result<Review>> CreateReviewAsync(CreateReviewDTO reviewDTO)
        {
            if (!await _baseRepository.UserExistsAsync(reviewDTO.UserId))
            {
                return Result<Review>.FailureResult($"No user was found with the following id: {reviewDTO.UserId}", ErrorType.NotFound);
            }
            if (!await _baseRepository.BookExistsAsync(reviewDTO.BookId))
            {
                return Result<Review>.FailureResult($"No book was found with the following id: {reviewDTO.BookId}", ErrorType.NotFound);
            }
            if(reviewDTO.Rating < 1 || reviewDTO.Rating > 5)
            {
                return Result<Review>.FailureResult($"The rating should be between 1 and 5.", ErrorType.Conflict);
            }

            Review reviewObj = new()
            {
                Content = reviewDTO.Content,
                Rating = reviewDTO.Rating,
                UserId = reviewDTO.UserId,
                BookId = reviewDTO.BookId
            };

            var newReview = await _reviewRepository.CreateReviewAsync(reviewObj);
            return Result<Review>.SuccessResult(newReview);
        }
        public async Task<Result<Review>> UpdateReviewAsync(Review review, int reviewId)
        {
            var reviewToUpdate = await _reviewRepository.UpdateReviewAsync(review, reviewId);

            if (reviewToUpdate == null) 
            {
                return Result<Review>.FailureResult($"No review found with the following id: {reviewId}", ErrorType.NotFound);
            };
            if (review.Rating <= 0 || review.Rating > 5)
            {
                return Result<Review>.FailureResult($"The rating should be between 1 and 5.", ErrorType.Conflict);
            }

            return Result<Review>.SuccessResult(reviewToUpdate);
        }
        public async Task<Result<Review>> DeleteReviewAsync(int reviewId)
        {
            var reviewToDelete = await _reviewRepository.DeleteReviewAsync(reviewId);

            if (reviewToDelete == null)
            {
                return Result<Review>.FailureResult($"No review found with the following id: {reviewId}", ErrorType.NotFound);
            }

            return Result<Review>.SuccessResult(null);

        }
    }
}
