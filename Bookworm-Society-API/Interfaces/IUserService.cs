using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IUserService

    {
        Task<Result<User>> GetUserByIdAsync(int userId);
        Task<Result<User>> CreateUserAsync(User user);
    }

}
