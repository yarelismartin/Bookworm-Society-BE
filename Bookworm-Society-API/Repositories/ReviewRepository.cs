using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;
using Microsoft.EntityFrameworkCore;


namespace Bookworm_Society_API.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public readonly Bookworm_SocietyDbContext dbContext;

        public ReviewRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            await dbContext.Reviews.AddAsync(review);
            await dbContext.SaveChangesAsync();
            return review;
        }
        public async Task<Review> UpdateReviewAsync(Review review, int reviewId)
        {
            var reviewToUpdate = await dbContext.Reviews.SingleOrDefaultAsync(r => r.Id == reviewId);

            if (reviewToUpdate == null)
            {
                return null;
            }


            reviewToUpdate.Content = review.Content;
            reviewToUpdate.Rating = review.Rating;

            return reviewToUpdate;

        }
        public async Task<Review> DeleteReviewAsync(int reviewId)
        {
            var reviewToDelete = await dbContext.Reviews.SingleOrDefaultAsync(r => r.Id == reviewId);

            if (reviewToDelete == null)
                return null;

            dbContext.Reviews.Remove(reviewToDelete);
            await dbContext.SaveChangesAsync();
            return reviewToDelete;
        }
    }
}
