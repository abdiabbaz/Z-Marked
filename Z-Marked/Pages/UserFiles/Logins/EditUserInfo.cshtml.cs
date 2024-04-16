using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Z_Marked.Model;
using Z_Marked.Services;

namespace Z_Marked.Pages.UserFiles.Logins
{
    [BindProperties]
    public class EditUserInfoModel : PageModel
    {
        #region Instance fields
        private IUserSource _repo;
        
    
        #endregion
        public EditUserInfoModel(IUserSource repo)
        {
            _repo = repo; 
        }

        public bool CanChange;
       
        public string Phonenumber { get; set; }
        
        public string Email { get; set; }
       
        public string Username { get; set; }
     
        public string Password { get; set; }
        public bool ShowChanges = false;
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
            _repo.UpdateUser(user.UserID, user); 
            return Page();
        }

        public IActionResult OnPostRegretChanges()
        {
            return Page();
        }
    }
}
