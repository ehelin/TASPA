using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Dto;
using Shared.Interfaces;

namespace TASPA.Models
{
    public class BaseModel : PageModel
    {
        protected ITaspaService taspaService;
        public List<NavigationLink> NavigationLinks;

        public BaseModel(ITaspaService taspaService)
        {
            this.taspaService = taspaService;
            this.NavigationLinks = this.taspaService.GetNavigationLinks();
        }
    }
}
