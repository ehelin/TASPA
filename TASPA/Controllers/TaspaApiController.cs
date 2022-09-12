using System;
using System.Collections.Generic;
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
            List<string> verbList = null;

            // TODO - make verbListName comparison strings constants
            if (verbListName == "Full")
            {
                verbList = this.taspaService.GetFullVerbList();
            }
            else
            {
                throw new Exception(string.Format("Unknown verb list name: {0}", verbListName));
            }

            return Ok(verbList); // 200
        }

        [HttpGet("getNavigationLinks")]
        public IActionResult GetNavigationLinks()
        {
            var navigationLinks = this.taspaService.GetNavigationLinks();

            return Ok(navigationLinks); // 200
        }
    }
}
