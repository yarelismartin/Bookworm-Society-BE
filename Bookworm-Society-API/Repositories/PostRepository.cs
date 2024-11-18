using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Repositories
{
    public class PostService : IPostRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;
        public PostService(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
