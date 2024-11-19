using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class UserData
    {
        public static List<User> Users = new()
{
        new() { Id = 1, FirstName = "Alice", LastName = "Johnson", ImageUrl = "https://example.com/alice.jpg", Username = "alicej", JoinedDate = new DateTime(2023, 8, 15), Uid = "UID12345" },
        new() { Id = 2, FirstName = "Bob", LastName = "Smith", ImageUrl = "https://example.com/bob.jpg", Username = "bobsmith", JoinedDate = new DateTime(2023, 7, 20), Uid = "UID67890" },
        new() { Id = 3, FirstName = "Charlie", LastName = "Brown", ImageUrl = "https://example.com/charlie.jpg", Username = "charlieb", JoinedDate = new DateTime(2023, 6, 10), Uid = "UID24680" },
        new() { Id = 4, FirstName = "Diana", LastName = "Prince", ImageUrl = "https://example.com/diana.jpg", Username = "dianap", JoinedDate = new DateTime(2023, 5, 25), Uid = "UID13579" },
        new() { Id = 5, FirstName = "Edward", LastName = "Elric", ImageUrl = "https://example.com/edward.jpg", Username = "edwarde", JoinedDate = new DateTime(2023, 4, 12), Uid = "UID11223" },
        new() { Id = 6, FirstName = "Fiona", LastName = "Hill", ImageUrl = "https://example.com/fiona.jpg", Username = "fionah", JoinedDate = new DateTime(2023, 3, 8), Uid = "UID44556" },
        new() { Id = 7, FirstName = "George", LastName = "Harrison", ImageUrl = "https://example.com/george.jpg", Username = "georgeh", JoinedDate = new DateTime(2023, 2, 18), Uid = "UID77889" },
        new() { Id = 8, FirstName = "Hannah", LastName = "Montana", ImageUrl = "https://example.com/hannah.jpg", Username = "hannahm", JoinedDate = new DateTime(2023, 1, 15), Uid = "UID99101" },
        new() { Id = 9, FirstName = "Ian", LastName = "Curtis", ImageUrl = "https://example.com/ian.jpg", Username = "ianc", JoinedDate = new DateTime(2022, 12, 1), Uid = "UID22334" },
        new() { Id = 10, FirstName = "Jill", LastName = "Valentine", ImageUrl = "https://example.com/jill.jpg", Username = "jillv", JoinedDate = new DateTime(2022, 11, 5), Uid = "UID55667" },
        new() { Id = 11, FirstName = "Kyle", LastName = "Reese", ImageUrl = "https://example.com/kyle.jpg", Username = "kyler", JoinedDate = new DateTime(2022, 10, 20), Uid = "UID77880" },
        new() { Id = 12, FirstName = "Laura", LastName = "Croft", ImageUrl = "https://example.com/laura.jpg", Username = "laurac", JoinedDate = new DateTime(2022, 9, 10), Uid = "UID99112" },
        new() { Id = 13, FirstName = "Mike", LastName = "Tyson", ImageUrl = "https://example.com/mike.jpg", Username = "miket", JoinedDate = new DateTime(2022, 8, 15), Uid = "UID22344" },
        new() { Id = 14, FirstName = "Nina", LastName = "Williams", ImageUrl = "https://example.com/nina.jpg", Username = "ninaw", JoinedDate = new DateTime(2022, 7, 25), Uid = "UID55678" },
        new() { Id = 15, FirstName = "Oscar", LastName = "Wilde", ImageUrl = "https://example.com/oscar.jpg", Username = "oscarw", JoinedDate = new DateTime(2022, 6, 30), Uid = "UID77891" }
};

    }
}
