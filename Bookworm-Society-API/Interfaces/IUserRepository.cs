using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Interfaces
{
    public interface IUserRepository

    {
        Task<User?> GetUserByIdAsync(int userId);
    }

}
