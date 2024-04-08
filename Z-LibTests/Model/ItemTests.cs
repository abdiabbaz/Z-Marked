using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z_Marked.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z_Marked.Services;
using Z_Lib.Exceptions;
using System.Diagnostics;
using System.Xml.Linq;

namespace Z_Marked.Model.Tests
{
    [TestClass()]
    public class ItemTests
    {
        private Item _item;
        private Item _dummyItem; 
        [TestInitialize]
        public void BeforeEachTest()
        {
            _item = new Item(0, "d", 1.0, "dd", "dd", "d", "d");
            _dummyItem = new Item(); 
        }

        //ID Property
        [TestMethod()]
        public void TestID()
        {

            Assert.AreEqual(0, _item.Id);
            _item.Id++;
            Assert.AreEqual(1, _item.Id);
            Assert.AreEqual(0, _dummyItem.Id);
            _dummyItem.Id++;
            Assert.AreEqual(1, _dummyItem.Id);
        }

        //Test 
        [TestMethod()]
        public void TestIllegalID()
        {
            Assert.ThrowsException<IllegalIDException>(() => _item.Id = -5);
            Assert.ThrowsException<IllegalIDException>(() => _dummyItem.Id = -5);
        }

        //Name property
        [TestMethod()]
        public void TestName()
        {
            Assert.AreEqual("d", _item.Name);
            _item.Name = "Dummy";
            Assert.AreEqual("Dummy", _item.Name);
  
            _dummyItem.Name = "Dummy";
            Assert.AreEqual("Dummy", _dummyItem.Name);
        }

        //Name illegal and null test
        [TestMethod()]
        [DataRow("")]
        [DataRow(null)]
        public void TestIllegalAndNullName(string input)
        {
            Assert.ThrowsException<IllegalStringValue>(() => _item.Name = input);
            Assert.ThrowsException<IllegalStringValue>(() => _dummyItem.Name = input);
        }

        //Price property
        [TestMethod()]
        [DataRow(0.1)]
        [DataRow(1)]
        [DataRow(2000)]
        [DataRow(4000.9)]
        [DataRow(4000)]
        public void TestPrice(double input)
        {
            _item.Price = input;
            Assert.AreEqual(input, _item.Price);
            _dummyItem.Price = input;
            Assert.AreEqual(input, _item.Price);
        }

        //Illegal price
        [TestMethod()]
        [DataRow(0.0)]
        [DataRow(-0.1)]
        [DataRow(4001.0)]
        [DataRow(4001.1)]
        public void TestIllegalPrice(double input)
        {
            Assert.ThrowsException<IllegalPriceException>(() => _item.Price = input);
            Assert.ThrowsException<IllegalPriceException>(() => _dummyItem.Price = input);
        }

        //Category property
        [DataRow("Hej")]
        [DataRow("Med")]
        [DataRow("Dig")]
        [DataRow(":)")]
        public void TestCategory(string input)
        {
            _item.Category = input;
            Assert.AreEqual(input, _item.Category);
            _dummyItem.Category = input;
            Assert.AreEqual(input, _dummyItem.Category);
        }

        //Illegal category
        [TestMethod()]
        [DataRow(null)]
        [DataRow("")]
        public void TestIllegalCategory(string input)
        {
            Assert.ThrowsException<IllegalStringValue>(() => _item.Category = input);
            Assert.ThrowsException<IllegalStringValue>(() => _dummyItem.Category = input);
        }

        //Description property
        [TestMethod()]
        [DataRow("Dummy value")]
        [DataRow("Another dummy")]
        [DataRow("Looks fine to me")]
        public void TestDescription(string input)
        {
            _item.Description = input;
            Assert.AreEqual(input, _item.Description);
            _dummyItem.Description = input;
            Assert.AreEqual(input, _dummyItem.Description);
        }

        //Illegal Description
        [TestMethod()]
        [DataRow(null)]
        [DataRow("")]
        public void TestIllegalDescription(string input)
        {
            Assert.ThrowsException<IllegalStringValue>(() => _item.Description = input);
            Assert.ThrowsException<IllegalStringValue>(() => _dummyItem.Description = input);
        }

        //NutritionalContent property
        [TestMethod()]
        [DataRow("Dummy value")]
        [DataRow("Another dummy")]
        [DataRow("Looks fine to me")]
        public void TestNutritionalContent(string input)
        {
            _item.NutritionalContent = input;
            Assert.AreEqual(input, _item.NutritionalContent);
            _dummyItem.NutritionalContent = input;
            Assert.AreEqual(input, _dummyItem.NutritionalContent);
        }

        //Illegal NutritionalContent
        [TestMethod()]
        [DataRow(null)]
        [DataRow("")]
        public void TestIllegalNutritionalContent(string input)
        {
            Assert.ThrowsException<IllegalStringValue>(() => _item.NutritionalContent = input);
            Assert.ThrowsException<IllegalStringValue>(() => _dummyItem.NutritionalContent = input);
        }

        //ImagePath property
        [TestMethod()]
        [DataRow("Dummy value")]
        [DataRow("Another dummy")]
        [DataRow("Looks fine to me")]
        public void TestImagePath(string input)
        {
            _item.ImagePath = input;
            Assert.AreEqual(input, _item.ImagePath);
            _dummyItem.ImagePath = input;
            Assert.AreEqual(input, _dummyItem.ImagePath);
        }

        //Illegal ImagePath
        [TestMethod()]
        [DataRow(null)]
        [DataRow("")]
        public void TestIllegalImagePath(string input)
        {
            Assert.ThrowsException<IllegalStringValue>(() => _item.ImagePath = input);
            Assert.ThrowsException<IllegalStringValue>(() => _dummyItem.ImagePath = input);
        }

        //ToString()
        [TestMethod()]
        public void TestToString()
        {
            string output = _item.ToString();
            Assert.AreEqual(output, _item.ToString());
            string se = _dummyItem.ToString();
            Assert.AreEqual(se, _dummyItem.ToString());
        }


    }
}