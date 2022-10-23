using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class PhrasesPanelModel : BaseModel
    {
        public PhrasesPanelModel(ITaspaService taspaService) : base(taspaService) { }

        public void OnGet() {}
    }
}