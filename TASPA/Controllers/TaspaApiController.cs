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

        [HttpGet("sendChatMessage")]
        public IActionResult SendChatMessage([FromQuery] string chatMessage)
        {
            //var verbList = this.taspaService.GetVerbList(verbListName);
            var msgSent = string.Format("{0}-{1}", "Message Sent", chatMessage);

            return Ok(msgSent); // 200
        }

        [HttpGet("getVocabularyList")]
        public IActionResult GetVocabularyList([FromQuery] string vocabularyListName)
        {
            var vocabularyList = this.taspaService.GetVocabularyList(vocabularyListName);

            return Ok(vocabularyList); // 200
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