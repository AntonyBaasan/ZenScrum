using Microsoft.AspNetCore.Mvc;

namespace ZenScrumWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok(new object[]
            {
                new {id = 1, name = "Antony", age = "33"},
                new {id = 2, name = "Bold", age = "3"}
            });
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