using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Services;

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
        public IActionResult OnPostLog(bool logud) { 
            if (logud)
            {
                _repo.CurrentUser = null;
                return Redirect("~/"); 
            }
            return Redirect("~/");
        }
    }
}
