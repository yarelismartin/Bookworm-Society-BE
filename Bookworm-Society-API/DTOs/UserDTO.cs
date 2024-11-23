using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Username { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Username = user.Username;
            ImageUrl = user.ImageUrl;
        }

    }
}
