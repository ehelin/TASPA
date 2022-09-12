using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class IndexModel : BaseModel
    {
        public IndexModel(ITaspaService taspaService) : base(taspaService) { }

        public void OnGet() {}
    }
}