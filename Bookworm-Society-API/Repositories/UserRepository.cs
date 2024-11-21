using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public UserRepository(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
