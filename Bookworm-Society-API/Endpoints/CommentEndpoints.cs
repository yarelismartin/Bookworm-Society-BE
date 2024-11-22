﻿using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;
using Bookworm_Society_API.Services;

namespace Bookworm_Society_API.Endpoints
{
    public static class CommentEndpoints
    {
        public static void MapCommentEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("comments").WithTags(nameof(Comment));

            group.MapPost("/", async (ICommentService commentService, Comment comment) =>
            {
                var result = await commentService.CreateCommentAsync(comment);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }

                return Results.Ok(result.Data);
            });

            group.MapDelete("/{commentId}", async (ICommentService commentService, int commentId) =>
            {
                var result = await commentService.DeleteCommentAsync(commentId);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }

                return Results.Ok(result.Data);
            });
        }
    }
}
