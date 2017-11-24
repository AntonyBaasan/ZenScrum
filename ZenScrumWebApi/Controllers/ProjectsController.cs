using Microsoft.AspNetCore.Mvc;
using ZenScrumWebApi.Dto;
using System.Threading.Tasks;
using AutoMapper;
using ZenScrumCore.Services;

namespace ZenScrumWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : BaseController
    {
        private readonly IZenScrumService _zenScrumService;
        private readonly IMapper _mapper;

        public ProjectsController(IZenScrumService zenScrumService, IMapper mapper)
        {
            _zenScrumService = zenScrumService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var projects = _zenScrumService.GetProjects();

            var projectDtos = _mapper.Map<ProjectDto[]>(projects);

            return Ok(projectDtos);
        }

        [HttpGet("{id}", Name = "ProjectGet")]
        public async Task<IActionResult> Index(int id)
        {
            var project = _zenScrumService.GetProjectById(id);
            return Ok(_mapper.Map<ProjectDto>(project));
        }
    }
}