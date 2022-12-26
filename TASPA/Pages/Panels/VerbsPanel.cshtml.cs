using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class VerbsPanelModel : BaseModel
    {
        public string SearchVerbList { get; set; }
        public string SearchTerm { get; set; }

        public VerbsPanelModel(ITaspaService taspaService) : base(taspaService) { }

        public void OnGet(string selectedSearchTerm) 
        {
            if (!string.IsNullOrEmpty(selectedSearchTerm))
            {
                this.SearchTerm = selectedSearchTerm;
                this.SearchVerbList = SearchTerm.Substring(0, 1).ToUpper();
            }      
        }
    }
}