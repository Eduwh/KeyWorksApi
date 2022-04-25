using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using KeyWorks.Api.Models;
using KeyWorks.Api.Controllers;
using KeyWorks.Api.Data;
using KeyWork.test.Dtos;

namespace KeyWorks.test.Controller
{
    public class TeamControllerTests
    {
        //private readonly IMapper _mapper;
        private readonly Mock<AppDbContext> _context;

        public TeamControllerTests()
        {
            _context = new Mock<AppDbContext>();            
        }

        [Fact]
        public async Task ShouldReturnOkActionResultAsync()
        {
            //Arrange
            var expectedRepositoryList = new List<TeamModel>()
            {
                new TeamModel() { Name = "Team1" },
                new TeamModel() { Name = "Team2" },
                new TeamModel() { Name = "Team3" },
            };

            _context.Setup(x => x.GetAllTeams() )
                .Returns(expectedRepositoryList);

            var controller = new TeamController();

            //Act
            var result = controller.GetAllTeams( _context.Object );

            //Assert            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualList = Assert.IsType<List<TeamModel>>(okResult.Value);
            Assert.Equal(expectedRepositoryList, actualList, new TeamDtoEqualityComparer());
        }       
    }
}
