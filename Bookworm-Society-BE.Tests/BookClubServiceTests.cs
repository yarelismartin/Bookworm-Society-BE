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
            int bookClubId = 1;
            int userId = 2;

            var bookClub = new BookClub
            {
                Id = bookClubId,
                Name = "Sci-Fi Enthusiasts",
                MeetUpType = "Online",
                Description = "A group for sci-fi fans to discuss books and movies.",
                ImageUrl = "https://example.com/sci-fi-enthusiasts.jpg",
                DateCreated = new DateTime(2023, 11, 20),
                HostId = 1,
                BookId = 102,
                Book = new Book { Id = 1, Title = "Dune", Author = new Author { FirstName = "test", LastName = "testt" }, ImageUrl="test" },
                Host = new User { Id = 1 },
                Members = new List<User>
                    {
                        new User { Id = 2 },
                        new User { Id = 3 }
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
                Host = new UserDTO(bookClub.Host),
                Book = bookClub.Book != null ? new BookDTO(bookClub.Book) : null,
                Members = bookClub.Members?.Select(m => new UserDTO(m)).ToList(),
                isMemberOrHost = bookClub.Members.Any(m => m.Id == userId) || bookClub.Host.Id == userId,
            };

            // Mock
            _mockBookClubRepository.Setup(repo => repo.GetBookClubByIdAsync(bookClubId))
                .ReturnsAsync(bookClub);

            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(userId))
                .ReturnsAsync(true);

            // Act
            var result = await _bookClubService.GetBookClubByIdAsync(bookClubId, userId);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(expectedDto);
        }


        [Fact]
        public async Task AddBookClub_ShouldReturnBookClub_WhenAddedIsSuccessful()
        {
            // Arrange
            var bookClubToCreate = new CreateBookClubDTO
            {
                Name = "Sci-Fi Enthusiasts",
                MeetUpType = "Online",
                Description = "A group for sci-fi fans to discuss books and movies.",
                ImageUrl = "https://example.com/sci-fi-enthusiasts.jpg",
                HostId = 1,
            };

            var createdBookClub = new BookClub
            {
                Id = 1,
                Name = bookClubToCreate.Name,
                MeetUpType = bookClubToCreate.MeetUpType,
                Description = bookClubToCreate.Description,
                ImageUrl = bookClubToCreate.ImageUrl,
                HostId = bookClubToCreate.HostId,
                Members = new List<User>(), 
                DateCreated = DateTime.Now
            };

            // Mock
            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(bookClubToCreate.HostId))
                .ReturnsAsync(true);

            _mockBookClubRepository.Setup(repo => repo.CreateBookClubAsync(It.IsAny<BookClub>()))
                .ReturnsAsync(createdBookClub);

            // Act
            var result = await _bookClubService.CreateBookClubAsync(bookClubToCreate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(createdBookClub);
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
                .ReturnsAsync(true);

            _mockBookClubRepository.Setup(repo => repo.UpdateBookClubAsync(bookClubToUpdate, bookClubId))
                .ReturnsAsync(updatedBookClub);

            // Act
            var result = await _bookClubService.UpdateBookClubAsync(bookClubToUpdate, bookClubId);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); 
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull(); 
        }

        [Fact]
        public async Task DeleteeBookClub_ShouldReturnNoContent_WhenDeleteIsSuccessful()
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
                .ReturnsAsync(bookClubToDelete); 

            // Act
            var result = await _bookClubService.DeleteBookClubAsync(bookClubId);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); 
            result.Success.Should().BeTrue();
            result.Data.Should().BeNull();
        }

    }
}
