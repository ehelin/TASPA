﻿using Microsoft.AspNetCore.Hosting;
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

        public TaspaApiController(ITaspaService taspaService, IChatService chatService, IWebHostEnvironment environment)
        {
            this.taspaService = taspaService;
            this.chatService = chatService;
			this.environment = environment;
        }

        [HttpGet("getLastVerbListUsed")]
        public IActionResult GetLastVerbListUsed()
        {
            var response = this.taspaService.GetLastVerbListUsed(this.environment.WebRootPath);

            return Ok(response); // 200
        }

        [HttpGet("getLastVocabularyListUsed")]
        public IActionResult GetLastVocabularyListUsed()
        {
            var response = this.taspaService.GetLastVocabularyListUsed(this.environment.WebRootPath);

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
                this.taspaService.SaveLastVocabularyListUsed(this.environment.WebRootPath, vocabularyListName);
            }

            return Ok(vocabularyList); // 200
        }        

        [HttpGet("getVerbList")]
        public IActionResult GetVerbList([FromQuery] string verbListName)
        {
            var verbList = this.taspaService.GetVerbList(verbListName);

            this.taspaService.SaveLastVerbListUsed(this.environment.WebRootPath, verbListName);

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