using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Model;
using Z_Marked.Services;

namespace Z_Marked.Pages.UserFiles.Logins
{
    public class EditUserInfoModel : PageModel
    {
        #region Instance fields
        private UserRepo _userRepository;
        public bool CanChange;
        [BindProperty]
        public string Phonenumber { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public bool ShowChanges = false;
    
        #endregion
        public void OnGet()
        {
        }

        public IActionResult OnPostChange()
        {
            User? user = null;
            try
            {
                user = SessionHelper.Get<User>(user, HttpContext);

            }
            catch { }
            Email = user.Email;
            Username = user.UserName;
            Password = user.Password;
            Phonenumber = user.PhoneNumber;
            ShowChanges = false;
            CanChange = true;
            return Page();
        }
        public IActionResult OnPostSave()
        {
            User? user = null;
            try
            {
                user = SessionHelper.Get<User>(user, HttpContext);

            }
            catch { }
            CanChange = false;
            user.Email = Email;
            user.UserName = Username;
            user.Password = Password;
            user.PhoneNumber = Phonenumber;
            ShowChanges = true;
            return Page();
        }

        public IActionResult OnPostRegretChanges()
        {
            return Page();
        }
    }
}
