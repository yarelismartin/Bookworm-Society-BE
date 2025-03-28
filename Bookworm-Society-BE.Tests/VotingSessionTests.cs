using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;
using Bookworm_Society_API.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm_Society_BE.Tests
{
    public class VotingSessionTests
    {
        private readonly VotingSessionService _votingSessionService;
        private readonly Mock<IVotingSessionRepository> _mockVotingSession;
        private readonly Mock<IBaseRepository> _mockBaseRepository;

        public VotingSessionTests()
        {
            _mockVotingSession = new Mock<IVotingSessionRepository>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            _votingSessionService = new VotingSessionService(_mockVotingSession.Object, _mockBaseRepository.Object);
        }

        [Fact]
        public async Task GetBookClubLatestVotingSession_ReturnsVotingSession_WhenBookClubExist()
        {
            //ARANGE
            //two varibles to pass to service methood, club id and user id 
            int bookClubId = 3;
            int userId = 2;


            //repo returns a voting session 
            var repoReturn = new VotingSession
            {
                Id = 2,
                IsActive = true,
                VotingStartDate = DateTime.Now,
                VotingEndDate = DateTime.Now,
                BookClubId = bookClubId,
                VotingBooks = new List<Book>
                {
                    new Book
                    {
                        Id = 1,
                        Title = "Book Title",
                        Description = "Some Description",
                        Author = new Author { FirstName = "John", LastName = "Doe" },
                        Genre = new Genre { Name = "Fiction" },
                        ImageUrl = "http://example.com/image.jpg"
                    }
                },
                Votes = new List<Vote>
                    {
                        new Vote { UserId = userId, BookId = 1 },
                        new Vote { UserId = 3, BookId = 1 },
                        new Vote { UserId = 4, BookId = 1 },
                        new Vote { UserId = 5, BookId = 1 },
                        new Vote { UserId = 6, BookId = 1 }
                    }

            };

            //object being returned from service method 
            var serviceReturn = new
            {
                Id = 2,
                IsActive = true,
                VotingStartDate = repoReturn.VotingStartDate,
                VotingEndDate = repoReturn.VotingEndDate,
                HasUserVoted = true,
                VotingBooks = new List<object>
                    {
                        new
                        {
                            Id = 1,
                            Title = "Book Title",
                            Description = "Some Description",
                            Author = "John Doe",
                            Genre = "Fiction",
                            ImageUrl = "http://example.com/image.jpg",
                            TotalVotes = 5
                        }
                    }
            };

            _mockVotingSession.Setup(repo => repo.GetLatestVotingSessionAsync(bookClubId, userId)).ReturnsAsync(repoReturn);
            _mockBaseRepository.Setup(repo=> repo.UserExistsAsync(userId)).ReturnsAsync(true);
            _mockBaseRepository.Setup(repo => repo.BookClubExistsAsync(bookClubId)).ReturnsAsync(true);
            _mockVotingSession.Setup(repo => repo.IsUserAllowedToVote(bookClubId, userId)).ReturnsAsync(true);

            //ACT
            var result = await _votingSessionService.GetLatestVotingSessionAsync(bookClubId, userId);

            //ASSERT
            result.Should().NotBeNull();
            result.Data.Should().BeEquivalentTo(serviceReturn);

            /*result.Data.Should().BeEquivalentTo(serviceReturn, options =>
        options.Excluding(ctx => ctx.VotingStartDate)
               .Excluding(ctx => ctx.VotingEndDate) // Exclude DateTime to prevent precision issues
    );*/

        }

        [Fact]
        public async Task CreateVotingSession_ReturnsCreatedVotingSession_WhenInputsValid()
        {
            //ARRANGE 
           int userId = 1;
            int bookClub = 2;
            DateTime fixedNow = DateTime.Now;
            var serviceDTO = new CreateVotingSessionDTO
            {
                VotingEndDate = fixedNow.AddDays(3),
                BookClubId = bookClub,
                BookIds = new List<int> { 102, 103, 104 }
            };
            //passing to main repo method
            var passingRepo = new VotingSession
            {
                BookClubId = serviceDTO.BookClubId,
                VotingEndDate = serviceDTO.VotingEndDate,
                IsActive = true,
                VotingBooks = new List<Book>
                {
                    new()
                    {
                        Id = 102
                    },
                    new()
                    {
                        Id = 103
                    },
                    new()
                    {
                        Id = 104
                    }
                },
            };

            //REPORETURN VOTING SESSION
            var repoReturn = new VotingSession
            {
                Id = 2,
                IsActive = passingRepo.IsActive,
                VotingStartDate = fixedNow,
                VotingEndDate = passingRepo.VotingEndDate,
                WinningBookId = null,
                BookClubId = bookClub,
                VotingBooks = passingRepo.VotingBooks
            };

            var expectedReturn = new VotingSession
            {
                Id = repoReturn.Id,
                BookClubId = repoReturn.BookClubId,
                VotingStartDate = repoReturn.VotingStartDate,
                VotingEndDate = repoReturn.VotingEndDate,
                IsActive = repoReturn.IsActive,
                VotingBooks = repoReturn.VotingBooks,
                WinningBookId = repoReturn.WinningBookId,
                Votes = new List<Vote>()
            };

            //GETSINGLEBOOKCLUB
            BookClub singleClub = new()
            {
                Id = bookClub,
                HostId = userId
            };


            //MOCK
            //GET SINGLE BOOK CLUB RETURNS BOOKCLUB (hOSTiD SAME AS USERID)
            _mockBaseRepository.Setup(repo => repo.GetSingleBookClubAsync(bookClub)).ReturnsAsync(singleClub);
            // GET BOOK BY ID RETURNS SAME BOOK LIST AS DTO 
            _mockVotingSession.Setup(repo => repo.GetBooksByIdsAsync(serviceDTO.BookIds)).ReturnsAsync(repoReturn.VotingBooks);
            //CREATEVOTINGSESSION RETURNS REPO RETURNED 
            _mockVotingSession.Setup(repo => repo.CreateVotingSession(passingRepo)).ReturnsAsync(repoReturn);

            //ACT
            var result = await _votingSessionService.CreateVotingSession(serviceDTO, userId);
            //ASSERT
            result.Should().NotBeNull();    
            result.Data.Should().BeEquivalentTo(passingRepo, option => option.Excluding(ctx => ctx.VotingStartDate));
        }

    }
}
