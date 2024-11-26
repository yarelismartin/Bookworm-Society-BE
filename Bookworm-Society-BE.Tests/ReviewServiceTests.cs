using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Services;
using FluentAssertions;
using Moq;

namespace Bookworm_Society_BE.Tests
{
    public class ReviewServiceTests
    {

        private readonly ReviewService _reviewService;
        private readonly Mock<IReviewRepository> _mockReviewRepository;
        private readonly Mock<IBaseRepository> _mockBaseRepository;


        public ReviewServiceTests()
        {
            //Testing saveing 
            // lets us simulate the behavior of the repository without needing a real database.
            _mockReviewRepository = new Mock<IReviewRepository>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            // initialize StoryService with the mock repository.
            // This way, StoryService will use the mocked methods instead of actual database calls.
            _reviewService = new ReviewService(_mockReviewRepository.Object, _mockBaseRepository.Object);
        }

        [Fact]
        public async Task AddReview_ShouldReturnReview_WhenAddedIsSuccessful()
        {
            // Arrange
            var reviewToAdd = new Review
            {
                Content = "Great book! A must-read for all science fiction fans.",
                Rating = 5, // Valid rating between 1 and 5
                UserId = 1, // Assume a valid UserId
                BookId = 1, // Assume a valid BookId
                CreatedDate = DateTime.Now
            };

            var createdReview = new Review
            {
                Id = 1, // Simulating an auto-generated Id
                Content = reviewToAdd.Content,
                Rating = reviewToAdd.Rating,
                UserId = reviewToAdd.UserId,
                BookId = reviewToAdd.BookId,
                CreatedDate = reviewToAdd.CreatedDate
            };

            // Mock the repository methods
            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(reviewToAdd.UserId))
                .ReturnsAsync(true); // Simulate that the user exists

            _mockBaseRepository.Setup(repo => repo.BookExistsAsync(reviewToAdd.BookId))
                .ReturnsAsync(true); // Simulate that the book exists

            _mockReviewRepository.Setup(repo => repo.CreateReviewAsync(It.IsAny<Review>()))
                .ReturnsAsync(createdReview); // Simulate creating the review and returning it

            // Act
            var result = await _reviewService.CreateReviewAsync(reviewToAdd);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); // Ensure the result is not null
            result.Success.Should().BeTrue(); // Ensure the result is a success
            result.Data.Should().NotBeNull(); // Ensure the Data property is not null
        }

        [Fact]
        public async Task UpdateReview_ShouldReturnTheUpdatedReview_WhenUpdateIsSuccessful()
        {
            // Arrange
            var reviewId = 1; // The review ID to update
            var reviewToUpdate = new Review
            {
                Content = "Updated review content. It's a fantastic book!",
                Rating = 5, // Valid rating between 1 and 5
                UserId = 1, // Assume valid UserId
                BookId = 1, // Assume valid BookId
                CreatedDate = DateTime.Now
            };

            var existingReview = new Review
            {
                Id = reviewId, // The existing review to update
                Content = "Old review content.",
                Rating = 3, // Old rating
                UserId = 1,
                BookId = 1,
                CreatedDate = DateTime.Now
            };

            var updatedReview = new Review
            {
                Id = reviewId, // The updated review
                Content = reviewToUpdate.Content,
                Rating = reviewToUpdate.Rating,
                UserId = reviewToUpdate.UserId,
                BookId = reviewToUpdate.BookId,
                CreatedDate = existingReview.CreatedDate // Keep the same CreatedDate
            };

            // Mock the repository methods
            _mockReviewRepository.Setup(repo => repo.UpdateReviewAsync(It.IsAny<Review>(), reviewId))
                .ReturnsAsync(updatedReview); // Simulate the review being updated

            // Act
            var result = await _reviewService.UpdateReviewAsync(reviewToUpdate, reviewId);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); // Ensure the result is not null
            result.Success.Should().BeTrue(); // Ensure the result is a success
            result.Data.Should().NotBeNull(); // Ensure the Data property is not null

        }

        [Fact]
        public async Task DeleteReview_ShouldReturnTheDeletedReview_WhenDeleteIsSuccessful()
        {
            // Arrange
            var reviewId = 1; // The review ID to delete

            var existingReview = new Review
            {
                Id = reviewId, // The review to delete
                Content = "This book was amazing! Highly recommended.",
                Rating = 5,
                UserId = 1,
                BookId = 1,
                CreatedDate = DateTime.Now
            };

            // Mock the repository methods to simulate deleting the review
            _mockReviewRepository.Setup(repo => repo.DeleteReviewAsync(reviewId))
                .ReturnsAsync(existingReview); // Simulate the review being deleted

            // Act
            var result = await _reviewService.DeleteReviewAsync(reviewId);

            // Assert with Fluent Assertions
            result.Should().NotBeNull(); // Ensure the result is not null
            result.Success.Should().BeTrue(); // Ensure the result is a success
            result.Data.Should().NotBeNull(); // Ensure the Data property is not null

        }
    }

}