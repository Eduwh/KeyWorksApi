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
    public class StatusControllerTests
    {
        //private readonly IMapper _mapper;
        private readonly Mock<AppDbContext> _context;

        public StatusControllerTests()
        {
            _context = new Mock<AppDbContext>();            
        }

        [Fact]
        public async Task ShouldReturnOkActionResultAsync()
        {
            //Arrange
            var expectedRepositoryList = new List<StatusModel>()
            {
                new StatusModel() { Name = "Status1" },
                new StatusModel() { Name = "Status2" },
                new StatusModel() { Name = "Status3" },
            };

            _context.Setup(x => x.GetAllStatus() )
                .Returns(expectedRepositoryList);

            var controller = new StatusController();

            //Act
            var result = controller.GetAllStatus( _context.Object );

            //Assert            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualList = Assert.IsType<List<StatusModel>>(okResult.Value);
            Assert.Equal(expectedRepositoryList, actualList, new StatusDtoEqualityComparer());
        }       
    }
}
