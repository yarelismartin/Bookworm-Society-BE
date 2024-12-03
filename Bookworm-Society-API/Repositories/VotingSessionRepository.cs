using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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

        public async Task<VotingSession> CreateVotingSession(VotingSession votingSession)
        {
            await dbContext.VotingSessions.AddAsync(votingSession);
            await dbContext.SaveChangesAsync();
            return votingSession;
        }

        public async Task<List<Book>> GetBooksByIdsAsync(List<int> bookIds)
        {
            var books = await dbContext.Books
                .Where(b => bookIds.Contains(b.Id))
                .ToListAsync();

            return books;
        }

        public async Task<List<VotingSession>> GetActiveVotingSessions(CancellationToken cancellationToken)
        {
            return await dbContext.VotingSessions
                .Include(vs => vs.BookClub)
                .Where(vs => vs.IsActive == true).ToListAsync(cancellationToken);
        }


        public async Task FinalizeVotingSessionAsync(int votingSessionId, CancellationToken cancellationToken)
        {
            var session = await dbContext.VotingSessions
                .Include(vs => vs.Votes)
                .Include(vs => vs.BookClub)
                    .ThenInclude(b => b.Book)
                .Include(vs => vs.BookClub)
                    .ThenInclude(bc => bc.HaveRead)
                .SingleOrDefaultAsync(vs => vs.Id == votingSessionId, cancellationToken);

            if (session.VotingEndDate <= DateTime.UtcNow)
            {
                session.IsActive = false;

                if(session.BookClub.Book != null)
{
                    session.BookClub.HaveRead.Add(session.BookClub.Book);
                }

                session.WinningBookId = await CalculateWinningBook(session.Votes);

                session.BookClub.BookId = session.WinningBookId;

                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task<int> CalculateWinningBook(List<Vote> votes)
        {
            return votes.GroupBy(v => v.BookId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

        }

    }
}
