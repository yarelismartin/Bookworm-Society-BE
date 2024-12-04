using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Endpoints
{
    public static class VoteEndpoints
    {
        public static void MapVoteEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("votes").WithTags(nameof(Vote));

            group.MapPost("/", async (IVoteService voteService, CreateVoteDTO voteDTO) =>
            {
                var result = await voteService.CreateVote(voteDTO);

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
