using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class BookClubData
    {
        public static List<BookClub> BookClubs = new()
{
            new() { Id = 1, Name = "Literary Legends", MeetUpType = "Online", Description = "A club for avid readers of classic literature.", ImageUrl = "https://images.unsplash.com/photo-1534580235139-e2ef095e1972?q=80&w=1287&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", DateCreated = new DateTime(2023, 1, 15), HostId = 1, BookId = 101 },
            new() { Id = 2, Name = "Fantasy Fanatics", MeetUpType = "In-Person", Description = "Discussing all things fantasy and magical worlds.", ImageUrl = "https://images.unsplash.com/photo-1548445929-4f60a497f851?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", DateCreated = new DateTime(2023, 2, 10), HostId = 2, BookId = 102 },
            new() { Id = 3, Name = "Sci-Fi Society", MeetUpType = "Hybrid", Description = "Exploring science fiction novels and ideas.", ImageUrl = "https://plus.unsplash.com/premium_photo-1701085496588-8f294c8cd063?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", DateCreated = new DateTime(2023, 3, 5), HostId = 3, BookId = 103 },
            new() { Id = 4, Name = "Mystery Maniacs", MeetUpType = "Online", Description = "For fans of thrilling mysteries and crime stories.", ImageUrl = "https://plus.unsplash.com/premium_photo-1673635651187-8206328b0b61?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fG15c3Rlcnl8ZW58MHx8MHx8fDA%3D", DateCreated = new DateTime(2023, 4, 20), HostId = 4, BookId = 104 },
            new() { Id = 5, Name = "Romance Readers", MeetUpType = "In-Person", Description = "A group dedicated to the best romance novels.", ImageUrl = "https://images.unsplash.com/photo-1459623837994-06d03aa27b9b?q=80&w=1332&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", DateCreated = new DateTime(2023, 5, 15), HostId = 5, BookId = 105 },
            new() { Id = 6, Name = "Historical Tales", MeetUpType = "Online", Description = "Delve into historical fiction with fellow enthusiasts.", ImageUrl = "https://plus.unsplash.com/premium_photo-1726768903173-8cac387e97ab?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjF8fGhpc3RvcmljYWwlMjBib29rc3xlbnwwfHwwfHx8MA%3D%3D", DateCreated = new DateTime(2023, 6, 10), HostId = 6, BookId = 106 },
            new() { Id = 7, Name = "Thriller Thursdays", MeetUpType = "Hybrid", Description = "Intense thrillers and gripping reads every week.", ImageUrl = "https://images.unsplash.com/photo-1674521659179-b93d7eed75c8?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjN8fHRocmlsbGVyfGVufDB8fDB8fHww", DateCreated = new DateTime(2023, 7, 5), HostId = 7, BookId = 107 },
            new() { Id = 8, Name = "Supernatural Circle", MeetUpType = "In-Person", Description = "Exploring supernatural and paranormal fiction.", ImageUrl = "https://images.unsplash.com/photo-1485855691614-f7547af0c4c5?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDZ8fHN1cGVybmF0dXJhbHxlbnwwfHwwfHx8MA%3D%3D", DateCreated = new DateTime(2023, 8, 25), HostId = 8, BookId = 108 },
            new() { Id = 9, Name = "Slice of Life", MeetUpType = "Online", Description = "Heartwarming stories and everyday adventures.", ImageUrl = "https://images.unsplash.com/photo-1604960592081-96019492fcc4?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8dHJhdmVsJTIwYm9va3xlbnwwfHwwfHx8MA%3D%3D", DateCreated = new DateTime(2023, 9, 15), HostId = 9, BookId = 109 },
            new() { Id = 10, Name = "Horror House", MeetUpType = "Hybrid", Description = "Spooky tales and scary reads for brave souls.", ImageUrl = "https://images.unsplash.com/photo-1595171694538-beb81da39d3e?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTJ8fHRocmlsbGVyfGVufDB8fDB8fHww", DateCreated = new DateTime(2023, 10, 1), HostId = 10, BookId = 110 }
};
    }
}
