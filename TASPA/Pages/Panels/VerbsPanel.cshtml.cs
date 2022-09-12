using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class VerbsPanelModel : BaseModel
    {
        public VerbsPanelModel(ITaspaService taspaService) : base(taspaService) { }

        public void OnGet() {}
    }
}