using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Z_Marked.Services;

namespace Z_Marked.Pages.UserFiles.Logins
{
    [BindProperties]
    public class NewUserModel : PageModel
    {
        private readonly IUserSource _repo;
        private string _password;
        private string _phoneNumber;
        public NewUserModel(IUserSource repo)
        {
            _repo = repo;
        }
        [Required(ErrorMessage = "Du skal taste et brugernavn")]
        [StringLength(15, MinimumLength = 2)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Du skal taste et kodeord!")]
        [StringLength(30, MinimumLength = 7, ErrorMessage = "Længden af kodeord skal være mindst 7 tegn.")]
        [RegularExpression("([A-ZÆØÅ]{1,}[a-zæøå]{3,}\\d{3,})|([a-zæøå]{1,}[A-ZÆØÅ]{1,}[a-zæøå]{2,}\\d{3,})|([a-zæøå]{2,}[A-ZÆØÅ]{1,}[a-zæøå]{1,}\\d{3,})|([a-zæøå]{3,}[A-ZÆØÅ]{1,}[a-zæøå]{0,}\\d{3,})", ErrorMessage = "4 bogstaver (3 små, 1 stort) og 3 tal")]
        public string Password
        {
            get => _password;
            set
            {
                if (!(ContainsAtLeastThreeDigits(value) && ContainsCapitalLetter(value) && ContainsAtLeastThreeLowerCaseCharacters(value)))
                {
                    _password = "NaN";
                }
                else
                {
                    
                    _password = value;
                }

            }
        }
        [Required(ErrorMessage = "Du skal taste en email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Du skal taste et 8-cifret telefonnummer")]
        public string PhoneNumber
        {
            get => _phoneNumber; set
            {
                if (string.IsNullOrEmpty(value) || !Contains8Digits(value))
                {
                    _phoneNumber = "NaN"; 
                }
                else
                {
                    _phoneNumber = value;
                }
            }
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _repo.AddUser(new Model.User(UserName, Password, Email, PhoneNumber, 1));
            return Redirect("~/Index");
        }

        private bool ContainsAtLeastThreeDigits(string input)
        {
            int digits = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c)) digits++;
            }
            return digits >= 3;
        }


        private bool ContainsCapitalLetter(string input)
        {
            int number = 0;
            foreach (char c in input)
            {
                if (char.IsUpper(c)) number++;
            }
            return number >= 1;
        }

        private bool ContainsAtLeastThreeLowerCaseCharacters(string input)
        {
            int number = 0;
            foreach (char c in input)
            {
                if (char.IsLower(c)) number++;
            }
            return number >= 3;
        }

        private bool Contains8Digits(string input)
        {
            int digits = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c)) digits++;
            }
            return digits == 8;
        }
    }
}
