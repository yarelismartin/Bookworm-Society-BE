using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;


namespace Bookworm_Society_API.Repositories
{
    public class ReviewService : IReviewRepository
    {
        public readonly Bookworm_SocietyDbContext dbContext;

        public ReviewService(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
