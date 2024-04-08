using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Model;
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
                User user = null!;
                SessionHelper.Get(user, HttpContext);
                SessionHelper.Clear(user, HttpContext);
                return Redirect("~/"); 
            }
            return Redirect("~/");
        }
    }
}
