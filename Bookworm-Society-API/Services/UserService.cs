using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<User>> GetUserByIdAsync(int userId)
        {
             var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return Result<User>.FailureResult($"No user was found with the following id: {userId}", ErrorType.NotFound);
            }

            return Result<User>.SuccessResult(user);

        }
    }
}
