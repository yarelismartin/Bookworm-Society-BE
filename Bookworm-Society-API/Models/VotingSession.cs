namespace Bookworm_Society_API.Models
{
    public class VotingSession
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime VotingStartDate { get; set; } = DateTime.Now;
        public DateTime VotingEndDate { get; set; }

        public int? WinningBookId { get; set; }
        public Book? WinningBook { get; set; }

        public int BookClubId { get; set; }
        public BookClub BookClub { get; set; }

        public List<Book>? VotingBooks {  get; set; }
        public List<Vote>? Votes { get; set; }

    }
}
