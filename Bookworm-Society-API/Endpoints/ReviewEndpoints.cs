using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Endpoints
{
    public static class ReviewEndpoints
    {
        public static void MapReviewEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(Review));
        }
    }
}
