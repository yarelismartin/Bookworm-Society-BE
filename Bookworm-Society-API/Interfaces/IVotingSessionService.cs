using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IVotingSessionService
    {
        Task<Result<object?>> GetLatestVotingSessionAsync(int bookClubId, int userId);
        Task<Result<VotingSession>> CreateVotingSession(int userId, int bookClubId, List<int> bookIds);

    }
}
