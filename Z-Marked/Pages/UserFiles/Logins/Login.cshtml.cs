using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Pages.services;

namespace Z_Marked.Pages.UserFiles.Logins
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        private IUserSource _repo; 
        public LoginModel(IUserSource repo)
        {
            _repo = repo;
        }
        public void OnGet()
        {
        }
        public string UserName { get; set; }
        public string Password { get; set; }

        public IActionResult OnPostLogout()
        {
            if (_repo.IsValidLogin(UserName, Password))
            {
                _repo.CurrentUser = _repo.Read(UserName); 
            }
            return RedirectToPage("/Index");
        }
    }
}
