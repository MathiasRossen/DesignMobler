using Microsoft.VisualStudio.TestTools.UnitTesting;
using DM.Core;
using System.Collections.Generic;

namespace DM.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void CanCreateEmptyOrder()
        {
            Order order = new Order();
            Order expected = new Order();

            Assert.IsTrue(order.Equals(expected));
        }

        [TestMethod]
        public void CanAddTablesToOrder()
        {
            Table table = new Table(100, 100);
            Order order = new Order();
            order.AddTable(table);

            string expected = "1";

            Assert.AreEqual(expected, order.ToString());
            Assert.AreEqual(table.ToString(), order.GetTable(0).ToString());
            Assert.AreNotEqual(new Table(150, 100).ToString(), order.GetTable(0).ToString());
        }

        [TestMethod]
        public void CanDeleteTableFromOrder()
        {
            Order order = new Order();
            order.AddTable(new Table(100, 100));
            order.AddTable(new Table(150, 150));

            string expected = "2";
            Assert.AreEqual(expected, order.ToString());

            order.RemoveTable(1);
            expected = "1";
            Assert.AreEqual(expected, order.ToString());

            order.RemoveTable(0);
            expected = "0";
            Assert.AreEqual(expected, order.ToString());
        }

        [TestMethod]
        public void CanClearTablesFromOrder()
        {
            Order order = new Order();
            order.AddTable(new Table(100, 100));
            order.AddTable(new Table(150, 150));

            string expected = "2";
            Assert.AreEqual(expected, order.ToString());

            order.ClearOrder();
            expected = "0";
            Assert.AreEqual(expected, order.ToString());
        }
        [TestMethod]
        public void CanGetTableInfo()
        {
            Order order = new Order();
            order.AddTable(new Table(1100, 100, 100));

            Table table = order.GetTable(0);

            Assert.AreEqual(1100, table.WareId);
            Assert.AreEqual(100, table.Length);
            Assert.AreEqual(100, table.Width);
        }

        [TestMethod]
        public void CanFindTableByWareId()
        {
            Order order = new Order();
            order.AddTable(new Table(1000));
            order.AddTable(new Table(1100));
            order.AddTable(new Table(1200));

            Table tableOne = order.GetTable();
            Table tableTwo = order.GetTable(1);
            Table tableThree = order.GetTable(2);

            Assert.AreEqual(1000, tableOne.WareId);
            Assert.AreEqual(100, tableOne.Length);
            Assert.AreEqual(100, tableOne.Width);

            Assert.AreEqual(1100, tableTwo.WareId);
            Assert.AreEqual(200, tableTwo.Length);
            Assert.AreEqual(150, tableTwo.Width);

            Assert.AreEqual(1200, tableThree.WareId);
            Assert.AreEqual(400, tableThree.Length);
            Assert.AreEqual(300, tableThree.Width);
        }

        [TestMethod]
        public void CanAddMoreTablesOfSameType()
        {
            Order order = new Order();
            order.AddTable(new Table(1000));
            order.AddTable(new Table(1000));

            Table table = order.GetTable();

            Assert.AreEqual(2, table.Quantity);
        }

        [TestMethod]
        public void CanEditQuantity()
        {
            Order order = new Order();
            Table table = new Table(1000);
            table.Quantity = 5;
            order.AddTable(table);

            order.EditQuantity(1000, 10);
            Table expectedTable = order.GetTable();

            Assert.AreEqual(10, expectedTable.Quantity);
        }
        
    }
}