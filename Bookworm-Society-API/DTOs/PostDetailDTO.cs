using Bookworm_Society_API.Data;
using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class PostDetailDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPinned { get; set; }
        public bool IsEdited { get; set; }
        public UserDTO User { get; set; }
        public List<object> Comments { get; set; } 

        public PostDetailDTO(Post post)
        {
            Id = post.Id;
            Content = post.Content;
            CreatedDate = post.CreatedDate;
            IsPinned = post.IsPinned;
            IsEdited = post.IsEdited;
            User = new UserDTO(post.User);
            Comments = post.Comments?
                .OrderBy(c => c.CreatedDate)
                .Select(c => new
                {
                    c.Id,
                    c.Content,
                    c.CreatedDate,
                    User = new UserDTO(c.User)
                })
                .ToList<object>();
        }
    }
}
