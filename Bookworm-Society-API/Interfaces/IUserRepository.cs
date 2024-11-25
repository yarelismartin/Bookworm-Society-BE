using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IUserRepository

    {
        Task<User?> GetUserByIdAsync(int userId);
        Task<bool> UserUidAlreadyInUseAsync(string userUid);
        Task<User> CreateUserAsync(User user);

        Task<User> UpdateUserAsync(User user, int userId);

        Task<User?> CheckUserAsync(string userUid);

        Task<User?> GetUsersClubs(int userId);
    }

}
