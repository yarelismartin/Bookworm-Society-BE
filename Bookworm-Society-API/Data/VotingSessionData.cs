using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class VotingSessionData
    {
        public static List<VotingSession> VotingSessions = new()
            {
                new() {
                    Id = 1,
                    IsActive = true,
                    VotingStartDate = new DateTime(2023, 11, 14),
                    VotingEndDate = new DateTime(2023, 11, 18),
                    BookClubId = 1,
                    WinningBookId = null
                },
                new() {
                    Id = 2,
                    IsActive = true,
                    VotingStartDate = new DateTime(2023, 11, 15),
                    VotingEndDate = new DateTime(2023, 11, 19),
                    BookClubId = 2,
                    WinningBookId = null
                },
                new() {
                    Id = 3,
                    IsActive = false,
                    VotingStartDate = new DateTime(2023, 11, 1),
                    VotingEndDate = new DateTime(2023, 11, 4),
                    WinningBookId = 107,
                    BookClubId = 3
                },
                new() {
                    Id = 4,
                    IsActive = true,
                    VotingStartDate = new DateTime(2023, 11, 16),
                    VotingEndDate = new DateTime(2023, 11, 20),
                    BookClubId = 4,
                    WinningBookId = null
                },
                new() {
                    Id = 5,
                    IsActive = false,
                    VotingStartDate = new DateTime(2023, 10, 25),
                    VotingEndDate = new DateTime(2023, 10, 29),
                    WinningBookId = 113,
                    BookClubId = 5
                },
                new() {
                    Id = 6,
                    IsActive = true,
                    VotingStartDate = new DateTime(2023, 11, 18),
                    VotingEndDate = new DateTime(2023, 11, 22),
                    BookClubId = 6,
                    WinningBookId = null
                }
            };

    }
}
