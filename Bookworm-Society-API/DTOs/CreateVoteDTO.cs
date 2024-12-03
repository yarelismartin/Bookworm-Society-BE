using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class CreateVoteDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int VotingSessionId { get; set; }
    }
}
