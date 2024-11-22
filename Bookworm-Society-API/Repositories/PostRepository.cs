using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;
        public PostRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
