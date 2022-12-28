using System.Collections.Generic;
using Shared.Dto;

namespace TASPA.Pages
{
    public class LayoutListModel
    {
        public List<NavigationLink> NavigationLinks;
        public bool IsMobile;

        public LayoutListModel(List<NavigationLink> navigationLinks, bool isMobile) 
        { 
            this.NavigationLinks = navigationLinks;
            this.IsMobile = isMobile;
        }

        public void OnGet() {}
    }
}