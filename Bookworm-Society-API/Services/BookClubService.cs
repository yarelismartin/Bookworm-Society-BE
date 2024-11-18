using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;

namespace Bookworm_Society_API.Services
{
    public class BookClubService : IBookClubService
    {
        private readonly IBookClubRepository _bookClubRepository;

        public BookClubService(IBookClubRepository bookClubRepository)
        {
            _bookClubRepository = bookClubRepository;
        }
    }
}
