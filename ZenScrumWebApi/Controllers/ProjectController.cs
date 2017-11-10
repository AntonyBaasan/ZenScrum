using Microsoft.AspNetCore.Mvc;

namespace ZenScrumWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok(new {name = "Antony", age = "33"});
        }
    }
}