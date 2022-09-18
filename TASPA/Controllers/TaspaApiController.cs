using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;

namespace TASPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaspaApiController : ControllerBase
    {
        private ITaspaService taspaService;

        public TaspaApiController(ITaspaService taspaService)
        {
            this.taspaService = taspaService;
        }

        [HttpGet("getVerbList")]
        public IActionResult GetVerbList([FromQuery] string verbListName)
        {
            var verList = this.taspaService.GetVerbList(verbListName);
            
            return Ok(verList); // 200
        }

        [HttpGet("getNavigationLinks")]
        public IActionResult GetNavigationLinks()
        {
            var navigationLinks = this.taspaService.GetNavigationLinks();

            return Ok(navigationLinks); // 200
        }
    }
}