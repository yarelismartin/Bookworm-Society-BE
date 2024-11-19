using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Endpoints
{
    public static class CommentEndpoints
    {
        public static void MapCommentEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(Comment));
        }
    }
}
