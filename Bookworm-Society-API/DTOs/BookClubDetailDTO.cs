using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class BookClubDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MeetUpType { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public UserDTO Host { get; set; }
        public BookDTO Book { get; set; }
        public List<UserDTO> Members { get; set; }
        public bool IsMemberOrHost { get; set; }

        public BookClubDetailDTO(BookClub bookClub, int userId)
        {
            Id = bookClub.Id;
            Name = bookClub.Name;
            Description = bookClub.Description;
            MeetUpType = bookClub.MeetUpType;
            ImageUrl = bookClub.ImageUrl;
            DateCreated = bookClub.DateCreated;
            Host = new UserDTO(bookClub.Host);
            Book = bookClub.Book != null ? new BookDTO(bookClub.Book) : null;
            Members = bookClub.Members?.Select(member => new UserDTO(member)).ToList();
            IsMemberOrHost = bookClub.Members.Any(m => m.Id == userId) || bookClub.Host.Id == userId;
        }
    }
}
