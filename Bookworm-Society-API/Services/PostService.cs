using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
    }
}
