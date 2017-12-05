using Microsoft.AspNetCore.Mvc;
using ZenScrumWebApi.Dto;
using System.Threading.Tasks;
using AutoMapper;
using ZenScrumCore.Services;
using Domain;

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

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var projects = _zenScrumService.GetProjects();

            var projectDtos = _mapper.Map<ProjectDto[]>(projects);

            return Ok(projectDtos);
        }

        [HttpGet("{id}", Name = "ProjectGet")]
        public async Task<IActionResult> Index(string id)
        {
            var project = _zenScrumService.GetProjectById(id);
            if (project == null)
                return NotFound(new {Message = $"Can't find project with {id}"});

            return Ok(_mapper.Map<ProjectDto>(project));
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _zenScrumService.CreateProject(project);

            return Ok(_mapper.Map<ProjectDto>(project));
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(string id)
        {
            _zenScrumService.DeleteProject(id);

            return Ok(new {Message = "Project was successfully removed!"});
        }

        [HttpPut("{id}")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProjectDto projectDto)
        {
            var oldProject = _zenScrumService.GetProjectById(id);
            if (oldProject == null)
                return NotFound(new {Message = $"Can't find project with {id}"});

            var updatedProject = _mapper.Map(projectDto, oldProject);
            
            _zenScrumService.UpdateProject(id, updatedProject);

            return Ok(_mapper.Map<ProjectDto>(updatedProject));
        }
    }
}