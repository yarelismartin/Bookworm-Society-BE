namespace Bookworm_Society_API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; } 
        public string Genre { get; set; }
        public string ImageUrl { get; set; }
        public List<VotingSession>? VotingSessions {  get; set; }
        public List<BookClub>? BookClubs { get; set;}
        public List<Review>? Reviews { get; set; }

    }
}
