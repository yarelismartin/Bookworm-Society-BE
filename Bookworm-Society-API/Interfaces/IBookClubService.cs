using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface IBookClubService
    {
        Task<List<BookClubDTO>> GetBookClubsAsync();
        Task<BookClub?> GetBookClubByIdAsync(int bookClubId);
        Task<Result<BookClub>> CreateBookClubAsync(BookClub bookClub);
        Task<Result<BookClub>> UpdateBookClubAsync(BookClub bookClub, int bookClubId);
        Task<BookClub> DeleteBookClubAsync(int bookClubId);
    }
}
