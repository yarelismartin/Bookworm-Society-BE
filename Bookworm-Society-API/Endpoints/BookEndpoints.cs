using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Helpers;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;
using Bookworm_Society_API.Services;
using System.Text.RegularExpressions;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bookworm_Society_API.Endpoints
{
    public static class BookEndpoints
    {
        public static void MapBookEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("books").WithTags(nameof(Book));

            /*group.MapGet("/", async (IBookService bookService) =>
            {
                var books = await bookService.GetAllBooksAsync();

                if (!books.Any())
                {
                    return Results.Ok(new List<BookClub>());
                }
                return Results.Ok(books);
            });*/


            group.MapGet("/", async (IBookService bookService, int page = 1, int pageSize = 5) =>
            {
                var books = await bookService.GetPaginatedBooksAsync(page, pageSize);

                if (!books.Items.Any())
                {
                    // Return a PagedList with an empty list and pagination metadata
                    var emptyPagedList = new PagedList<BookDTO>(
                        new List<BookDTO>(),
                        books.PageNumber,
                        books.PageSize,
                        books.TotalCount
                    );
                    return Results.Ok(emptyPagedList);
                }
                return Results.Ok(books);
            });

            group.MapGet("/{bookId}", async (IBookService bookService, int bookId) =>
            {
                var book = await bookService.GetSingleBookAsync(bookId);

                if (book.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(book.Message);
                }
                return Results.Ok(book.Data);

            });


            group.MapGet("/popular", async (IBookService bookService) =>
            {
                var book = await bookService.GetMostPopularBookAsync();

                return Results.Ok(book);
            });

            group.MapGet("/search", async (IBookService bookService) =>
            {

            });
        }
    }
}
