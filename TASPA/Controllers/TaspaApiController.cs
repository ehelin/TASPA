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

        [HttpGet("getPhraseLists")]
        public IActionResult GetPhraseList()
        {
            var verbList = this.taspaService.GetPhraseLists();

            return Ok(verbList); // 200
        }

        [HttpGet("getPhraseList")]
        public IActionResult GetPhraseList([FromQuery] string phraseListName)
        {
            var verbList = this.taspaService.GetPhraseList(phraseListName);

            return Ok(verbList); // 200
        }

        [HttpGet("getVerbList")]
        public IActionResult GetVerbList([FromQuery] string verbListName)
        {
            var verbList = this.taspaService.GetVerbList(verbListName);
            
            return Ok(verbList); // 200
        }

        [HttpGet("getVerbLists")]
        public IActionResult GetVerbLists()
        {
            var verbLists = this.taspaService.GetVerbLists();

            return Ok(verbLists); // 200
        }

        [HttpGet("getNavigationLinks")]
        public IActionResult GetNavigationLinks()
        {
            var navigationLinks = this.taspaService.GetNavigationLinks();

            return Ok(navigationLinks); // 200
        }
    }
}