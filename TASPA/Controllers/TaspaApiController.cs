using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace TASPA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaspaApiController : ControllerBase
    {
        private readonly ITaspaService taspaService;
        private readonly IChatService chatService;
		private readonly IWebHostEnvironment environment;
        private readonly string lastVerbListUsedSubPath;
        private readonly string lastVocabularyListUsedSubPath;

        public const string LAST_VERB_LIST_USED_SUB_PATH = "data\\lastverblistused.txt";
        public const string LAST_VOCABULARY_LIST_USED_SUB_PATH = "data\\lastvocabularylistused.txt";

        public TaspaApiController(ITaspaService taspaService, IChatService chatService, IWebHostEnvironment environment)
        {
            this.taspaService = taspaService;
            this.chatService = chatService;
			this.environment = environment;
            this.lastVerbListUsedSubPath = string.Format("{0}\\{1}", this.environment.WebRootPath, LAST_VERB_LIST_USED_SUB_PATH);
            this.lastVocabularyListUsedSubPath = string.Format("{0}\\{1}", this.environment.WebRootPath, LAST_VOCABULARY_LIST_USED_SUB_PATH);
        }

        [HttpGet("getLastVerbListUsed")]
        public IActionResult GetLastVerbListUsed()
        {
            var responseList = System.IO.File.ReadAllLines(lastVerbListUsedSubPath);
            string response = null;

            if (responseList != null && responseList.Count() == 1)
            {
                response = string.Format("Last Verb List Used: {0}", responseList[0]);
            }

            return Ok(response); // 200
        }

        [HttpGet("getLastVocabularyListUsed")]
        public IActionResult GetLastVocabularyListUsed()
        {
            var responseList = System.IO.File.ReadAllLines(lastVocabularyListUsedSubPath);
            string response = null;

            if (responseList != null && responseList.Count() == 1)
            {
                response = string.Format("Last Vocabulary List Used: {0}", responseList[0]);
            }

            return Ok(response); // 200
        }

        // TODO - change to POST
        [HttpGet("sendChatMessage")]
        public IActionResult SendChatMessage([FromQuery] string chatMessage)
		{
			var response = this.chatService.GetMessageResponse(this.environment.WebRootPath, chatMessage);

            return Ok(response); // 200
        }

        // TODO - change to POST
        [HttpGet("clearChatSession")]
        public IActionResult ClearChatSession()
        {
            this.chatService.ClearChatSession();

            return Ok(); // 200
        }

        [HttpGet("getVocabularyList")]
        public IActionResult GetVocabularyList([FromQuery] string vocabularyListName)
        {
            var vocabularyList = this.taspaService.GetVocabularyList(vocabularyListName);

            if (vocabularyListName != "bodyparts") // NOTE: Exception as this is hard coded on each page load
            {
                // save verb list for UI reference
                System.IO.File.WriteAllText(lastVocabularyListUsedSubPath, String.Empty);
                System.IO.File.WriteAllText(lastVocabularyListUsedSubPath, vocabularyListName);
            }

            return Ok(vocabularyList); // 200
        }        

        [HttpGet("getVerbList")]
        public IActionResult GetVerbList([FromQuery] string verbListName)
        {
            var verbList = this.taspaService.GetVerbList(verbListName);

            // save verb list for UI reference
            System.IO.File.WriteAllText(lastVerbListUsedSubPath, String.Empty);
            System.IO.File.WriteAllText(lastVerbListUsedSubPath, verbListName);

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