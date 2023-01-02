using Shared.Interfaces;
using TASPA.Models;

namespace TASPA.Pages
{
    public class ChatModel : BaseModel
    {
        public ChatModel(ITaspaService taspaService) : base(taspaService) {}

        public void OnGet() {}
    }
}