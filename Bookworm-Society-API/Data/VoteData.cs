using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class VoteData
    {
        public static List<Vote> Votes = new()
        {
            // Voting Session 1 (Literary Legends - HostId = 1)
            new() { Id = 1, UserId = 1, BookId = 101, VotingSessionId = 1 }, // Host voting in their club
            new() { Id = 2, UserId = 2, BookId = 102, VotingSessionId = 1 },
            new() { Id = 3, UserId = 3, BookId = 103, VotingSessionId = 1 },

            // Voting Session 2 (Fantasy Fanatics - HostId = 2)
            new() { Id = 4, UserId = 2, BookId = 104, VotingSessionId = 2 }, // Host voting in their club
            new() { Id = 5, UserId = 4, BookId = 105, VotingSessionId = 2 },
            new() { Id = 6, UserId = 5, BookId = 106, VotingSessionId = 2 },

            // Voting Session 3 (Sci-Fi Society - HostId = 3)
            new() { Id = 7, UserId = 3, BookId = 107, VotingSessionId = 3 }, // Host voting in their club
            new() { Id = 8, UserId = 6, BookId = 108, VotingSessionId = 3 },

            // Voting Session 4 (Mystery Maniacs - HostId = 4)
            new() { Id = 9, UserId = 4, BookId = 109, VotingSessionId = 4 }, // Host voting in their club
            new() { Id = 10, UserId = 7, BookId = 110, VotingSessionId = 4 },

            // Voting Session 5 (Romance Readers - HostId = 5)
            new() { Id = 11, UserId = 5, BookId = 111, VotingSessionId = 5 }, // Host voting in their club
            new() { Id = 12, UserId = 8, BookId = 112, VotingSessionId = 5 },

            // Voting Session 6 (Historical Tales - HostId = 6)
            new() { Id = 13, UserId = 6, BookId = 113, VotingSessionId = 6 }, // Host voting in their club
            new() { Id = 14, UserId = 9, BookId = 114, VotingSessionId = 6 },

            // Voting Session 7 (Thriller Thursdays - HostId = 7)
            new() { Id = 15, UserId = 7, BookId = 115, VotingSessionId = 7 }, // Host voting in their club
            new() { Id = 16, UserId = 10, BookId = 116, VotingSessionId = 7 },

            // Voting Session 8 (Supernatural Circle - HostId = 8)
            new() { Id = 17, UserId = 8, BookId = 117, VotingSessionId = 8 }, // Host voting in their club
            new() { Id = 18, UserId = 11, BookId = 118, VotingSessionId = 8 },

            // Voting Session 9 (Slice of Life - HostId = 9)
            new() { Id = 19, UserId = 9, BookId = 119, VotingSessionId = 9 }, // Host voting in their club
            new() { Id = 20, UserId = 12, BookId = 120, VotingSessionId = 9 },

            // Voting Session 10 (Horror House - HostId = 10)
            new() { Id = 21, UserId = 10, BookId = 121, VotingSessionId = 10 }, // Host voting in their club
            new() { Id = 22, UserId = 13, BookId = 122, VotingSessionId = 10 }
        };

    }
}
