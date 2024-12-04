using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IVotingSessionRepository
    {
        Task<VotingSession> GetLatestVotingSessionAsync(int bookClubId, int userId);
        Task<bool> IsUserAllowedToVote(int bookClubId, int userId);
        Task<VotingSession> CreateVotingSession(VotingSession votingSession);

        Task<List<Book>> GetBooksByIdsAsync(List<int> bookIds);
        Task<List<VotingSession>> GetActiveVotingSessions(CancellationToken cancellationToken);
        Task<int> CalculateWinningBook(List<Vote> votes);

        Task FinalizeVotingSessionAsync(int votingSessionId, CancellationToken cancellationToken);
    }
}
