﻿using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Endpoints
{
    public static class VoteEndpoints
    {
        public static void MapVoteEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("").WithTags(nameof(Vote));
        }
    }
}
