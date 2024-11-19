using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Repositories
{
    public class UserService : IUserRepository
    {
        private readonly Bookworm_SocietyDbContext dbContext;

        public UserService(Bookworm_SocietyDbContext context)
        {
            dbContext = context;
        }
    }
}
