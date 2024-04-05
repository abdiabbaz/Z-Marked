using Z_Marked.Pages.UserFiles;

namespace Z_Marked.Pages.services
{
    public class UserRepo : IUserSource
    {
        List<User> _userList = new List<User>();

        public UserRepo(bool mockdata = false)
        {
            _userList = new List<User>();
            if (mockdata)
            {
                _userList.Add(new User("Anders", "Anders123", "anders@hotmail.com", "21212121", 1));
                _userList.Add(new User("Svend", "Svend123", "svend@hotmail.com", "12121212", 2));
                _userList.Add(new User("Kjeld", "Kjeld123", "kjeld@hotmail.com", "31313131", 3));
                _userList.Add(new User());
                _userList.Add(new User());
                Console.WriteLine(_userList.Count);
                Console.WriteLine(IsValidLogin("Anders", "Anders123"));
                Console.WriteLine(ToString());
            }

        }



        public List<User> GetAllUsers()
        {
            return new List<User>(_userList);
        }

        public void Add(User user)
        {
            if (_userList.Count == 1000)
            {
                throw new Exception("Too many users in db");
            }
            _userList.Add(user);
        }

        public void Remove(User user)
        {
            _userList.Remove(user);

        }

        public void Update(int idx, User user)
        {
            User? usrToUpdate = _userList.Find(u => u.UserID == idx);
            if (usrToUpdate == null)
            {
                throw new NullReferenceException("No user found with that UserID");
            }
            int _index = _userList.IndexOf(usrToUpdate);
            usrToUpdate.Email = user.Email;
            usrToUpdate.Password = user.Password;
            _userList[idx] = usrToUpdate;
            return;

        }

        public User Read(int userid)
        {
            return _userList.Find(u => u.UserID == userid)!;

        }

        public User Read(string username)
        {
            User? user = _userList.Find(u => u.UserName == username);
            if (user == null)
            {
                throw new NullReferenceException("No user found with that username");
            }
            return user;
        }

        public bool IsValidLogin(string username, string password)
        {
            User? usr = _userList.Find(u => u.UserName == username);
            if (usr == null)
            {
                throw new NullReferenceException("No user found with that username");
            }
            return password == usr.Password;
        }

        public User CurrentUser { get; set; } = null;

        public override string ToString()
        {
            string usrstring = $"Number of users in list: {_userList.Count}\n\a\t";
            foreach (User usr in _userList)
            {
                usrstring += $"{usr.ToString()}\n\t";
            }
            return usrstring;
        }
    }
}
