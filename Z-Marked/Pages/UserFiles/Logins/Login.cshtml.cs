using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Z_Lib.Exceptions;
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
        [Required(ErrorMessage = "Brugernavn skal skrives")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Kodeord skal skrives")]
        [StringLength(100, MinimumLength = 7)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Ukendt login!")]
        public bool Match { get; set; } = false;

        public IActionResult OnPost()
        {
            User user = _repo.GetUser(UserName, Password)!;
            SessionHelper.Set(user, HttpContext);
            if (user != null)
            {
                Match = true; 
            } else
            {
                Match = false;
            }
            if (!ModelState.IsValid && user == null)
            {
                return Page(); 
            }
            return Redirect("~/");

        }
    }
}
