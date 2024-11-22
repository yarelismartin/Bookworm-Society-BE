using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Repositories
{
    public class VotingSessionRepository : IVotingSessionRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public VotingSessionRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
