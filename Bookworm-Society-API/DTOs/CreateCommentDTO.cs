using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class CreateCommentDTO
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
