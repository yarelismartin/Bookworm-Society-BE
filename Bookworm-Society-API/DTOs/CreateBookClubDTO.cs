using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class CreateBookClubDTO
    {
        public string Name { get; set; }
        public string MeetUpType { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int HostId { get; set; }
    }
}
