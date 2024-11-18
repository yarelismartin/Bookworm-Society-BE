namespace Bookworm_Society_API.Models
{
    public class BookClub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeetUpType { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int HostId { get; set; }
        public User Host {  get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public List<VotingSession>? VotingSession {  get; set; }
        public List<User>? Members { get; set; }
        public List<BookClub> HaveRead {  get; set; }
        public List<Post> Posts { get; set; }


    }
}
