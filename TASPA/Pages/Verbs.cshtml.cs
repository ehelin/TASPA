using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TASPA.Pages
{
    public class VerbsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public VerbsModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}