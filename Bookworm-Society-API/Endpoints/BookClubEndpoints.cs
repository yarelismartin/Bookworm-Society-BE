﻿using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
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

            group.MapGet("/{bookClubId}", async (IBookClubService bookClubService, int bookClubId) =>
            {
                var bookClub = await bookClubService.GetBookClubByIdAsync(bookClubId);

                if (bookClub == null)
                {
                    return Results.NotFound($"No book club was found with the following id: {bookClubId}");
                }

                var dto = new
                {
                    bookClub.Id,
                    bookClub.Name,
                    bookClub.Description,
                    bookClub.MeetUpType,
                    bookClub.ImageUrl,
                    bookClub.DateCreated,
                    Host = new UserDTO(bookClub.Host),
                    Book = new BookDTO(bookClub.Book),
                    Members = bookClub.Members?.Select(member => new UserDTO(member)).ToList(),
                };

                return Results.Ok(dto);
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
        }
    }
}
