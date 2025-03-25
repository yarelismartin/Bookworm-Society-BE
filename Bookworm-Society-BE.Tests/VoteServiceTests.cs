using Bookworm_Society_API.Interfaces;
using Bookworm_Society_API.Services;
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
        private readonly Mock<IBaseRepository> _baseRepository;

        public VoteServiceTests()
        {
            _mockVoteRepository = new Mock<IVoteRepository>();
            _baseRepository = new Mock<IBaseRepository>();
            _voteService = new VoteService(_mockVoteRepository.Object, _baseRepository.Object);

        }

        //create vote 

        //get single vote 

        //voting session exist 
    }
}
