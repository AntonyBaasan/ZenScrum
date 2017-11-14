using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZenScrum.Services;
using ZenScrumWebApi.Dto;

namespace ZenScrumWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IZenScrumService _zenScrumService;

        public ProjectsController(IZenScrumService zenScrumService)
        {
            _zenScrumService = zenScrumService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var projects = _zenScrumService.GetProjects();

            var projectDtos = projects.Select(p =>
            {
                return new ProjectDto {Id = p.Id, Name = p.Name, Details = p.Details, Moniker = p.Moniker};
            }).ToArray();

            return Ok(projectDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            return Ok(new object[]
            {
                new {id = 1, name = "Antony", age = "33"}
            });
        }
    }
}