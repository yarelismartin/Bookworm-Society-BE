using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(User));
        }
    }
}
