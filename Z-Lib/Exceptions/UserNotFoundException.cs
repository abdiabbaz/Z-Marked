using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Lib.Exceptions
{
    public class UserNotFoundException : ArgumentException
    {
        public UserNotFoundException(string username, string password): base($"Ingen bruger fundet med brugernavn: {username} og kodeord: {password}"){ }
        public UserNotFoundException(int id) : base($"Ingen bruger fundet med ID: {id}") { }
        public UserNotFoundException(string username) : base($"Ingen bruger fundet med brugernavn: {username}") { }
        public override string Message => base.Message;
    }
}
