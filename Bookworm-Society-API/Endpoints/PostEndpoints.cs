﻿using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;
using Bookworm_Society_API.Services;
using Microsoft.Extensions.Hosting;

namespace Bookworm_Society_API.Endpoints
{
    public static class PostEndpoints
    {
        public static void MapPostEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("posts").WithTags(nameof(Post));

            group.MapGet("/{postId}", async (IPostService postService, int postId) =>
            {
                var post = await postService.GetPostByIdAsync(postId);

                if (post.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(post.Message);
                }

                return Results.Ok(post.Data);
            });

            group.MapPost("/", async (IPostService postService, CreatePostDto postDto) =>
            {
                var result = await postService.CreatePostAsync(postDto);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }
                if (result.ErrorType == ErrorType.Conflict)
                {
                    return Results.Conflict(result.Message);
                }

                return Results.Ok(result.Data);
            });

            group.MapPatch("/{postId}", async (IPostService postService, Post post, int postId) =>
            {
                var result = await postService.UpdatePostAsync(post, postId);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }

                return Results.Ok(result.Data);
            });

            group.MapDelete("/{postId}", async (IPostService postService, int postId) =>
            {
                var result = await postService.DeletePostAsync(postId);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }

                return Results.NoContent();
            });

            group.MapPatch("/{postId}/pin-post", async (IPostService postService, PinPostRequestDTO pinRequestDto, int postId) =>
            {
                var result = await postService.PinPostAsync(pinRequestDto, postId);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }
                if (result.ErrorType == ErrorType.Conflict)
                {
                    return Results.Conflict(result.Message);
                }

                return Results.Ok(result.Message);
            });
        }
    }
}
