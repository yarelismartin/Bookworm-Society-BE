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

            //object being returned from service method 
            var serviceReturn = new
            {
                Id = 2,
                IsActive = true,
                VotingStartDate = DateTime.Now,
                VotingEndDate = DateTime.Now,
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


            _mockVotingSession.Setup(repo => repo.GetLatestVotingSessionAsync(bookClubId, userId)).ReturnsAsync(repoReturn);
            _mockBaseRepository.Setup(repo=> repo.UserExistsAsync(userId)).ReturnsAsync(true);
            _mockBaseRepository.Setup(repo => repo.BookClubExistsAsync(bookClubId)).ReturnsAsync(true);
            _mockVotingSession.Setup(repo => repo.IsUserAllowedToVote(bookClubId, userId)).ReturnsAsync(true);

            //ACT
            var result = await _votingSessionService.GetLatestVotingSessionAsync(bookClubId, userId);

            //ASSERT
            result.Should().NotBeNull();
            result.Data.Should().BeEquivalentTo(serviceReturn, options =>
                    options.Excluding(ctx => ctx.VotingStartDate)
                           .Excluding(ctx => ctx.VotingEndDate) // Exclude DateTime to prevent precision issues
                );
        }

        [Fact]
        public async Task CreateVotingSession_ReturnsCreatedVotingSession_WhenInputsValid()
        {

        }

    }
}
