using Bookworm_Society_API.Data;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Repositories;
using Bookworm_Society_API.Result;
using System.Linq;

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
                Book = bookClub.Book != null ? new BookDTO(bookClub.Book) : null ,
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

            var createdBookClub = await _bookClubRepository.CreateBookClubAsync(newBookClub);
            Console.WriteLine($"Created BookClub: {createdBookClub?.Name}");
            return Result<BookClub>.SuccessResult(createdBookClub);
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
            return Result<BookClub>.SuccessResult(null);
        }
        public async Task<Result<object>> GetABookClubHaveReadAsync(int bookClubId)
        {
            var bookclub = await _bookClubRepository.GetABookClubHaveReadAsync(bookClubId);

            if (bookclub == null)
            {
                return Result<object>.FailureResult($"No book club was found with the following id: {bookClubId}", ErrorType.NotFound);
            };

            var bookObj = new
            {
                bookclub.Id,
                HaveRead = bookclub.HaveRead?.Select(hr => new BookDTO(hr)).ToList(),
            };

            return Result<object>.SuccessResult(bookObj);
        }
        public async Task<Result<object>> GetABookClubPostAsync(int bookClubId)
        {
            var bookclub = await _bookClubRepository.GetABookClubHavePostAsync(bookClubId);

            if (bookclub == null)
            {
                return Result<object>.FailureResult($"No book club was found with the following id: {bookClubId}", ErrorType.NotFound);
            };

            var bookObj = new
            {
                bookclub.Id,
                Posts = bookclub.Posts?
                .Select(p => new 
                {
                    p.Id, 
                    p.Content, 
                    p.CreatedDate, 
                    p.IsPinned,
                    p.IsEdited, 
                    User = new UserDTO(p.User),
                }).ToList(),
            };

            return Result<object>.SuccessResult(bookObj);

        }
        public async Task<Result<object>> AddUserToBookClubAsync(int bookClubId, int userId)
        {
            if (!await _baseRepository.UserExistsAsync(userId))
            {
                return Result<object>.FailureResult($"Not user was found with the following id: {userId}", ErrorType.NotFound);
            }

            if (!await _baseRepository.BookClubExistsAsync(bookClubId))
            {
                return Result<object>.FailureResult($"Not book club was found with the following id: {bookClubId}", ErrorType.NotFound);
            }



            var bookclub = await _bookClubRepository.GetBookClubWithMembersAsync(bookClubId);

            bool isMember = bookclub.Members?.Any(member => member.Id == userId) == true;
            bool isHost = bookclub.HostId == userId;

            if (isMember || isHost)
            {
                string message = isMember
                    ? "This user is already a member of this club."
                    : "This user is already the host of this club.";

                return Result<object>.FailureResult(message, ErrorType.Conflict);
            }

            var addMember = await _bookClubRepository.AddUserToBookClubAsync(bookclub, userId);

            var currentMembers = new
            {
                addMember.Id,
                Members = addMember.Members?.Select(m => new UserDTO(m)).ToList(),
            };

            return Result<object>.SuccessResult(currentMembers);

        }
        public async Task<Result<object>> RemoveUserFromBookClubAsync( int bookClubId, int userId)
        {
            if (!await _baseRepository.UserExistsAsync(userId))
            {
                return Result<object>.FailureResult($"Not user was found with the following id: {userId}", ErrorType.NotFound);
            }

            if (!await _baseRepository.BookClubExistsAsync(bookClubId))
            {
                return Result<object>.FailureResult($"Not book club was found with the following id: {bookClubId}", ErrorType.NotFound);
            }



            var bookclub = await _bookClubRepository.GetBookClubWithMembersAsync(bookClubId);

            if (bookclub.HostId == userId)
            {
                return Result<object>.FailureResult("The host cannot be removed from the book club.", ErrorType.Conflict);
            }

            if (bookclub.Members?.Any(member => member.Id == userId) == false)
            {
                return Result<object>.FailureResult($"This user is not a member of this club.", ErrorType.Conflict);
            }

            var addMember = await _bookClubRepository.RemoveUserFromBookClubAsync(bookclub, userId);

            var currentMembers = new
            {
                addMember.Id,
                Members = addMember.Members?.Select(m => new UserDTO(m)).ToList(),
            };

            return Result<object>.SuccessResult(currentMembers);
        }

    }
}
