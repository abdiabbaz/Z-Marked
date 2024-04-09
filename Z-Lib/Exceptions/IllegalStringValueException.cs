using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Lib.Exceptions
{
    public class IllegalStringValueException : ArgumentNullException
    {
        public IllegalStringValueException() : base ("Empty or null name supplied, please enter a non-empty value"){}

        public override string Message => base.Message;
    }
}
