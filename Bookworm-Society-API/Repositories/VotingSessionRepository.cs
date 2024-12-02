using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Repositories
{
    public class VotingSessionRepository : IVotingSessionRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public VotingSessionRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }

        public async Task<VotingSession> GetLatestVotingSessionAsync(int bookClubId, int userId)
        {
            var bookclub = await dbContext.BookClubs
                .Include(bc => bc.VotingSessions)
                    .ThenInclude(vs => vs.VotingBooks)
                .Include(bc => bc.VotingSessions)
                    .ThenInclude(vs => vs.Votes)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);

            if (bookclub == null || !bookclub.VotingSessions.Any())
                return null;


            var activeVotingSessions = bookclub.VotingSessions.FirstOrDefault(vs => vs.IsActive && vs.VotingEndDate >= DateTime.Now);
            return activeVotingSessions;
            
        }

        public async Task<bool> IsUserAllowedToVote(int bookClubId, int userId)
        {
            var bookClub = await dbContext.BookClubs
                .Include(bc => bc.Members)
                .Include(bc => bc.Host)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);

            bool isHost = bookClub.Host.Id == userId;
            bool isMember = bookClub.Members?.Any(m => m.Id == userId) == true;

            return isHost || isMember;
        }

        public async Task<VotingSession> CreateVotingSession(int userId, int bookClubId, List<int> bookIds)
        {
            throw new NotImplementedException();
        }
    }
}
