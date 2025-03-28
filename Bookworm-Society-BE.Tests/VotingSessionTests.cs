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
            //object being returned from service method 
            var serviceReturn = new
            {
                Id = 2,
                IsActive = true,
                VotingStartDate = DateTime.Now,
                VotingEndDate = DateTime.Now,
                HasUserVotes = true,
                VotingBooks = new List<object>()
            };
            //repo returns a voting session 
            var repoReturn = new VotingSession
            {
                Id = 2,
                IsActive = true,
                VotingStartDate = DateTime.Now,
                VotingEndDate = DateTime.Now,
                VotingBooks = new List<Book>()

                };
            //two varibles to pass to service methood, club id and user id 
            int bookClubId = 3;
            int userId = 2;
            //get latest voting session
            _mockVotingSession.Setup(repo => repo.GetLatestVotingSessionAsync(bookClubId, userId)).ReturnsAsync(repoReturn);
                //user exist 
                _mockBaseRepository.Setup(repo=> repo.UserExistsAsync(userId)).ReturnsAsync(true);
                //book exist 
                _mockBaseRepository.Setup(repo => repo.BookExistsAsync(bookClubId)).ReturnsAsync(true);
                // is user allowed to vote 
                _mockVotingSession.Setup(repo => repo.IsUserAllowedToVote(bookClubId, userId)).ReturnsAsync(true);
            //ACT
            var result = await _votingSessionService.GetLatestVotingSessionAsync(bookClubId, userId);
            //ASSERT
            result.Should().NotBeNull();
            result.Data.Should().BeEquivalentTo(serviceReturn);
                
        }

        [Fact]
        public async Task CreateVotingSession_ReturnsCreatedVotingSession_WhenInputsValid()
        {

        }

    }
}
