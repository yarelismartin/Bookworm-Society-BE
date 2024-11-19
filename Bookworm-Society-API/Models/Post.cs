namespace Bookworm_Society_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsPinned { get; set; } = false;
        public bool IsEdited { get; set; } = false;

        public int BookClubId { get; set; }
        public BookClub BookClub {  get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
