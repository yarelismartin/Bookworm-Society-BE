using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Username { get; set; }
        public DateTime JoinedDate { get; set; }
        public string Uid { get; set; }

        public UserDetailDTO(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            ImageUrl = user.ImageUrl;
            Username = user.Username;
            JoinedDate = user.JoinedDate;
            Uid = user.Uid;
        }
    }
}
