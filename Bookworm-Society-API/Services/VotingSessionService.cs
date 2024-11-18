using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Services
{
    public class VotingSessionService : IVotingSessionService
    {
        private readonly IVotingSessionRepository _votingSessionRepository;

        public VotingSessionService(IVotingSessionRepository votingSessionRepository)
        {
            _votingSessionRepository = votingSessionRepository;
        }
    }
}
