namespace Bookworm_Society_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Username { get; set; }
        public DateTime JoinedDate { get; set; } = DateTime.Now;
        public string Uid { get; set; }
        public List <BookClub>? BookClubs { get; set; }

    }
}
