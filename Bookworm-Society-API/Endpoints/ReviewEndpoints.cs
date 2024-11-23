using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;
using Bookworm_Society_API.Services;

namespace Bookworm_Society_API.Endpoints
{
    public static class ReviewEndpoints
    {
        public static void MapReviewEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("reviews").WithTags(nameof(Review));

            group.MapPost("/", async (IReviewService reviewService, Review review) =>
            {
                var result = await reviewService.CreateReviewAsync(review);

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

            group.MapPatch("/", async (IReviewService reviewService, Review review, int reviewId) =>
            {
                var result = await reviewService.UpdateReviewAsync(review, reviewId);

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

            group.MapDelete("/", async (IReviewService reviewService, int reviewId) =>
            {
                var result = await reviewService.DeleteReviewAsync(reviewId);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }

                return Results.Ok(result.Data);
            });
        }
    }
}
