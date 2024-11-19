namespace Bookworm_Society_API.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int BookId { get; set; }
        public Book Book { get; set; }  

        public int VotingSessionId { get; set; }
        public VotingSession VotingSession { get; set; }
    }
}
