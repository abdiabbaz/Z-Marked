using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Lib.Exceptions
{
    public class IllegalIDException : ArgumentException
    {
        public IllegalIDException(string message) : base(message) { }
        public override string Message => base.Message;
    }
}
