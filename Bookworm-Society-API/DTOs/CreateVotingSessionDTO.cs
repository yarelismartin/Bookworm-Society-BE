namespace Bookworm_Society_API.DTOs
{
    public class CreateVotingSessionDTO
    {
        public DateTime VotingEndDate { get; set; }
        public int BookClubId { get; set; }
        public List<int> BookIds { get; set; }
    }
}
