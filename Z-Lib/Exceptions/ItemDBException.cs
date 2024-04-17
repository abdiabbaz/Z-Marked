using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Lib.Exceptions
{
    public class ItemDBException : Exception
    {
        public ItemDBException(string name) : base($"Vare ikke oprettet i system: {name}"){ }

        public ItemDBException(int id) : base($"Vare ikke fundet med ID: {id}")
        {
        }

        public ItemDBException(string name, string action) : base($"Vare ikke {action} i system: {name}")
        {
        }

        public override string Message => base.Message;
    }
}
