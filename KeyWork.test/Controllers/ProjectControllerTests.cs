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
    public class ProjectControllerTests
    {
        //private readonly IMapper _mapper;
        private readonly Mock<AppDbContext> _context;

        public ProjectControllerTests()
        {
            _context = new Mock<AppDbContext>();            
        }

        [Fact]
        public async Task ShouldReturnOkActionResultAsync()
        {
            //Arrange
            var expectedRepositoryList = new List<ProjectModel>()
            {
                new ProjectModel() { Name = "Project1" },
                new ProjectModel() { Name = "Project2" },
                new ProjectModel() { Name = "Project3" },
            };

            _context.Setup(x => x.GetAllProjects() )
                .Returns(expectedRepositoryList);

            var controller = new ProjectController();

            //Act
            var result = controller.GetAllProjects( _context.Object );

            //Assert            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualList = Assert.IsType<List<ProjectModel>>(okResult.Value);
            Assert.Equal(expectedRepositoryList, actualList, new ProjectDtoEqualityComparer());
        }       
    }
}
