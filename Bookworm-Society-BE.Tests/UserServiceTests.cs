using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Services;
using Moq;

namespace Bookworm_Society_BE.Tests
{
    public class UserServiceTests
    {

        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IBaseRepository> _mockBaseRepository;


        public UserServiceTests()
        {
            //Testing saveing 
            // lets us simulate the behavior of the repository without needing a real database.
            _mockUserRepository = new Mock<IUserRepository>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            // initialize StoryService with the mock repository.
            // This way, StoryService will use the mocked methods instead of actual database calls.
            _userService = new UserService(_mockUserRepository.Object, _mockBaseRepository.Object);
        }

        [Fact]
        public async Task GetUserDetails_ShouldReturnUser_WhenExists()
        {

        }

        [Fact]
        public async Task AddUser_ShouldReturnUser_WhenAddedIsSuccessful()
        {

        }

        [Fact]
        public async Task UpdateUser_ShouldReturnTheUpdatedUser_WhenUpdateIsSuccessful()
        {

        }

    }
}
