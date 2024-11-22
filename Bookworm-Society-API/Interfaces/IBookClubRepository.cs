using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Interfaces
{
    public interface IBookClubRepository
    {
        Task<List<BookClub>> GetBookClubsAsync();
        Task<BookClub?> GetBookClubByIdAsync(int bookClubId);
        Task<BookClub> CreateBookClubAsync(BookClub bookClub);
        Task<BookClub> UpdateBookClubAsync(BookClub bookClub, int bookClubId);
        Task<BookClub> DeleteBookClubAsync(int bookClubId);
    }
}
