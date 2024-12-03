using Bookworm_Society_API.Data;
using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IBaseRepository _baseRepository;

        public VoteService(IVoteRepository voteRepository, IBaseRepository baseRepository)
        {
            _voteRepository = voteRepository;
            _baseRepository = baseRepository;
        }

        public async Task<Result<object>> CreateVote(CreateVoteDTO voteDTO)
        {
          if(!await _baseRepository.UserExistsAsync(voteDTO.UserId))
            {
                return Result<object>.FailureResult($"No user was found with the following id: {voteDTO.UserId}", ErrorType.NotFound);

            }

            if (!await _baseRepository.BookExistsAsync(voteDTO.BookId))
            {
                return Result<object>.FailureResult($"No book was found with the following id: {voteDTO.BookId}", ErrorType.NotFound);
            }

            var votingSession = await _voteRepository.GetSingleVotingSession(voteDTO.VotingSessionId);

            if (votingSession == null) 
            { 
              return Result<object>.FailureResult($"No voting session was found with the following id: {voteDTO.VotingSessionId}", ErrorType.NotFound);
            }
            
            if (votingSession.Votes.Any(v => v.UserId == voteDTO.UserId))
            {
                return Result<object>.FailureResult($"The user with an id of {voteDTO.UserId} has already voted in this voting session", ErrorType.Conflict);
            }

            if (!votingSession.VotingBooks.Any(vb => vb.Id == voteDTO.BookId))
            {
                return Result<object>.FailureResult($"The book with id {voteDTO.BookId} is not part of the current voting session.", ErrorType.Conflict);
            }

            Vote newVote = new()
            {
                UserId = voteDTO.UserId,
                BookId = voteDTO.BookId,
                VotingSessionId = voteDTO.VotingSessionId,
            };

            var createdVote = await _voteRepository.CreateVote(newVote);

            var voteObject = new
            {
                createdVote.Id,
                createdVote.UserId,
                createdVote.BookId,
                createdVote.VotingSessionId,

            };

            return Result<object>.SuccessResult(voteObject);
        }


    }
}
