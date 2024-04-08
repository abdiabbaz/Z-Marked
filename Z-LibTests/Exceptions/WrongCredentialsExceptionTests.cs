using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z_Marked.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z_Marked.Services;

namespace Z_Marked.Exceptions.Tests
{
    [TestClass()]
    public class WrongCredentialsExceptionTests
    {
        private UserRepo _repo; 
        [TestInitialize]
        public void BeforeEveryMethod()
        {
            _repo = new UserRepo(true);

        }

        [TestMethod()]
        public void WrongCredentialsExceptionTest()
        {
            Assert.ThrowsException<WrongCredentialsException>(() => { _repo.GetUser("FDSFS", "SDFSDF"); });  
        }
    }
}