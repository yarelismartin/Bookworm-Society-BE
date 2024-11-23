using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Repositories;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Services
{
    public class BookClubService : IBookClubService
    {
        private readonly IBookClubRepository _bookClubRepository;
        private readonly IBaseRepository _baseRepository;

        public BookClubService(IBookClubRepository bookClubRepository, IBaseRepository baseRepository)
        {
            _bookClubRepository = bookClubRepository;
            _baseRepository = baseRepository;
        }

        public async Task<List<BookClubDTO>> GetBookClubsAsync()
        {
            var allBookClubs = await _bookClubRepository.GetBookClubsAsync();
            return allBookClubs.Select(bookClub => new BookClubDTO(bookClub)).ToList();
        }
        public async Task<Result<object?>> GetBookClubByIdAsync(int bookClubId, int userId)
        {
            if (!await _baseRepository.UserExistsAsync(userId))
            {
                return Result<object>.FailureResult($"No user was found with the following id: {userId}", ErrorType.NotFound);
            }

            var bookClub = await _bookClubRepository.GetBookClubByIdAsync(bookClubId);

           if (bookClub == null )
            {
                return Result<object>.FailureResult($"No book club was found with the following id: {bookClubId}", ErrorType.NotFound);
            }

            var dto = new
            {
                bookClub.Id,
                bookClub.Name,
                bookClub.Description,
                bookClub.MeetUpType,
                bookClub.ImageUrl,
                bookClub.DateCreated,
                Host = new UserDTO(bookClub.Host),
                Book = new BookDTO(bookClub.Book),
                Members = bookClub.Members?.Select(member => new UserDTO(member)).ToList(),
                isMemberOrHost = bookClub.Members.Any(m => m.Id == userId) || bookClub.Host.Id == userId,
            };

            return Result<object>.SuccessResult(dto);

        }
        public async Task<Result<BookClub>> CreateBookClubAsync(BookClub bookClub)
        {
            if(!await _baseRepository.UserExistsAsync(bookClub.HostId))
            {
                return Result<BookClub>.FailureResult($"No host was found with the following id: {bookClub.HostId}", ErrorType.NotFound);
            }


            BookClub newBookClub = new()
            {
                Name = bookClub.Name,
                MeetUpType = bookClub.MeetUpType,
                Description = bookClub.Description,
                ImageUrl = bookClub.ImageUrl,
                HostId = bookClub.HostId,
            };

            var createdBook = await _bookClubRepository.CreateBookClubAsync(newBookClub);

            return Result<BookClub>.SuccessResult(createdBook);
        }
        public async Task<Result<BookClub>> UpdateBookClubAsync(BookClub bookClub, int bookClubId)
        {
            if (!await _baseRepository.UserExistsAsync(bookClub.HostId))
            {
                return Result<BookClub>.FailureResult($"Not host was found with the following id: {bookClub.HostId}", ErrorType.NotFound);
            }

            var bookClubToUpdate = await _bookClubRepository.UpdateBookClubAsync(bookClub, bookClubId);

            if (bookClubToUpdate == null)
            {
                return Result<BookClub>.FailureResult($"No book club was found with the following id: {bookClubId}", ErrorType.NotFound);
            }
             
            return Result<BookClub>.SuccessResult(bookClubToUpdate);
        }
        public async Task<Result<BookClub>> DeleteBookClubAsync(int bookClubId)
        {
            var bookClubToDelete =  await _bookClubRepository.DeleteBookClubAsync(bookClubId);
            if(bookClubToDelete == null)
            {
                return Result<BookClub>.FailureResult($"No book club was found with the following id: {bookClubId}", ErrorType.NotFound);
            };
            return Result<BookClub>.SuccessResult(bookClubToDelete);
        }

    }
}
