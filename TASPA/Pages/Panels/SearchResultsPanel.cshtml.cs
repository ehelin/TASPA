using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class SearchResultsModel : BaseModel
    {
        public SearchResultsModel(ITaspaService taspaService) : base(taspaService) { }

        public void OnGet() {}
    }
}