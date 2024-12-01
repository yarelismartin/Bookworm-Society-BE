using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Services;
using FluentAssertions;
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
            // Arrange
            var postId = 1;
            var existingPost = new Post
            {
                Id = postId,
                Content = "This is a test post",
                CreatedDate = DateTime.Now,
                IsPinned = false,
                IsEdited = false,
                BookClubId = 1,
                UserId = 1,
                User = new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    ImageUrl = "https://example.com/johndoe.jpg",
                    Username = "johndoe",
                    Uid = "useruid123"
                },
                Comments = new List<Comment>
        {
            new Comment
            {
                Id = 1,
                Content = "This is a test comment",
                CreatedDate = DateTime.Now,
                UserId = 1,
                User = new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    ImageUrl = "https://example.com/johndoe.jpg",
                    Username = "johndoe",
                    Uid = "useruid123"
                }
            }
        }
            };

            // Mock the repository method to return the existing post
            _mockPostRepository.Setup(repo => repo.GetPostByIdAsync(postId))
                .ReturnsAsync(existingPost);

            // Act
            var result = await _postService.GetPostByIdAsync(postId);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task AddPost_ShouldReturnPost_WhenAddedIsSuccessful()
        {
            // Arrange
            var postId = 1;
            var userId = 1;
            var bookClubId = 1;

            var createPostDto = new CreatePostDto
            {
                Content = "This is a test post",
                BookClubId = bookClubId,
                UserId = userId
            };

            var post = new Post
            {
                Id = postId,
                Content = createPostDto.Content,
                CreatedDate = DateTime.Now,
                IsPinned = false,
                IsEdited = false,
                BookClubId = createPostDto.BookClubId,
                UserId = createPostDto.UserId,
                User = new User
                {
                    Id = userId,
                    FirstName = "John",
                    LastName = "Doe",
                    ImageUrl = "https://example.com/johndoe.jpg",
                    Username = "johndoe",
                    Uid = "useruid123"
                },
                Comments = new List<Comment>()
            };

            var existingUser = new User { Id = userId };
            var existingBookClub = new BookClub { Id = bookClubId };

            // Mock the repositories to simulate existing user and book club
            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(userId)).ReturnsAsync(true);
            _mockBaseRepository.Setup(repo => repo.BookClubExistsAsync(bookClubId)).ReturnsAsync(true);
            _mockPostRepository.Setup(repo => repo.IsUserAllowedToPost(bookClubId, userId)).ReturnsAsync(true);
            _mockPostRepository.Setup(repo => repo.CreatePostAsync(It.IsAny<Post>())).ReturnsAsync(post);

            // Act
            var result = await _postService.CreatePostAsync(createPostDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdatePost_ShouldReturnTheUpdatedPost_WhenUpdateIsSuccessful()
        {
            // Arrange
            var postId = 1;
            var post = new Post
            {
                Id = postId,
                Content = "Updated content",
                IsPinned = false,
                IsEdited = true, // This will be set to true after update
                BookClubId = 1,
                UserId = 1
            };

            var existingPost = new Post
            {
                Id = postId,
                Content = "Old content",
                IsPinned = false,
                IsEdited = false, // Before update, it should be false
                BookClubId = 1,
                UserId = 1
            };

            // Mock the repository method to return the existing post
            _mockPostRepository.Setup(repo => repo.UpdatePostAsync(It.IsAny<Post>(), postId))
                .ReturnsAsync(post); // Mock the return value to be the updated post

            _mockPostRepository.Setup(repo => repo.GetPostByIdAsync(postId))
                .ReturnsAsync(existingPost); // Ensure we mock getting the existing post

            // Act
            var result = await _postService.UpdatePostAsync(post, postId);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();


        }

        [Fact]
        public async Task DeleteePost_ShouldReturnTheDeletedPost_WhenDeleteIsSuccessful()
        {
            // Arrange
            var postId = 1;
            var postToDelete = new Post
            {
                Id = postId,
                Content = "Post content",
                IsPinned = false,
                IsEdited = false,
                BookClubId = 1,
                UserId = 1
            };

            // Mock the repository method to return the post to be deleted
            _mockPostRepository.Setup(repo => repo.DeletePostAsync(postId))
                .ReturnsAsync(postToDelete);

            // Act
            var result = await _postService.DeletePostAsync(postId);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().BeNull();
        }

    }
}
