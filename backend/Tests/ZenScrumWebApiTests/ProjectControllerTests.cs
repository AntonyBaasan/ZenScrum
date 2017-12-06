using System;
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
        public void Index_GetProjectById_Sucess()
        {
            var objectId = ObjectId.GenerateNewId().ToString();
            // Arrange
            mockZenScrumService.Setup(m => m.GetProjectById(objectId))
                .Returns(new Project { Id = ObjectId.Parse(objectId) });
            var controller = new ProjectsController(mockZenScrumService.Object, mapper);

            // Act
            var result = controller.Index(objectId);
            var okResult = (OkObjectResult)result.Result;

            // Assert
            var p = (ProjectDto)okResult.Value;
            Assert.Equal(objectId, p.Id.ToString());
        }

        [Fact]
        public void Index_GetProjectByWrongId_NotFoundResult()
        {
            var objectId = ObjectId.GenerateNewId().ToString();
            // Arrange
            mockZenScrumService.Setup(m => m.GetProjectById(objectId)).Returns<Project>(null);
            var controller = new ProjectsController(mockZenScrumService.Object, mapper);

            // Act
            var result = controller.Index(objectId);


            // Assert
            Assert.IsType(typeof(NotFoundObjectResult), result.Result);
        }

        [Fact]
        public void Index_NoParam_ReturnsAllProjecs()
        {
            // Arrange
            mockZenScrumService.Setup(m => m.GetProjects()).Returns(MockUtils.GetMockProjects());
            var controller = new ProjectsController(mockZenScrumService.Object, mapper);

            // Act
            var result = controller.Index();
            var okResult = (OkObjectResult)result.Result;

            // Assert
            var arr = (ProjectDto[])okResult.Value;
            Assert.Equal(3, arr.Length);
        }

        [Fact]
        public void Delete_ById_ShouldCallService()
        {
            // Arrange
            mockZenScrumService.Setup(m => m.DeleteProject("1"));
            var controller = new ProjectsController(mockZenScrumService.Object, mapper);

            // Act
            var result = controller.Delete("1");
            var okResult = (OkObjectResult)result.Result;

            // Assert
            mockZenScrumService.Verify(s => s.DeleteProject("1"), Times.Once);
        }

        [Fact]
        public void Update_ShouldCallService()
        {
            var Id = ObjectId.GenerateNewId();
            var oldProject = new Project { Id = Id, Name = "Name1" };
            var newProjectDto = new ProjectDto { Id = Id.ToString(), Name = "Name2" };
            // Arrange
            mockZenScrumService.Setup(m => m.GetProjectById(Id.ToString())).Returns(oldProject);
            mockZenScrumService.Setup(m => m.UpdateProject(Id.ToString(), It.IsAny<Project>()));
            var controller = new ProjectsController(mockZenScrumService.Object, mapper);

            // Act
            var result = controller.Update(Id.ToString(), newProjectDto);
            var okResult = (OkObjectResult)result.Result;

            // Assert
            var p = (ProjectDto)okResult.Value;
            Assert.Equal(Id.ToString(), p.Id.ToString());
        }

    }
}