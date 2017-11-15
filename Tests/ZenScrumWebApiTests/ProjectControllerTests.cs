using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ZenScrum.Services;
using ZenScrum.Utilities;
using ZenScrumWebApi.Controllers;
using ZenScrumWebApi.Dto;

namespace ZenScrumWebApiTests
{
    public class ProjectControllerTests
    {
        [Fact]
        public void Index_ReturnsProjectModels()
        {
            // Arrange
            var mockZenScrumService = new Mock<IZenScrumService>();
            mockZenScrumService.Setup(m => m.GetProjects()).Returns(MockUtils.GetMockProjects());
            var controller = new ProjectsController(mockZenScrumService.Object);

            // Act
            var result = controller.Index();
            var okResult = (OkObjectResult) result.Result;

            // Assert
            Assert.Equal(okResult.StatusCode, 200);
            var arr = (ProjectDto[])okResult.Value;
            Assert.Equal(arr.Length, 3);
        }

        [Fact]
        public void Dump_Test()
        {
            Assert.Equal(3, 3);
        }

    }
}