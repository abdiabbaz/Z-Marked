using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Lib.Exceptions
{
    public class MissingCriteriaException : ArgumentException
    {
        public MissingCriteriaException() : base("Input must have at least 1 capital character, 3 lower case letters and 3 digits") { }

        public override string Message => base.Message;
    }
}
