using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Endpoints
{
    public static class BookEndpoints
    {
        public static void MapBookEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(Book));
        }
    }
}
