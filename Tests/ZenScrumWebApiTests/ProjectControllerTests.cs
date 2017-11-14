using System;
using Domain;
using Xunit;
using Moq;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZenScrum.Services;
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
            mockZenScrumService.Setup(m => m.GetProjects())
                .Returns(new Project[] {new Project(), new Project(), new Project()});
            var controller = new ProjectsController(mockZenScrumService.Object);

            // Act
            IActionResult result = controller.Index();
            var okResult = (OkObjectResult) result;

            // Assert
            Assert.Equal(okResult.StatusCode, 200);
            var arr = (ProjectDto[])okResult.Value;
            Assert.Equal(arr.Length, 3);
        }
    }
}