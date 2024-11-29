using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Services;
using Moq;
using FluentAssertions;


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
            // Arrange
            var commentToCreate = new Comment
            {
                Content = "Great discussion about sci-fi!",
                PostId = 1, // Simulate existing PostId
                UserId = 2  // Simulate existing UserId
            };

            var createdComment = new Comment
            {
                Id = 1, // Simulate auto-generated Id
                Content = commentToCreate.Content,
                PostId = commentToCreate.PostId,
                UserId = commentToCreate.UserId,
                CreatedDate = DateTime.Now // Timestamp of creation
            };

            // Mock the repository methods
            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(commentToCreate.UserId))
                .ReturnsAsync(true); // Simulate that the user exists

            _mockCommentRepository.Setup(repo => repo.PostExistAsync(commentToCreate.PostId))
                .ReturnsAsync(true); // Simulate that the post exists

            _mockCommentRepository.Setup(repo => repo.CreateCommentAsync(It.IsAny<Comment>()))
                .ReturnsAsync(createdComment); // Return the created comment

            // Act
            var result = await _commentService.CreateCommentAsync(commentToCreate);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); // Ensure the result is not null
            result.Success.Should().BeTrue(); // Ensure the result is a success
            result.Data.Should().NotBeNull(); // Ensure the Data property is not null


        }

        [Fact]
        public async Task DeleteComment_ShouldReturnTheDeletedComment_WhenDeleteIsSuccessful()
        {
            // Arrange
            var commentIdToDelete = 1; 

            var commentToDelete = new Comment
            {
                Id = commentIdToDelete,
                Content = "This is a comment to be deleted",
                PostId = 1, 
                UserId = 2, 
                CreatedDate = DateTime.Now
            };

            // Mock the repository method
            _mockCommentRepository.Setup(repo => repo.DeleteCommentAsync(commentIdToDelete))
                .ReturnsAsync(commentToDelete); 

            // Act
            var result = await _commentService.DeleteCommentAsync(commentIdToDelete);

            // Assert with Fluent Assertions
            result.Should().NotBeNull();
            result.Success.Should().BeTrue(); 
            result.Data.Should().BeNull();

        }
    }

}