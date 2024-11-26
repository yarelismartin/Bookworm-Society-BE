using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Services;
using Moq;

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

        }

        [Fact]
        public async Task GetBookClubDetails_ShouldReturnBookClub_WhenExists()
        {

        }

        [Fact]
        public async Task AddBookClub_ShouldReturnBookClub_WhenAddedIsSuccessful()
        {

        }

        [Fact]
        public async Task UpdateBookClub_ShouldReturnTheUpdatedBookClub_WhenUpdateIsSuccessful()
        {

        }

        [Fact]
        public async Task DeleteeBookClub_ShouldReturnTheDeletedBookClub_WhenDeleteIsSuccessful()
        {

        }

    }
}
