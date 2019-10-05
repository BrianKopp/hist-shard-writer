using Microsoft.AspNetCore.Mvc;

namespace HistShardWriter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Healthy!");
        }
    }
}