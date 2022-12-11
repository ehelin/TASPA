using System.Collections.Generic;
using Shared.Interfaces;
using TASPA.Models;
using Shared.Dto;

namespace TASPA.Pages
{
    public class SearchResultsPanelModel : BaseModel
    {
        public List<SearchTerm> SearchResults;

        public SearchResultsPanelModel(ITaspaService taspaService) : base(taspaService) { }

        public void OnGet(string searchTerm) 
        {
            this.SearchResults = this.taspaService.Search(searchTerm);        
        }
    }
}