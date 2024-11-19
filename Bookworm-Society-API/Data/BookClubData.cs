using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class BookClubData
    {
        public static List<BookClub> BookClubs = new()
{
            new() { Id = 1, Name = "Literary Legends", MeetUpType = "Online", Description = "A club for avid readers of classic literature.", ImageUrl = "https://example.com/club1.jpg", DateCreated = new DateTime(2023, 1, 15), HostId = 1, BookId = 101 },
            new() { Id = 2, Name = "Fantasy Fanatics", MeetUpType = "In-Person", Description = "Discussing all things fantasy and magical worlds.", ImageUrl = "https://example.com/club2.jpg", DateCreated = new DateTime(2023, 2, 10), HostId = 2, BookId = 102 },
            new() { Id = 3, Name = "Sci-Fi Society", MeetUpType = "Hybrid", Description = "Exploring science fiction novels and ideas.", ImageUrl = "https://example.com/club3.jpg", DateCreated = new DateTime(2023, 3, 5), HostId = 3, BookId = 103 },
            new() { Id = 4, Name = "Mystery Maniacs", MeetUpType = "Online", Description = "For fans of thrilling mysteries and crime stories.", ImageUrl = "https://example.com/club4.jpg", DateCreated = new DateTime(2023, 4, 20), HostId = 4, BookId = 104 },
            new() { Id = 5, Name = "Romance Readers", MeetUpType = "In-Person", Description = "A group dedicated to the best romance novels.", ImageUrl = "https://example.com/club5.jpg", DateCreated = new DateTime(2023, 5, 15), HostId = 5, BookId = 105 },
            new() { Id = 6, Name = "Historical Tales", MeetUpType = "Online", Description = "Delve into historical fiction with fellow enthusiasts.", ImageUrl = "https://example.com/club6.jpg", DateCreated = new DateTime(2023, 6, 10), HostId = 6, BookId = 106 },
            new() { Id = 7, Name = "Thriller Thursdays", MeetUpType = "Hybrid", Description = "Intense thrillers and gripping reads every week.", ImageUrl = "https://example.com/club7.jpg", DateCreated = new DateTime(2023, 7, 5), HostId = 7, BookId = 107 },
            new() { Id = 8, Name = "Supernatural Circle", MeetUpType = "In-Person", Description = "Exploring supernatural and paranormal fiction.", ImageUrl = "https://example.com/club8.jpg", DateCreated = new DateTime(2023, 8, 25), HostId = 8, BookId = 108 },
            new() { Id = 9, Name = "Slice of Life", MeetUpType = "Online", Description = "Heartwarming stories and everyday adventures.", ImageUrl = "https://example.com/club9.jpg", DateCreated = new DateTime(2023, 9, 15), HostId = 9, BookId = 109 },
            new() { Id = 10, Name = "Horror House", MeetUpType = "Hybrid", Description = "Spooky tales and scary reads for brave souls.", ImageUrl = "https://example.com/club10.jpg", DateCreated = new DateTime(2023, 10, 1), HostId = 10, BookId = 110 }
};
    }
}
