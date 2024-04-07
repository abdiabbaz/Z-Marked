using Z_Marked.Model;

namespace Z_Marked.Services
{
    public interface IUserSource
    {
        User CurrentUser { get; set; }

        void Add(User user);
        List<User> GetAllUsers();
        bool IsValidLogin(string username, string password);
        User Read(int userid);
        User Read(string username);
        void Remove(User user);
        string ToString();
        void Update(int idx, User user);
    }
}