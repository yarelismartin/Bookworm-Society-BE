using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Repositories;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IBaseRepository _baseRepository;

        public UserService(IUserRepository userRepository, IBaseRepository baseRepository)
        {
            _userRepository = userRepository;
            _baseRepository = baseRepository;
        }

        public async Task<Result<object>> GetUserByIdAsync(int userId)
        {
             var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return Result<object>.FailureResult($"No user was found with the following id: {userId}", ErrorType.NotFound);
            }

            var userObj = new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.ImageUrl,
                user.Username,
                user.JoinedDate,
                user.Uid,

            };

            return Result<object>.SuccessResult(userObj);

        }

        public async Task<Result<User>> CreateUserAsync(User user)
        {
            if(await _userRepository.UserUidAlreadyInUseAsync(user.Uid))
            {
                return Result<User>.FailureResult($"The following uid is already in use: {user.Uid}", ErrorType.Conflict);
            }

            User userObject = new()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = user.ImageUrl,
                Username = user.Username,
                Uid = user.Uid,

            };

            var newUser = await _userRepository.CreateUserAsync(userObject);

            return Result<User>.SuccessResult(newUser);


        }

        public async Task<Result<User>> UpdateUserAsync(User user, int userId)
        {
            if (!await _baseRepository.UserExistsAsync(userId))
            {
                return Result<User>.FailureResult($"No user found with the following id: {userId}", ErrorType.NotFound);
            }

            var updatedUser = await _userRepository.UpdateUserAsync(user, userId);

            return Result<User>.SuccessResult(updatedUser);
        }
    }
}
