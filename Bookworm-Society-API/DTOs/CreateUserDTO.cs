using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Username { get; set; }
        public string Uid { get; set; }
    }
}
