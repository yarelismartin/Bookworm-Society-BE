using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public VoteRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
