using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public VoteRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
        public async Task<Vote> CreateVote(Vote vote)
        {
            await dbContext.Votes.AddAsync(vote);
            await dbContext.SaveChangesAsync();
            return vote;
        }
        public async Task<VotingSession> GetSingleVotingSession(int votingSessionId)
        {
            var session = await dbContext.VotingSessions
                .Include(vs => vs.Votes)
                .Include(vs => vs.VotingBooks)
                .SingleOrDefaultAsync(vs => vs.Id == votingSessionId);
            
            return session;
        }


        public async Task<bool> VotingSessionExistsAsync(int votingSessionId)
        {
            return await dbContext.VotingSessions.AnyAsync(vs => vs.Id == votingSessionId);
        }
    }
}
