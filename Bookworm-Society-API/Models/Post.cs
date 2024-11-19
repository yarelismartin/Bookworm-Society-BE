namespace Bookworm_Society_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool isPinned { get; set; } = false;
        public bool isEdited { get; set; } = false;

        public int BookClubId { get; set; }
        public int BookClub {  get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
