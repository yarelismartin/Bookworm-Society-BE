using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class CreateReviewDTO
    {
        public string Content { get; set; }

        // [Range(1,5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

    }
}
