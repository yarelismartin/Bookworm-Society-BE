using System.ComponentModel.DataAnnotations;

namespace Bookworm_Society_API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Range(1,5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public User Book { get; set; }


    }
}
