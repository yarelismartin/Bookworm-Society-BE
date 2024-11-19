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

        };

    }
}
