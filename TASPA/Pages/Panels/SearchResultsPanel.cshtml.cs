using System.Collections.Generic;
using Shared.Dto;
using Shared.Interfaces;
using TASPA.Models;

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