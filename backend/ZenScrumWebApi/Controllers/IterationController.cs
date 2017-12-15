using Microsoft.AspNetCore.Mvc;
using ZenScrumWebApi.Dto;
using System.Threading.Tasks;
using AutoMapper;
using ZenScrumCore.Services;
using Domain;

namespace ZenScrumWebApi.Controllers
{
    [Route("api/[controller]")]
    public class IterationController : BaseController
    {
        private readonly IZenScrumService _zenScrumService;
        private readonly IMapper _mapper;

        public IterationController(IZenScrumService zenScrumService, IMapper mapper)
        {
            _zenScrumService = zenScrumService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var projects = _zenScrumService.ProjectRepository.GetObjects();

            var projectDtos = _mapper.Map<ProjectDto[]>(projects);

            return Ok(projectDtos);
        }

        [HttpGet("{id}", Name = "ProjectGet")]
        public async Task<IActionResult> Index(string id)
        {
            var project = _zenScrumService.ProjectRepository.GetObjectById(id);
            if (project == null)
                return NotFound(new {Message = $"Can't find project with {id}"});

            return Ok(_mapper.Map<ProjectDto>(project));
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _zenScrumService.ProjectRepository.Create(project);

            return Ok(_mapper.Map<ProjectDto>(project));
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(string id)
        {
            _zenScrumService.ProjectRepository.Delete(id);

            return Ok(new {Message = "Project was successfully removed!"});
        }

        [HttpPut("{id}")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProjectDto projectDto)
        {
            var oldProject = _zenScrumService.ProjectRepository.GetObjectById(id);
            if (oldProject == null)
                return NotFound(new {Message = $"Can't find project with {id}"});

            var updatedProject = _mapper.Map(projectDto, oldProject);
            
            _zenScrumService.ProjectRepository.Update(id, updatedProject);

            return Ok(_mapper.Map<ProjectDto>(updatedProject));
        }
        
        //[HttpGet("search")]
        //public async Task<IActionResult> Search(string s)
        //{
        //    var foundProjects = _zenScrumService.SearchProject(s);

        //    return Ok(_mapper.Map<ProjectDto>(foundProjects));
        //}
    }
}