namespace Bookworm_Society_API.DTOs
{
    public class CreateVotingSessionRequestDTO
    {
        public int UserId { get; set; }
        public int BookClubId { get; set; }
        public List<int> BookIds { get; set; }
    }

}
