using System.Collections.Generic;
using Shared.Dto;
using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class VocabularyPanelModel : BaseModel
    {
        public List<VocabularyRadioButton> VocabularyRadioButtons;

        public VocabularyPanelModel(ITaspaService taspaService) : base(taspaService) 
        { 
            this.VocabularyRadioButtons = this.taspaService.GetVocabularyRadioButtons();
        }
    }
}