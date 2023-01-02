using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using System.IO;

namespace TASPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaspaApiController : ControllerBase
    {
        private readonly ITaspaService taspaService;
        private readonly IChatService chatService;
		private readonly IWebHostEnvironment environment;

		public TaspaApiController(ITaspaService taspaService, IChatService chatService, IWebHostEnvironment environment)
        {
            this.taspaService = taspaService;
            this.chatService = chatService;
			this.environment = environment;
		}

        [HttpGet("sendChatMessage")]
        public IActionResult SendChatMessage([FromQuery] string chatMessage)
		{
			var response = this.chatService.GetMessageResponse(this.environment.WebRootPath, chatMessage);

            return Ok(response); // 200
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