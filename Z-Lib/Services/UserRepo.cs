using Z_Marked.Exceptions;
using Z_Marked.Model;

namespace Z_Marked.Services
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
                Console.WriteLine(GetUser("Anders", "Anders123"));
                Console.WriteLine(ToString());
            }

        }



        public List<User> GetAllUsers()
        {
            return new List<User>(_userList);
        }

        public void AddUser(User user)
        {
            if (_userList.Count == 1000)
            {
                throw new Exception("Too many users in db");
            }
            _userList.Add(user);
        }

        public void RemoveUser(User user)
        {
            _userList.Remove(user);

        }

        public void UpdateUser(int idx, User user)
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

        public User ReadUser(int userid)
        {
            return _userList.Find(u => u.UserID == userid)!;

        }

        public User ReadUser(string username)
        {
            User? user = _userList.Find(u => u.UserName == username);
            if (user == null)
            {
                throw new NullReferenceException("No user found with that username");
            }
            return user;
        }

        public User GetUser(string username, string password)
        {
            User? user = _userList.Find(u => u.UserName == username && u.Password == password);
            if (user == null)
            {
                throw new WrongCredentialsException();
            }
            return user;
        }



        public override string ToString()
        {
            string usrstring = $"Number of users in list: {_userList.Count}\n\t";
            foreach (User usr in _userList)
            {
                usrstring += $"{usr.ToString()}\n\t";
            }
            return usrstring;
        }
    }
}
