using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;

        public VoteService(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }
    }
}
