using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Lib.Exceptions
{
    public class IllegalPriceException : ArgumentException
    {
        public IllegalPriceException(double price) : base ($"Illegal price supplied: {price}"){ 
        }

        public override string Message => base.Message;
    }
}
