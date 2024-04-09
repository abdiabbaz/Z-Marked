using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z_Marked.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Z_Lib.Exceptions;

namespace Z_Marked.Model.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class UserTests
    {
        private User user;
        private User dummy;

        //Setup
        [TestInitialize]
        public void BeforeEach()
        {
            user = new User("Tester", "Pass123", "test@dummy.com", "33221133", 1);
            dummy = new User();
        }

        //Test not null
        [TestMethod()]
        public void UserTest()
        {
            Assert.IsNotNull(user);
            Assert.IsNotNull(dummy);
        }

        //UserName property
        [TestMethod()]
        public void TestUserName()
        {
            user.UserName = "test";
            dummy.UserName = "test";
            Assert.AreEqual("test", user.UserName);
            Assert.AreEqual("test", dummy.UserName);
        }

        //Illegal UserName
        [TestMethod()]
        [DataRow("")]
        [DataRow(null)]
        public void TestIllegalUserName(string input)
        {
            Assert.ThrowsException<IllegalStringValueException>(() => user.UserName = input);
            Assert.ThrowsException<IllegalStringValueException>(() => dummy.UserName = input);
        }


        //ToString()
        [TestMethod()]
        public void ToStringTest()
        {
            string output = user.ToString();
            string output2 = dummy.ToString();
            Assert.AreEqual(output, user.ToString());
            Assert.AreEqual(output2, dummy.ToString());
        }

        //Password property
        [TestMethod()]
        [DataRow("Tester123")]
        public void TestPassword(string input)
        {
            dummy.Password = input;
            user.Password = input;
            Assert.AreEqual(input, user.Password);
            Assert.AreEqual(input, dummy.Password);
        }

        //Illegal Password
        [TestMethod()]
        [DataRow(null)]
        [DataRow("")]
        public void TestIllegalPassword(string input)
        {
            Assert.ThrowsException<IllegalStringValueException>( () => user.Password = input);
            Assert.ThrowsException<IllegalStringValueException>(() => dummy.Password = input);
        }

        //More illegal password
        [TestMethod()]
        [DataRow("tester123")]
        [DataRow("T123")]
        [DataRow("Te123")]
        [DataRow("Tester12")]
        public void TestInvalidPassword(string input) {
            Assert.ThrowsException<MissingCriteriaException>(() => user.Password = input);
            Assert.ThrowsException<MissingCriteriaException>(() => dummy.Password = input);
        }

        //Email property
        [TestMethod()]
        [DataRow("test@testmail.com")]
        public void TestEmail(string input)
        {
            dummy.Email = input;
            user.Email = input;
            Assert.AreEqual(input, user.Email);
            Assert.AreEqual(input, dummy.Email);

        }

        //TestIllegalEmail
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void TestIllegalEmail(string input)
        {
            Assert.ThrowsException<IllegalStringValueException>(() => user.Email = input);
            Assert.ThrowsException<IllegalStringValueException>(() => dummy.Email = input);
        }

        //PhoneNumber property
        [TestMethod]
        public void TestPhoneNumber()
        {
            dummy.PhoneNumber = "33221122";
            user.PhoneNumber = "33221122"; 
            Assert.AreEqual ("33221122", user.PhoneNumber);
            Assert.AreEqual("33221122", dummy.PhoneNumber);
        }

        //Illegal PhoneNumber
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void TestIlleagalPhoneNumber(string input)
        {
            Assert.ThrowsException<IllegalStringValueException>(() => user.PhoneNumber = input);
            Assert.ThrowsException<IllegalStringValueException>(() => dummy.PhoneNumber = input);
        }

        //More Illegal PhoneNumber
        [TestMethod]
        [DataRow("1234567")]
        [DataRow("aaaaaaaa")]
        [DataRow("12345678a")]
        [DataRow("a")]
        public void TestMoreIlleagalPhoneNumber(string input)
        {
            Assert.ThrowsException<ArgumentException>(() => user.PhoneNumber = input);
            Assert.ThrowsException<ArgumentException>(() => dummy.PhoneNumber = input);
        }

        //UserID property
        [TestMethod]
        public void TestUserID()
        {
            user.UserID = 1;
            dummy.UserID = 1;
            Assert.AreEqual(1, user.UserID);
            Assert.AreEqual(1, dummy.UserID);
        }

        //Illeagl UserID
        [TestMethod]
        [DataRow(-1)]
        public void TestIllegalUserID(int input)
        {
            Assert.ThrowsException<IllegalIDException>(() => user.UserID = input);
            Assert.ThrowsException<IllegalIDException>(() => dummy.UserID = input);

        }
    }
}