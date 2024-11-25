using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IUserService

    {
        Task<Result<object>> GetUserByIdAsync(int userId);
        Task<Result<User>> CreateUserAsync(User user);
        Task<Result<User>> UpdateUserAsync(User user, int userId);

        Task<Result<object>> CheckUserAsync(string userUid);
        Task<Result<object?>> GetUsersClubs(int userId);
    }

}
