using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Endpoints
{
    public static class VotingSessionEndpoint
    {
        public static void MapCategoryEndpoint(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(VotingSession));
        }
    }
}
