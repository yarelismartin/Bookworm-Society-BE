using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Services
{
    public class VotingSessionService : IVotingSessionService
    {
        private readonly IVotingSessionRepository _votingSessionRepository;
        private readonly IBaseRepository _baseRepository;

        public VotingSessionService(IVotingSessionRepository votingSessionRepository, IBaseRepository baseRepository)
        {
            _votingSessionRepository = votingSessionRepository;
            _baseRepository = baseRepository;
        }

        public async Task<Result<VotingSession?>> GetLatestVotingSessionAsync(int bookClubId, int userId)
        {
            if (!await _baseRepository.UserExistsAsync(userId))
            {
                return Result<VotingSession>.FailureResult($"Not user was found with the following id: {userId}", ErrorType.NotFound);
            }

            if (!await _baseRepository.BookClubExistsAsync(bookClubId))
            {
                return Result<VotingSession>.FailureResult($"Not book club was found with the following id: {bookClubId}", ErrorType.NotFound);
            }

            var votingsession = await _votingSessionRepository.GetLatestVotingSessionAsync(bookClubId, userId);

            // this should be a different like .NoContent
            if (votingsession == null)
            {
                return Result<VotingSession?>.SuccessResult(null, "No active voting session");
            }

            if (votingsession.Votes.Any(v => v.UserId == userId))
            {
                return Result<VotingSession?>.SuccessResult( null,"You have already voted in this voting session");
            }

            return Result<VotingSession>.SuccessResult(votingsession);
        }
        public async Task<Result<VotingSession>> CreateVotingSession(int userId, int bookClubId, List<int> bookIds)
        {
            throw new NotImplementedException();
        }
    }
}
