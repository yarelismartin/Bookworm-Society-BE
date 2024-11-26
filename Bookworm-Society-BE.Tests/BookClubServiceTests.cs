using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;
using Bookworm_Society_API.Services;
using Bookworm_Society_API.Result;
using FluentAssertions;
using Moq;
using Castle.Components.DictionaryAdapter.Xml;

namespace Bookworm_Society_BE.Tests
{
    public class BookClubServiceTests
    {

        private readonly BookClubService _bookClubService;
        private readonly Mock<IBookClubRepository> _mockBookClubRepository;
        private readonly Mock<IBaseRepository> _mockBaseRepository;


        public BookClubServiceTests()
        {
            //Testing saveing 
            // lets us simulate the behavior of the repository without needing a real database.
            _mockBookClubRepository = new Mock<IBookClubRepository>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            // initialize StoryService with the mock repository.
            // This way, StoryService will use the mocked methods instead of actual database calls.
            _bookClubService = new BookClubService(_mockBookClubRepository.Object, _mockBaseRepository.Object);
        }

        [Fact]
        public async Task GetAllBookClubs_ShouldReturnListOfBookClubs()
        {
            // Arrange
            var expectedBookClubList = new List<BookClub>
            {

                new BookClub
                {
                    Id = 1,
                    Name = "Sci-Fi Enthusiasts",
                    MeetUpType = "Online",
                    Description = "A group for sci-fi fans to discuss books and movies.",
                    ImageUrl = "https://example.com/sci-fi-enthusiasts.jpg",
                    DateCreated = new DateTime(2023, 11, 20), 
                    HostId = 1,
                    BookId = 101,
                },
                new BookClub
                {
                    Id = 2,
                    Name = "Historical Fiction Lovers",
                    MeetUpType = "In-Person",
                    Description = "Dive into history through engaging fiction with fellow enthusiasts.",
                    ImageUrl = "https://example.com/historical-fiction.jpg",
                    DateCreated = new DateTime(2023, 10, 15),
                    HostId = 2,
                    BookId = 102,
                }
            };

            var expectedBookClubDTOList = expectedBookClubList.Select(bookClub => new BookClubDTO(bookClub)).ToList();

            _mockBookClubRepository.Setup(repo => repo.GetBookClubsAsync()).ReturnsAsync(expectedBookClubList);

            // Act
            List<BookClubDTO> actualBookClubList = await _bookClubService.GetBookClubsAsync();

            // Assert
            actualBookClubList.Should().BeEquivalentTo(expectedBookClubDTOList);
        }

        [Fact]
        public async Task GetBookClubDetails_ShouldReturnBookClub_WhenExists()
        {
            // Arrange
            int bookClubId = 1; // The id of the book club we want to test
            int userId = 2;     // The id of the user requesting the details

            // Mock data
            var bookClub = new BookClub
            {
                Id = bookClubId,
                Name = "Sci-Fi Enthusiasts",
                MeetUpType = "Online",
                Description = "A group for sci-fi fans to discuss books and movies.",
                ImageUrl = "https://example.com/sci-fi-enthusiasts.jpg",
                DateCreated = new DateTime(2023, 11, 20),
                HostId = 1, // Host Id
                BookId = 102, // Book ID
                Book = new Book { Id = 1, Title = "Dune" }, // Book being read
                Host = new User { Id = 1 }, // Host User
                Members = new List<User> // Adding members to the BookClub
        {
            new User { Id = 2 }, // Member 1
            new User { Id = 3}   // Member 2
        }
            };

            var expectedDto = new
            {
                bookClub.Id,
                bookClub.Name,
                bookClub.Description,
                bookClub.MeetUpType,
                bookClub.ImageUrl,
                bookClub.DateCreated,
                isMemberOrHost = bookClub.Members.Any(m => m.Id == userId) || bookClub.Host.Id == userId,
            };

            _mockBookClubRepository.Setup(repo => repo.GetBookClubByIdAsync(bookClubId))
                .ReturnsAsync(bookClub);

            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(userId))
                .ReturnsAsync(true);

            // Act
            var result = await _bookClubService.GetBookClubByIdAsync(bookClubId, userId);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); // Ensure the result is not null
            var successResult = result.Should().BeOfType<Result<object>>().Subject; // Ensure the result is of type SuccessResult<object>
            successResult.Success.Should().BeTrue();
            successResult.Message.Should().Be("Success");
            successResult.Data.Should().BeEquivalentTo(expectedDto); // Compare the returned DTO with the expected DTO
        }


        [Fact]
        public async Task AddBookClub_ShouldReturnBookClub_WhenAddedIsSuccessful()
        {
            // Arrange
            var bookClubToCreate = new BookClub
            {
                Name = "Sci-Fi Enthusiasts",
                MeetUpType = "Online",
                Description = "A group for sci-fi fans to discuss books and movies.",
                ImageUrl = "https://example.com/sci-fi-enthusiasts.jpg",
                HostId = 1, // Assume the host exists
            };

            var createdBookClub = new BookClub
            {
                Id = 1, // Simulate an auto-generated Id
                Name = bookClubToCreate.Name,
                MeetUpType = bookClubToCreate.MeetUpType,
                Description = bookClubToCreate.Description,
                ImageUrl = bookClubToCreate.ImageUrl,
                HostId = bookClubToCreate.HostId
            };

            // Mock the repository methods
            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(bookClubToCreate.HostId))
                .ReturnsAsync(true); // Simulate that the host exists

            _mockBookClubRepository.Setup(repo => repo.CreateBookClubAsync(It.IsAny<BookClub>()))
    .ReturnsAsync(createdBookClub);

            // Act
            var result = await _bookClubService.CreateBookClubAsync(bookClubToCreate);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); // Ensure the result is not null
            result.Success.Should().BeTrue(); // Ensure the result is a success
            result.Data.Should().NotBeNull(); // Ensure the Data property is not null
        }

        [Fact]
        public async Task UpdateBookClub_ShouldReturnTheUpdatedBookClub_WhenUpdateIsSuccessful()
        {
            // Arrange
            var bookClubId = 1;

            var bookClubToUpdate = new BookClub
            {
                Name = "Updated Sci-Fi Enthusiasts",
                MeetUpType = "Offline",
                Description = "An updated description for sci-fi fans.",
                ImageUrl = "https://example.com/updated-sci-fi.jpg",
                HostId = 1 // Assume the host exists
            };

            var existingBookClub = new BookClub
            {
                Id = bookClubId,
                Name = "Sci-Fi Enthusiasts",
                MeetUpType = "Online",
                Description = "A group for sci-fi fans to discuss books and movies.",
                ImageUrl = "https://example.com/sci-fi-enthusiasts.jpg",
                HostId = 1
            };

            var updatedBookClub = new BookClub
            {
                Id = bookClubId,
                Name = bookClubToUpdate.Name,
                MeetUpType = bookClubToUpdate.MeetUpType,
                Description = bookClubToUpdate.Description,
                ImageUrl = bookClubToUpdate.ImageUrl,
                HostId = bookClubToUpdate.HostId
            };

            // Mock the repository methods
            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(bookClubToUpdate.HostId))
                .ReturnsAsync(true); // Simulate that the host exists

            _mockBookClubRepository.Setup(repo => repo.UpdateBookClubAsync(bookClubToUpdate, bookClubId))
                .ReturnsAsync(updatedBookClub); // Return the updated book club

            // Act
            var result = await _bookClubService.UpdateBookClubAsync(bookClubToUpdate, bookClubId);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); // Ensure result is not null
            result.Success.Should().BeTrue(); // Ensure the result is a success
            result.Data.Should().NotBeNull(); // Ensure Data property is not null
        }

        [Fact]
        public async Task DeleteeBookClub_ShouldReturnTheDeletedBookClub_WhenDeleteIsSuccessful()
        {
            // Arrange
            var bookClubId = 1;

            var bookClubToDelete = new BookClub
            {
                Id = bookClubId,
                Name = "Sci-Fi Enthusiasts",
                MeetUpType = "Online",
                Description = "A group for sci-fi fans to discuss books and movies.",
                ImageUrl = "https://example.com/sci-fi-enthusiasts.jpg",
                HostId = 1
            };

            // Mock the repository method for deleting the book club
            _mockBookClubRepository.Setup(repo => repo.DeleteBookClubAsync(bookClubId))
                .ReturnsAsync(bookClubToDelete); // Return the deleted book club

            // Act
            var result = await _bookClubService.DeleteBookClubAsync(bookClubId);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); // Ensure result is not null
            result.Success.Should().BeTrue(); // Ensure the result is a success
            result.Data.Should().NotBeNull(); // Ensure the Data property is not null
        }

    }
}
