﻿using Bookworm_Society_API.Data;
using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;
using Bookworm_Society_API.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace Bookworm_Society_API.Services
{
    public class VotingSessionService : IVotingSessionService
    {
        private readonly IVotingSessionRepository _votingSessionRepository;
        private readonly IBaseRepository _baseRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public VotingSessionService(IVotingSessionRepository votingSessionRepository, IBaseRepository baseRepository, IHubContext<NotificationHub> hubContext)
        {
            _votingSessionRepository = votingSessionRepository;
            _baseRepository = baseRepository;
            _hubContext = hubContext;

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
                    Author = $"{vb.Author.FirstName} {vb.Author.LastName}",
                    Genre = vb.Genre.Name,
                    vb.ImageUrl,
                    TotalVotes = votingsession.Votes?.Count(v => v.BookId == vb.Id)
                }),

            };

            return Result<object?>.SuccessResult(latestVotingSession);
        }
        public async Task<Result<VotingSession>> CreateVotingSession(CreateVotingSessionDTO votingSessionDTO, int userId)
        {
            BookClub bookClub = await _baseRepository.GetSingleBookClubAsync(votingSessionDTO.BookClubId);

            if (bookClub == null)
            {
                return Result<VotingSession>.FailureResult($"No book club was found with the following id: {votingSessionDTO.BookClubId}", ErrorType.NotFound);
            }

            if (bookClub.HostId != userId)
            {
                return Result<VotingSession>.FailureResult($"Only the host can create a voting session. You are not authorized to perform this action", ErrorType.Conflict);
            }

            int daysApart = (votingSessionDTO.VotingEndDate - DateTime.Now).Days;
            if (daysApart > 4 )
            {
                return Result<VotingSession>.FailureResult($"The voting session duration cannot exceed 4 days. Please choose an earlier end date.", ErrorType.Conflict);
            }

            if (votingSessionDTO.BookIds.Count <= 1  )
            {
                return Result<VotingSession>.FailureResult($"You must select at least two books to be voted on. You currently only selected: {votingSessionDTO.BookIds.Count}", ErrorType.Conflict);
            }

            var existingBooks = await _votingSessionRepository.GetBooksByIdsAsync(votingSessionDTO.BookIds);

            if (existingBooks.Count != votingSessionDTO.BookIds.Count)
            {
                // Except method is used to find the difference between two collections. It returns the elements that are in the first collection but not in the second.
                var missingBookIds = votingSessionDTO.BookIds.Except(existingBooks.Select(b => b.Id)).ToList();
                return Result<VotingSession>.FailureResult($"The following books do not exist: {string.Join(", ", missingBookIds)}", ErrorType.NotFound);
            }

            VotingSession votingSession = new()
            {
                BookClubId = votingSessionDTO.BookClubId,
                VotingEndDate = votingSessionDTO.VotingEndDate,
                IsActive = true,
                VotingBooks = existingBooks
            };

            var createdVotginSession = await _votingSessionRepository.CreateVotingSession(votingSession);
            await _hubContext.Clients.Group(votingSessionDTO.BookClubId.ToString())
    .SendAsync("ReceivedMessage", $"Voting session has started for book club {votingSessionDTO.BookClubId}!");

            return Result<VotingSession>.SuccessResult(votingSession);


        }

        public async Task CheckAndUpdateVotingSessionAsync(CancellationToken cancellationToken)
        {
            
            var activeSessions = await _votingSessionRepository.GetActiveVotingSessions(cancellationToken);

            foreach (var session in activeSessions)
            {
                if(session.VotingEndDate <= DateTime.Now)
                {
                    await _votingSessionRepository.FinalizeVotingSessionAsync(session.Id, cancellationToken);

                }
            }

        }
    }
}
