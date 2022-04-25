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
    public class SectorControllerTests
    {
        //private readonly IMapper _mapper;
        private readonly Mock<AppDbContext> _context;

        public SectorControllerTests()
        {
            _context = new Mock<AppDbContext>();            
        }

        [Fact]
        public async Task ShouldReturnOkActionResultAsync()
        {
            //Arrange
            var expectedRepositoryList = new List<SectorModel>()
            {
                new SectorModel() { Name = "Sector1" },
                new SectorModel() { Name = "Sector2" },
                new SectorModel() { Name = "Sector3" },
            };

            _context.Setup(x => x.GetAllSectors() )
                .Returns(expectedRepositoryList);

            var controller = new SectorController();

            //Act
            var result = controller.GetAllSectors( _context.Object );

            //Assert            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualList = Assert.IsType<List<SectorModel>>(okResult.Value);
            Assert.Equal(expectedRepositoryList, actualList, new SectorDtoEqualityComparer());
        }       
    }
}
