using Z_Marked.Model;

namespace Z_Marked.Services
{
    public interface IUserSource
    {
        void AddUser(User user);
        List<User> GetAllUsers();
        User? GetUser(string username, string password);
        User ReadUser(int userid);
        User ReadUser(string username);
        void RemoveUser(User user);
        void UpdateUser(int idx, User user);
    }
}