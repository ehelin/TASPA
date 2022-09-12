using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class VerbsSubPanelModel : BaseModel
    {
        public VerbsSubPanelModel(ITaspaService taspaService) : base(taspaService) { }

        public void OnGet()
        {
            //this.NavigationLinks = this.taspaService.GetNavigationLinks();
        }
    }
}