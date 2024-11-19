using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Repositories
{
    public class VoteService : IVoteRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public VoteService(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
