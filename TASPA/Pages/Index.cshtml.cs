using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Dto;
using Shared.Interfaces;

namespace TASPA.Pages
{
    public class IndexModel : PageModel
    {
        private ITaspaService taspaService;

        public List<NavigationLink> NavigationLinks;

        public IndexModel(ITaspaService taspaService)
        {
            this.taspaService = taspaService;
        }

        public void OnGet()
        {
            //this.NavigationLinks = this.taspaService.GetNavigationLinks();
        }
    }
}