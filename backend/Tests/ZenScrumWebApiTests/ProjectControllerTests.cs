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
using DataRepository;

namespace ZenScrumWebApiTests
{
    public class ProjectControllerTests
    {
        private IMapper mapper;
        private IZenScrumService fakeZenScrumService;
        private Mock<IDataRepository<Project>> mockProjectRepository;

        public ProjectControllerTests()
        {
            mapper = CreateMapper();
            mockProjectRepository = new Mock<IDataRepository<Project>>();

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
            mockProjectRepository.Setup(m => m.GetObjectById(objectId)).Returns(new Project { Id = ObjectId.Parse(objectId) });
            fakeZenScrumService = new ZenScrumService(mockProjectRepository.Object, null);
            var controller = new ProjectsController(fakeZenScrumService, mapper);

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
            mockProjectRepository.Setup(m => m.GetObjectById(objectId)).Returns<Project>(null);
            fakeZenScrumService = new ZenScrumService(mockProjectRepository.Object, null);
            var controller = new ProjectsController(fakeZenScrumService, mapper);

            // Act
            var result = controller.Index(objectId);


            // Assert
            Assert.IsType(typeof(NotFoundObjectResult), result.Result);
        }

        [Fact]
        public void Index_NoParam_ReturnsAllProjecs()
        {
            // Arrange
            mockProjectRepository.Setup(m => m.GetObjects()).Returns(MockUtils.GetMockProjects());
            fakeZenScrumService = new ZenScrumService(mockProjectRepository.Object, null);
            var controller = new ProjectsController(fakeZenScrumService, mapper);

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
            mockProjectRepository.Setup(m => m.Delete("1"));
            fakeZenScrumService = new ZenScrumService(mockProjectRepository.Object, null);
            var controller = new ProjectsController(fakeZenScrumService, mapper);

            // Act
            var result = controller.Delete("1");
            var okResult = (OkObjectResult)result.Result;

            // Assert
            mockProjectRepository.Verify(s => s.Delete("1"), Times.Once);
        }

        [Fact]
        public void Update_ShouldCallService()
        {
            var Id = ObjectId.GenerateNewId();
            var oldProject = new Project { Id = Id, Name = "Name1" };
            var newProjectDto = new ProjectDto { Id = Id.ToString(), Name = "Name2" };
            // Arrange
            mockProjectRepository.Setup(m => m.GetObjectById(Id.ToString())).Returns(oldProject);
            mockProjectRepository.Setup(m => m.Update(Id.ToString(), It.IsAny<Project>()));
            fakeZenScrumService = new ZenScrumService(mockProjectRepository.Object, null);
            var controller = new ProjectsController(fakeZenScrumService, mapper);

            // Act
            var result = controller.Update(Id.ToString(), newProjectDto);
            var okResult = (OkObjectResult)result.Result;

            // Assert
            var p = (ProjectDto)okResult.Value;
            Assert.Equal(Id.ToString(), p.Id.ToString());
        }

    }
}