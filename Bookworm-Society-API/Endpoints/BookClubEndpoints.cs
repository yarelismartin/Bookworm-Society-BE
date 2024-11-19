using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Endpoints
{
    public static class BookClubEndpoints
    {
        public static void MapBookClubEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(BookClub));
        }
    }
}
