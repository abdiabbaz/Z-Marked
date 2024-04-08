using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Exceptions;
using Z_Marked.Model;
using Z_Marked.Services;

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

        public IActionResult OnPost()
        {
            //TODO: Change to session
            User user = _repo.GetUser(UserName, Password);
            if (user == null)
            {
                throw new WrongCredentialsException();
            }
            SessionHelper.Set(user, HttpContext);
        
            return RedirectToPage("/Index");
        }
    }
}
