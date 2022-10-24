using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class VocabularyPanelModel : BaseModel
    {
        public VocabularyPanelModel(ITaspaService taspaService) : base(taspaService) { }

        public void OnGet() {}
    }
}