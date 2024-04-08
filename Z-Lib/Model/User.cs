namespace Z_Marked.Model
{
    public class User
    {
        public User(string userName, string password, string email, string phoneNumber, int userID)
        {
            UserName = userName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            UserID = userID;
        }

        public User() : this("", "", "", "", 0) { }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int UserID { get; set; }

        public override string ToString()
        {
            return $"UserID: {UserID}, UserName: {UserName}, Password: {Password}, Email: {Email}, PhoneNumber: {PhoneNumber}";
        }

    }
}
