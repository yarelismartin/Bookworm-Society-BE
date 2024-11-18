using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Repositories
{
    public class CommentService : ICommentRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public CommentService(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
