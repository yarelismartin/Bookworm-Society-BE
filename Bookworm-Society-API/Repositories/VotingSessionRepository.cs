using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Repositories
{
    public class VotingSessionService : IVotingSessionRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public VotingSessionService(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
