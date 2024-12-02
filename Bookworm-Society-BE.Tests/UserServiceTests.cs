using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Services;
using FluentAssertions;
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
            // Arrange
            var userId = 1; // The user ID to get details for
            var existingUser = new User
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                ImageUrl = "https://example.com/johndoe.jpg",
                Username = "johndoe",
                JoinedDate = new DateTime(2020, 5, 1),
                Uid = "abc123"
            };

            // Mock the repository to return the existing user
            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userId))
                .ReturnsAsync(existingUser);

            // Act
            var result = await _userService.GetUserByIdAsync(userId);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); // Ensure the result is not null
            result.Success.Should().BeTrue(); // Ensure the result is a success
        }

        [Fact]
        public async Task AddUser_ShouldReturnUser_WhenAddedIsSuccessful()
        {
            // Arrange
            var userDto = new CreateUserDTO
            {
                FirstName = "Jane",
                LastName = "Doe",
                ImageUrl = "https://example.com/janedoe.jpg",
                Username = "janedoe",
                Uid = "newuseruid123"
            };

            var user = new User
            {
                Id = 1,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                ImageUrl = userDto.ImageUrl,
                Username = userDto.Username,
                Uid = userDto.Uid
            };

            var userDetailDto = new UserDetailDTO(user);

            _mockUserRepository.Setup(repo => repo.UserUidAlreadyInUseAsync(userDto.Uid))
                .ReturnsAsync(false);
            _mockUserRepository.Setup(repo => repo.CreateUserAsync(It.IsAny<User>()))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.CreateUserAsync(userDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(userDetailDto);

        }

        [Fact]
        public async Task UpdateUser_ShouldReturnTheUpdatedUser_WhenUpdateIsSuccessful()
        {
            // Arrange
            var userId = 1;
            var existingUser = new User
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                ImageUrl = "https://example.com/johndoe.jpg",
                Username = "johndoe",
                Uid = "useruid123"
            };

            var updatedUser = new User
            {
                Id = userId,
                FirstName = "Johnny",
                LastName = "Doe",
                ImageUrl = "https://example.com/johnnydoe.jpg",
                Username = "johnnydoe",
                Uid = "useruid123"
            };

            // Mock the repository to simulate getting the existing user and updating the user
            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(userId))
                .ReturnsAsync(true); // Simulate that the user exists
            _mockUserRepository.Setup(repo => repo.UpdateUserAsync(updatedUser, userId))
                .ReturnsAsync(updatedUser); // Simulate the successful update

            // Act
            var result = await _userService.UpdateUserAsync(updatedUser, userId);

            // Assert
            result.Should().NotBeNull(); // Ensure the result is not null
            result.Success.Should().BeTrue(); // Ensure the result is a success
            result.Data.Should().NotBeNull(); // Ensure the data (updated user) is returned
        }

    }
}
