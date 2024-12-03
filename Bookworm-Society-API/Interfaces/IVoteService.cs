using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IVoteService
    {
        Task<Result<Vote>> CreateVote(CreateVoteDTO voteDTO);
    }
}
