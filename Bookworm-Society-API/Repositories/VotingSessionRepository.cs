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


            var activeVotingSession = bookclub.VotingSessions.FirstOrDefault(vs => vs.IsActive && vs.VotingEndDate >= DateTime.Now);

            return activeVotingSession;
            
        }

        public async Task<bool> IsUserAllowedToVote(int bookClubId, int userId)
        {
            var bookClub = await dbContext.BookClubs
                .Include(bc => bc.Members)
                .Include(bc => bc.Host)
                .SingleOrDefaultAsync(bc => bc.Id == bookClubId);

            bool isHost = bookClub.Host.Id == userId;
            bool isMember = bookClub.Members?.Any(m => m.Id == userId) == true;
            bool isAllowedToVote = isHost || isMember;

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
                .Include(vs => vs.VotingBooks)
                .Include(vs => vs.BookClub)
                    .ThenInclude(b => b.Book)
                .Include(vs => vs.BookClub)
                    .ThenInclude(bc => bc.HaveRead)

                // With query splitting (.AsSplitQuery()), EF Core generates multiple,
                // simpler queries that are more efficient and avoid duplicate rows, improving performance.
                .AsSplitQuery()
                .SingleOrDefaultAsync(vs => vs.Id == votingSessionId, cancellationToken);

            if (session.VotingEndDate <= DateTime.Now)
            {
                session.IsActive = false;

                if(session.BookClub.Book != null)
{
                    session.BookClub.HaveRead.Add(session.BookClub.Book);
                }

                if (!session.Votes.Any())
                {
                    session.WinningBookId = session.VotingBooks.First().Id;
                }

                else
                {
                    session.WinningBookId = await CalculateWinningBook(session.Votes);

                }

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

        public async Task<int> CalculateWinningBookAsync(List<Vote> votes)
        {
            // Step 2: Count votes for each book
            var bookVoteCounts = votes
                .GroupBy(vote => vote.BookId)
                .Select(group => new { BookId = group.Key, VoteCount = group.Count() })
                .ToList();

            // Step 3: Find the highest vote count
            var maxVoteCount = bookVoteCounts.Max(bvc => bvc.VoteCount);

            // Step 4: Find books with the highest vote 
            var tiedBooks = bookVoteCounts
                .Where(bvc => bvc.VoteCount == maxVoteCount)
                .Select(bvc => bvc.BookId)
                .ToList();

            // Step 5: If there is a tie, select a book randomly
            if (tiedBooks.Count > 1)
            {
                var random = new Random();
                var randomIndex = random.Next(tiedBooks.Count);
                return tiedBooks[randomIndex];
            }

            // Step 6: Return the book with the highest vote count (no tie)
            return tiedBooks.First();
        }
    }
}
