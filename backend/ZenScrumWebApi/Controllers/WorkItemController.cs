using Microsoft.AspNetCore.Mvc;
using ZenScrumWebApi.Dto;
using System.Threading.Tasks;
using AutoMapper;
using ZenScrumCore.Services;
using Domain;
using DataRepository;

namespace ZenScrumWebApi.Controllers
{
    [Route("api/[controller]")]
    public class WorkItemController : BaseController
    {
        private readonly IDataRepository<WorkItem> _repository;
        private readonly IMapper _mapper;

        public WorkItemController(IZenScrumService zenScrumService, IMapper mapper)
        {
            _repository = zenScrumService.WorkItemRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var workItems = _repository.GetObjects();

            var dtos = _mapper.Map<WorkItemDto[]>(workItems);

            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "WorkItemGet")]
        public async Task<IActionResult> Index(string id)
        {
            var workItem = _repository.GetObjectById(id);
            if (workItem == null)
                return NotFound(new {Message = $"Can't find workitem with {id}"});

            return Ok(_mapper.Map<WorkItemDto>(workItem));
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] WorkItemDto workItemDto)
        {
            var workItem = _mapper.Map<WorkItem>(workItemDto);
            _repository.Create(workItem);

            return Ok(_mapper.Map<WorkItemDto>(workItemDto));
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(string id)
        {
            _repository.Delete(id);

            return Ok(new {Message = "Work item was successfully removed!"});
        }

        [HttpPut("{id}")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] WorkItemDto workItemDto)
        {
            var oldWorkItem = _repository.GetObjectById(id);
            if (oldWorkItem == null)
                return NotFound(new {Message = $"Can't find project with {id}"});

            var updatedProject = _mapper.Map(workItemDto, oldWorkItem);
            
            _repository.Update(id, updatedProject);

            return Ok(_mapper.Map<WorkItemDto>(updatedProject));
        }
        
        //[HttpGet("search")]
        //public async Task<IActionResult> Search(string s)
        //{
        //    var foundProjects = _zenScrumService.SearchProject(s);

        //    return Ok(_mapper.Map<WorkItemDto>(foundProjects));
        //}
    }
}