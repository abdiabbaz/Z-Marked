using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Lib.Exceptions
{
    public class IllegalNameException : ArgumentNullException
    {
        public IllegalNameException() : base ("Empty or null name supplied, please enter a name"){}

        public override string Message => base.Message;
    }
}
