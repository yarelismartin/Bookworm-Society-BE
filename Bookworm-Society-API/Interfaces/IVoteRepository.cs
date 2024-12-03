using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Interfaces
{
    public interface IVoteRepository
    {
        Task<Vote> CreateVote(Vote vote);
        Task<bool> VotingSessionExistsAsync(int votingSessionId);
        Task<VotingSession> GetSingleVotingSession(int votingSessionId);
    }
}
