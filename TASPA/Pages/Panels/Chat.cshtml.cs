using System.Collections.Generic;
using Shared.Dto;
using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class ChatModel : BaseModel
    {
        //public List<VocabularyRadioButton> VocabularyRadioButtons;

        //public string SearchVocabularyList { get; set; }
        //public string SearchTerm { get; set; }

        public ChatModel(ITaspaService taspaService) : base(taspaService) 
        { 
            //this.VocabularyRadioButtons = this.taspaService.GetVocabularyRadioButtons();
        }

        public void OnGet()//string selectedSearchTerm, string vocabularyList)
        {
            //if(!string.IsNullOrEmpty(selectedSearchTerm))
            //{
            //    this.SearchTerm = selectedSearchTerm;
            //    this.SearchVocabularyList = vocabularyList;
            //}
        }
    }
}