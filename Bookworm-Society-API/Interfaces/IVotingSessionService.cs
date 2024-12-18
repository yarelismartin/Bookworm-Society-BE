﻿using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IVotingSessionService
    {
        Task<Result<object?>> GetLatestVotingSessionAsync(int bookClubId, int userId);
        Task<Result<VotingSession>> CreateVotingSession(CreateVotingSessionDTO votingSessionDTO, int userId);
        Task CheckAndUpdateVotingSessionAsync(CancellationToken cancellationToken);
    }
}
