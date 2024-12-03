using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Endpoints
{
    public static class VotingSessionEndpoints
    {
        public static void MapVotingSessionEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("votingsessions").WithTags(nameof(VotingSession));

            group.MapGet("/bookclubs/{bookClubId}", async (IVotingSessionService votingSessionService, int bookClubId, int userId) =>
            {
                var result = await votingSessionService.GetLatestVotingSessionAsync(bookClubId, userId);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }

                if (result.ErrorType == ErrorType.Conflict)
                {
                    return Results.Conflict(result.Message);
                }

                if (result.Data == null)
                {
                    return Results.Ok(result.Message);
                }

                return Results.Ok(result.Data);
            });

            group.MapPost("/", async (IVotingSessionService votingSessionService, CreateVotingSessionDTO votingSessionDTO, int userId) =>
            {
                var result = await votingSessionService.CreateVotingSession(votingSessionDTO, userId);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }

                if (result.ErrorType == ErrorType.Conflict)
                {
                    return Results.Conflict(result.Message);
                }

                return Results.Ok(result.Data);
            });
        }
    }
}
