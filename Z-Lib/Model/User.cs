using Z_Lib.Exceptions;

namespace Z_Marked.Model
{
    public class User
    {
        private string _userName;
        private string _password;
        private string _email;
        private string _phoneNumber;
        private int _userID;
        public User(string userName, string password, string email, string phoneNumber, int userID)
        {
            UserName = userName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            UserID = userID;
        }

        public User() : this("Dummy", "Dummy123", "dummy@dummy.com", "33221133", 0)
        {
            Console.WriteLine("Hi there");
        }

        public string UserName
        {
            get => _userName; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalStringValueException();
                }
                _userName = value;

            }
        }
        public string Password
        {
            get => _password; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalStringValueException();
                }
                if (!(ContainsAtLeastThreeDigits(value) && ContainsAtLeastThreeLowerCaseCharacters(value) && ContainsCapitalLetter(value)))
                {
                    throw new MissingCriteriaException();
                }
                _password = value;
            }
        }
        public string Email
        {
            get => _email; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalStringValueException();
                }
                _email = value;
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new IllegalStringValueException();
                }
                if (value.Length != 8 || !Contains8Digits(value))
                {
                    throw new ArgumentException("Number has to be 8 digits precisely");
                }
                _phoneNumber = value;

            }
        }

        public int UserID
        {
            get => _userID; set
            {
                if (value < 0)
                {
                    throw new IllegalIDException($"UserID has to be bigger than 0. Input: {value}"); 
                }
                _userID = value;
            }
        }

        public override string ToString()
        {
            return $"UserID: {UserID}, UserName: {UserName}, Password: {Password}, Email: {Email}, PhoneNumber: {PhoneNumber}";
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

        private bool Contains8Digits(string input)
        {
            int digits = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c)) digits++;
            }
            return digits == 8;
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

    }
}
