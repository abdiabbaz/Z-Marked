using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z_Marked.Model;

namespace Z_Lib.Exceptions
{
    public class DBException : Exception
    {
        public DBException(string user):base($"Bruger med navnet: {user} eksisterer allerede! Prøv et nyt brugernavn") { }

        public DBException(int idx) : base($"Bruger med ID: {idx} ikke opdateret")
        {
        }

        public override string Message => base.Message;
    }
}
