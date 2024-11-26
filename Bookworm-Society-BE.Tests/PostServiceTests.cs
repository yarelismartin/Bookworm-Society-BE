using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Services;
using Moq;

namespace Bookworm_Society_BE.Tests
{
    public class PostServiceTests
    {

        private readonly PostService _postService;
        private readonly Mock<IPostRepository> _mockPostRepository;
        private readonly Mock<IBaseRepository> _mockBaseRepository;


        public PostServiceTests()
        {
            //Testing saveing 
            // lets us simulate the behavior of the repository without needing a real database.
            _mockPostRepository = new Mock<IPostRepository>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            // initialize StoryService with the mock repository.
            // This way, StoryService will use the mocked methods instead of actual database calls.
            _postService = new PostService(_mockPostRepository.Object, _mockBaseRepository.Object);
        }

        [Fact]
        public async Task GetPostDetails_ShouldReturnPost_WhenExists()
        {

        }

        [Fact]
        public async Task AddPost_ShouldReturnPost_WhenAddedIsSuccessful()
        {

        }

        [Fact]
        public async Task UpdatePost_ShouldReturnTheUpdatedPost_WhenUpdateIsSuccessful()
        {

        }

        [Fact]
        public async Task DeleteePost_ShouldReturnTheDeletedPost_WhenDeleteIsSuccessful()
        {

        }

    }
}
