using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z_Marked.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Z_Marked.Model.Tests
{
    [TestClass()]
    public class OrderTests : IComparer 
    {
        Order order; 
        [TestInitialize]
        public void BeforeEachTest()
        {
            order = new Order();
        }

        [TestMethod()]
        public void OrderTest()
        {
            order = new Order();
            Assert.IsNotNull(order);
        }

        [TestMethod()]
        public void AddItemTest()
        {
            Item item = new Item();
            order.AddItem(item);
            Assert.AreEqual(order.GetAllOrderItems()[0], item); 

        }

        [TestMethod()]
        public void SumOfAllItemsTest()
        {
            Item item = new Item();
            order.AddItem(item);
            Assert.AreEqual(0.1, order.SumOfAllItems());
        }

        [TestMethod()]
        public void GetAllOrdersTest()
        {
            Assert.IsNotNull(order.GetAllOrderItems());
        }

        public int Compare(object? x, object? y)
        {
            if (x.GetType() != typeof(List<Item>))
            {
                return 1;
            }
            if (x.ToString() == y.ToString())
            {
                return 0;
            }
            return -1;

        }
        
    }
}