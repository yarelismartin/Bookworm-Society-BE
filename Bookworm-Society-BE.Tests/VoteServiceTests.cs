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
    public class VoteServiceTests
    {
        private readonly VoteService _voteService;
        private readonly Mock<IVoteRepository> _mockVoteRepository;
        private readonly Mock<IBaseRepository> _mockBaseRepository;

        public VoteServiceTests()
        {
            _mockVoteRepository = new Mock<IVoteRepository>();
            _mockBaseRepository = new Mock<IBaseRepository>();
            _voteService = new VoteService(_mockVoteRepository.Object, _mockBaseRepository.Object);

        }

        //create vote
        [Fact]
        public async Task CreateAVote_ShouldReturnCreatedVote_WhenVoteIsSuccessful()
        {
            //Arrange
            // Expected return from service
            var expectedVote = new
            {
                Id = 3,
                UserId = 1,
                BookId = 4,
                VotingSessionId = 4
            };

            // What the repository will return when CreateVote is called
            var returnedRepository = new Vote
            {
                Id = 3,
                UserId = 1,
                BookId = 4,
                VotingSessionId = 4
            };

            // Input DTO
            var voteDTO = new CreateVoteDTO
            {
                UserId = 1,
                BookId = 4,
                VotingSessionId = 4
            };

            // Mock voting session with required books
            var votingSession = new VotingSession
            {
                Id = 2,
                Votes = new List<Vote>(),
                VotingBooks = new List<Book> { new() { Id = voteDTO.BookId } }
            };

            //Mock
            _mockVoteRepository.Setup(repo => repo.CreateVote(It.IsAny<Vote>())).ReturnsAsync(returnedRepository);
            _mockBaseRepository.Setup(repo => repo.UserExistsAsync(voteDTO.UserId)).ReturnsAsync(true);
            _mockBaseRepository.Setup(repo => repo.BookExistsAsync(voteDTO.BookId)).ReturnsAsync(true);
            _mockVoteRepository.Setup(repo => repo.GetSingleVotingSession(voteDTO.VotingSessionId)).ReturnsAsync(votingSession);

            //Act 
               var result = await _voteService.CreateVote(voteDTO);
            //Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(expectedVote);

        }
    }
}
