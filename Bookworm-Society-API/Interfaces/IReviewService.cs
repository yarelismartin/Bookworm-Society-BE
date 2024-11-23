using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IReviewService

    {
        Task<Result<Review>> CreateReviewAsync(Review review);
        Task<Result<Review>> UpdateReviewAsync(Review review, int reviewId);
        Task<Result<Review>> DeleteReviewAsync(int reviewId);

    }
}
