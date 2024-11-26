using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Repositories;
using Bookworm_Society_API.Result;
using System.Text.RegularExpressions;

namespace Bookworm_Society_API.Endpoints
{
    public static class BookClubEndpoints
    {
        public static void MapBookClubEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("bookclubs").WithTags(nameof(BookClub));

            group.MapGet("/", async (IBookClubService bookClubService) =>
            {
                var allBookClubs = await bookClubService.GetBookClubsAsync();

                if (!allBookClubs.Any()) 
                { 
                    return Results.Ok(new List<BookClub>());
                }
                return Results.Ok(allBookClubs);
            });

            group.MapGet("/{bookClubId}", async (IBookClubService bookClubService, int bookClubId, int userId) =>
            {
                var bookClub = await bookClubService.GetBookClubByIdAsync(bookClubId, userId);

                if (bookClub.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(bookClub.Message);
                }
                return Results.Ok(bookClub.Data);
            });

            group.MapPost("/", async (IBookClubService bookClubService, BookClub bookClub) =>
            {
                var result = await bookClubService.CreateBookClubAsync(bookClub);
            
                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message); 
                }

                return Results.Created($"/bookclubs/{result.Data.Id}", result.Data);

            });

            group.MapPut("/{bookClubId}", async (IBookClubService bookClubService, BookClub bookClub, int bookClubId) =>
            {
                var result = await bookClubService.UpdateBookClubAsync(bookClub, bookClubId);

                if(result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }

                return Results.Ok(result.Data);
            });

            group.MapDelete("/{bookClubId}", async (IBookClubService bookClubService, int bookClubId) =>
            {
                var bookToDelete = await bookClubService.DeleteBookClubAsync(bookClubId);
                if (bookToDelete.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(bookToDelete.Message);
                }
                return Results.Ok(bookToDelete.Data);
            });

            group.MapGet("/have-read", async (IBookClubService bookClubService, int BookClubId) =>
            {
                var bookClub = await bookClubService.GetABookClubHaveReadAsync(BookClubId);
                if (bookClub.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(bookClub.Message);
                }
                return Results.Ok(bookClub.Data);
            });

            group.MapGet("/community-posts", async (IBookClubService bookClubService, int bookClubId) =>
            {
                var bookClub = await bookClubService.GetABookClubPostAsync(bookClubId);
                if (bookClub.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(bookClub.Message);
                }
                return Results.Ok(bookClub.Data);
            });

            group.MapGet("/{bookClubId}/add-user/{userId}", async (IBookClubService bookClubService, int bookClubId, int userId) =>
            {

                var bookClub = await bookClubService.AddUserToBookClubAsync(bookClubId, userId);
                if (bookClub.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(bookClub.Message);
                }

                if (bookClub.ErrorType == ErrorType.Conflict)
                {
                    return Results.Conflict(bookClub.Message);
                }

                return Results.Ok(bookClub.Data);

            });

            group.MapGet("/{bookClubId}/remove-user/{userId}", async (IBookClubService bookClubService, int bookClubId, int userId) =>
            {
                var bookClub = await bookClubService.RemoveUserFromBookClubAsync(bookClubId, userId);

                if (bookClub.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(bookClub.Message);
                }

                if (bookClub.ErrorType == ErrorType.Conflict)
                {
                    return Results.Conflict(bookClub.Message);
                }

                return Results.Ok(bookClub.Data);
            });
        }
    }
}