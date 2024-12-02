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

        public async Task<Result<object?>> GetLatestVotingSessionAsync(int bookClubId, int userId)
        {
            if (!await _baseRepository.UserExistsAsync(userId))
            {
                return Result<object?>.FailureResult($"Not user was found with the following id: {userId}", ErrorType.NotFound);
            }

            if (!await _baseRepository.BookClubExistsAsync(bookClubId))
            {
                return Result<object?>.FailureResult($"Not book club was found with the following id: {bookClubId}", ErrorType.NotFound);
            }

            if (!await _votingSessionRepository.IsUserAllowedToVote(bookClubId, userId))
            {
                return Result<object?>.FailureResult("This user is not a member of host therefor they can not view or vote in this voting session.", ErrorType.Conflict);
            }

            var votingsession = await _votingSessionRepository.GetLatestVotingSessionAsync(bookClubId, userId);

            // this should be a different like .NoContent
            if (votingsession == null)
            {
                return Result<object?>.SuccessResult(null, "No active voting session");
            }


            var latestVotingSession = new
            {
                votingsession.Id,
                votingsession.IsActive,
                votingsession.VotingStartDate,
                votingsession.VotingEndDate,
                HasUserVoted = votingsession.Votes?.Any(v => v.UserId == userId),
                VotingBooks = votingsession.VotingBooks
                .Select(vb => new
                {
                    vb.Id,
                    vb.Title,
                    vb.Description,
                    vb.Author,
                    vb.Genre,
                    vb.ImageUrl,
                    TotalVotes = votingsession.Votes?.Count(v => v.BookId == vb.Id)
                }),

            };

            return Result<object?>.SuccessResult(latestVotingSession);
        }
        public async Task<Result<VotingSession>> CreateVotingSession(int userId, int bookClubId, List<int> bookIds)
        {
            throw new NotImplementedException();
        }
    }
}
