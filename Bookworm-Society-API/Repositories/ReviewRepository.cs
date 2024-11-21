using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;


namespace Bookworm_Society_API.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public readonly Bookworm_SocietyDbContext dbContext;

        public ReviewRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
