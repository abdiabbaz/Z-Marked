using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Pages.services;

namespace Z_Marked.Pages.UserFiles.Logins
{
    public class LogoutModel : PageModel
    {
        private IUserSource _repo; 
        public LogoutModel(IUserSource repo) {
            _repo = repo;
        }


        public void OnGet()
        {
        }
        public IActionResult OnPostLogout(bool logud) { 
            if (logud)
            {
                _repo.CurrentUser = null;
                return RedirectToPage("/Index"); 
            }
            return RedirectToPage("/Index");
        }
    }
}
