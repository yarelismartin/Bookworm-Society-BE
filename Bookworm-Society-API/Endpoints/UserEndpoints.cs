using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("users").WithTags(nameof(User));

            group.MapGet("/{userId}", async (IUserService userService, int userId) =>
            {
                var result = await userService.GetUserByIdAsync(userId);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }
                return Results.Ok(result.Data);
            });

            group.MapPost("/", async (IUserService userService, CreateUserDTO userDTO) =>
            {
                var result = await userService.CreateUserAsync(userDTO);

                if (result.ErrorType == ErrorType.Conflict)
                {
                    return Results.Conflict(result.Message);
                }
                return Results.Ok(result.Data);
            });

            group.MapPatch("/{userId}", async (IUserService userService, User user, int userId) =>
            {
                var result = await userService.UpdateUserAsync(user, userId);

                if(result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }
                return Results.Ok(result.Data);

            });

            group.MapGet("/checkUser/{uid}", async (IUserService userService, string uid) =>
            {
                var result = await userService.CheckUserAsync(uid);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }
                return Results.Ok(result.Data);
            });

            group.MapGet("/{userId}/my-clubs", async (IUserService userService, int userId) =>
            {
                var result = await userService.GetUsersClubs(userId);

                if (result.ErrorType == ErrorType.NotFound)
                {
                    return Results.NotFound(result.Message);
                }
                return Results.Ok(result.Data);
            });
        }
    }
}
