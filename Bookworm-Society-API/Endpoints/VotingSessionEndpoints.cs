using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Endpoints
{
    public static class VotingSessionEndpoints
    {
        public static void MapVotingSessionEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(VotingSession));
        }
    }
}
