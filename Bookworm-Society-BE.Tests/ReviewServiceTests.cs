using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Services;
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

        }

        [Fact]
        public async Task UpdateReview_ShouldReturnTheUpdatedReview_WhenUpdateIsSuccessful()
        {

        }

        [Fact]
        public async Task DeleteReview_ShouldReturnTheDeletedReview_WhenDeleteIsSuccessful()
        {

        }
    }

}