//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;
//using KeyWorks.Api.Models;

//namespace KeyWorks.test.Controller
//{
//    public class StatusControllerTests
//    {
//        private readonly IMapper _mapper;
//        private readonly Mock<ICityRepository> _cityRepository;

//        public StatusControllerTests()
//        {
//            _cityRepository = new Mock<ICityRepository>();

//            var mockMapper = new MapperConfiguration(cfg =>
//            {
//                cfg.AddProfile(new StatusProfile());
//            });
//            _mapper = mockMapper.CreateMapper();
//        }

//        [Fact]
//        public async Task ShouldReturnOkActionResultAsync()
//        {
//            //Arrange
//            var expectedRepositoryList = new List<StatusModel>()
//            {
//                new StatusModel() { Name = "Florianópolis" },
//                new StatusModel() { Name = "Porto Alegre" },
//                new StatusModel() { Name = "Curitiba" },
//            };

//            _cityRepository.Setup(x => x.GetAllAsync())
//                .ReturnsAsync(expectedRepositoryList);

//            var controller = new CityController(
//                _mapper,
//                _cityRepository.Object);

//            //Act
//            var result = await controller.GetAllAsync();

//            //Assert
//            var actionResult = Assert.IsType<ActionResult<List<CityDto>>>(result);
//            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
//            var actualList = Assert.IsType<List<CityDto>>(okResult.Value);
//        }

//        [Fact]
//        public async Task ShouldReturnNoContentActionResultAsync()
//        {
//            //Arrange
//            var expectedRepositoryList = new List<City>();

//            _cityRepository.Setup(x => x.GetAllAsync())
//                .ReturnsAsync(expectedRepositoryList);

//            var controller = new CityController(
//                _mapper,
//                _cityRepository.Object);

//            //Act
//            var result = await controller.GetAllAsync();

//            //Assert
//            var actionResult = Assert.IsType<ActionResult<List<CityDto>>>(result);
//            Assert.IsType<NoContentResult>(actionResult.Result);
//        }

//        [Fact]
//        public async Task ShouldReturnExpectedResultDataAsync()
//        {
//            //Arrange
//            var expectedRepositoryList = new List<City>()
//            {
//                new City() { Name = "Florianópolis" },
//                new City() { Name = "Porto Alegre" },
//                new City() { Name = "Curitiba" },
//            };
//            var expectedList = expectedRepositoryList
//                .Select(x => new CityDto()
//                {
//                    Name = x.Name
//                }).ToList();

//            _cityRepository.Setup(x => x.GetAllAsync())
//                .ReturnsAsync(expectedRepositoryList);

//            var controller = new CityController(
//                _mapper,
//                _cityRepository.Object);

//            //Act
//            var result = await controller.GetAllAsync();

//            //Assert
//            var actionResult = Assert.IsType<ActionResult<List<CityDto>>>(result);
//            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
//            var actualList = Assert.IsType<List<CityDto>>(okResult.Value);
//            Assert.Equal(expectedList, actualList, new CityDtoEqualityComparer());
//        }
//    }
//}
