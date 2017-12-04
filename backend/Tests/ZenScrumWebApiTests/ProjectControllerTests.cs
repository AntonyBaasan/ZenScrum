using AutoMapper;
using Domain;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ZenScrum.Utilities;
using ZenScrumWebApi.Controllers;
using ZenScrumWebApi.Dto;
using ZenScrumWebApi.MapperConfig;
using ZenScrumCore.Services;
using MongoDB.Bson;

namespace ZenScrumWebApiTests
{
    public class ProjectControllerTests
    {
        private IMapper mapper;
        private Mock<IZenScrumService> mockZenScrumService;
        
        public ProjectControllerTests()
        {
            mapper = CreateMapper();
            mockZenScrumService = new Mock<IZenScrumService>();
        }

        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<ProjectMapperProfile>(); });
            return new Mapper(config);
        }

        [Fact]
        public void Index_GetProjectById()
        {
            // Arrange
            mockZenScrumService.Setup(m => m.GetProjectById("2")).Returns(new Project {Id = ObjectId.Parse("2")});
            var controller = new ProjectsController(mockZenScrumService.Object, mapper);

            // Act
            var result = controller.Index("2");
            var okResult = (OkObjectResult) result.Result;

            // Assert
            var p = (ProjectDto) okResult.Value;
            Assert.Equal(p.Id.ToString(), "2");
        }

        [Fact]
        public void Index_ReturnsProjectModels()
        {
            // Arrange
            mockZenScrumService.Setup(m => m.GetProjects()).Returns(MockUtils.GetMockProjects());
            var controller = new ProjectsController(mockZenScrumService.Object, mapper);

            // Act
            var result = controller.Index();
            var okResult = (OkObjectResult) result.Result;

            // Assert
            var arr = (ProjectDto[]) okResult.Value;
            Assert.Equal(arr.Length, 3);
        }

        [Fact]
        public void ProjectController_DeletesProject_ById()
        {
            // Arrange
            mockZenScrumService.Setup(m => m.DeleteProject("1"));
            var controller = new ProjectsController(mockZenScrumService.Object, mapper);

            // Act
            var result = controller.Delete("1");
            var okResult = (OkObjectResult) result.Result;

            // Assert
            mockZenScrumService.Verify(s=>s.DeleteProject("1"), Times.Once);
        }

        [Fact]
        public void Dump_Test()
        {
            Assert.Equal(3, 3);
        }
    }
}