using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Interfaces
{
    public interface IBaseRepository
    {
        Task<bool> UserExistsAsync(int userId);
        Task<bool> BookExistsAsync(int bookId);
        Task<bool> BookClubExistsAsync(int bookClubId);
        Task<BookClub?> GetSingleBookClubAsync(int bookClubId);
    }
}
