using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Services;
using Moq;

namespace Bookworm_Society_BE.Tests
{
    public class CommentServiceTests
    {

        private readonly CommentService _commentService;
        private readonly Mock<ICommentRepository> _mockCommentRepository;
        private readonly Mock<IBaseRepository> _mockBaseRepository;


        public CommentServiceTests()
        {
            //Testing saveing 
            // lets us simulate the behavior of the repository without needing a real database.
            _mockCommentRepository = new Mock<ICommentRepository>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            // initialize StoryService with the mock repository.
            // This way, StoryService will use the mocked methods instead of actual database calls.
            _commentService = new CommentService(_mockCommentRepository.Object, _mockBaseRepository.Object);
        }

        [Fact]
        public async Task AddComment_ShouldReturnComment_WhenAddedIsSuccessful()
        {

        }

        [Fact]
        public async Task DeleteComment_ShouldReturnTheDeletedComment_WhenDeleteIsSuccessful()
        {

        }
    }

}