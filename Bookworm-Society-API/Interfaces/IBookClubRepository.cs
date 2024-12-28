using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IBookClubRepository
    {
        Task<List<BookClub>> GetBookClubsAsync();
        Task<BookClub?> GetBookClubByIdAsync(int bookClubId);
        Task<BookClub> CreateBookClubAsync(BookClub bookClub);
        Task<BookClub> UpdateBookClubAsync(BookClub bookClub, int bookClubId);
        Task<BookClub> DeleteBookClubAsync(int bookClubId);
        Task<BookClub> GetABookClubHaveReadAsync(int bookClubId);
        Task<BookClub> GetABookClubPostsAsync(int bookClubId);
        Task<BookClub> AddUserToBookClubAsync(BookClub bookClub, int userId);
        Task<BookClub> RemoveUserFromBookClubAsync(BookClub bookClub, int userId);

        Task<BookClub?> GetBookClubWithMembersAsync(int bookClubId);
    }
}
