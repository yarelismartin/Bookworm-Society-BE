using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Endpoints
{
    public static class PostEndpoints
    {
        public static void MapPostEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(Post));
        }
    }
}
