using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> CreateReviewAsync(Review review);
        Task<Review> UpdateReviewAsync(Review review, int reviewId);
        Task<Review> DeleteReviewAsync(int  reviewId);   
    }
}
