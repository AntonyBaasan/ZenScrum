using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZenScrum.Services;
using ZenScrumWebApi.Dto;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            var projects = _zenScrumService.GetProjects();

            var projectDtos = projects.Select(p =>
            {
                return new ProjectDto {Id = p.Id, Name = p.Name, Details = p.Details, Moniker = p.Moniker};
            }).ToArray();

            return Ok(projectDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var project = _zenScrumService.GetProjectById(id);
            return Ok(new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Details = project.Details,
                Moniker = project.Moniker
            });
        }
    }
}