using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Pages.services;

namespace Z_Marked.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public IUserSource Repo { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUserSource repo)
        {
            _logger = logger;
            Repo = repo;
        }

        public void OnGet()
        {

        }
    }
}