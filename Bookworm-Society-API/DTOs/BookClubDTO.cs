using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class BookClubDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MeetUpType { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public BookClubDTO(BookClub bookClub)
        { 
            Id = bookClub.Id;
            Name = bookClub.Name;
            MeetUpType = bookClub.MeetUpType;
            Description = bookClub.Description;
            ImageUrl = bookClub.ImageUrl;
            DateCreated = bookClub.DateCreated;
        }

    }
}
