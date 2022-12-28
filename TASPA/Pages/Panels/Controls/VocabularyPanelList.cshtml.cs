using System.Collections.Generic;
using Shared.Dto;
using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class VocabularyPanelListModel 
    {
        public List<VocabularyRadioButton> VocabularyRadioButtons;
        public string VocabularyList { get; set; }
        public bool IsMobile { get; set; }

        public VocabularyPanelListModel(List<VocabularyRadioButton> vocabularyRadioButtons, string vocabularyList, bool isMobile) 
        { 
            this.VocabularyRadioButtons = vocabularyRadioButtons;
            this.VocabularyList = vocabularyList;
            this.IsMobile = isMobile;
        }

        public void OnGet() {}
    }
}