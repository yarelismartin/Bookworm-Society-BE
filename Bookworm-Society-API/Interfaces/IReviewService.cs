using Bookworm_Society_API.Data;
using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IReviewService

    {
        Task<Result<Review>> CreateReviewAsync(CreateReviewDTO reviewDTO);
        Task<Result<Review>> UpdateReviewAsync(Review review, int reviewId);
        Task<Result<Review>> DeleteReviewAsync(int reviewId);

    }
}
