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
        public void CanAddBoardsToOrder()
        {
            Board board = new Board(100, 100);
            Order order = new Order();
            order.AddBoard(board);

            string expected = "1";

            Assert.AreEqual(expected, order.ToString());
            Assert.AreEqual(board.ToString(), order.GetBoard(0).ToString());
            Assert.AreNotEqual(new Board(150, 100).ToString(), order.GetBoard(0).ToString());
        }

        [TestMethod]
        public void CanDeleteBoardFromOrder()
        {
            Order order = new Order();
            order.AddBoard(new Board(100, 100));
            order.AddBoard(new Board(150, 150));

            string expected = "2";
            Assert.AreEqual(expected, order.ToString());

            order.RemoveBoard(1);
            expected = "1";
            Assert.AreEqual(expected, order.ToString());

            order.RemoveBoard(0);
            expected = "0";
            Assert.AreEqual(expected, order.ToString());
        }

        [TestMethod]
        public void CanClearBoardsFromOrder()
        {
            Order order = new Order();
            order.AddBoard(new Board(100, 100));
            order.AddBoard(new Board(150, 150));

            string expected = "2";
            Assert.AreEqual(expected, order.ToString());

            order.ClearOrder();
            expected = "0";
            Assert.AreEqual(expected, order.ToString());
        }
        [TestMethod]
        public void CanGetBoardInfo()
        {
            Order order = new Order();
            IBoardRepository br = new BoardRepository();
            order.AddBoard(new Board(1000, br));

            Board board = order.GetBoard(0);

            Assert.AreEqual(1000, board.WareId);
            Assert.AreEqual(100, board.Length);
            Assert.AreEqual(100, board.Width);
        }

        [TestMethod]
        public void CanFindBoardByWareId()
        {
            Order order = new Order();
            IBoardRepository br = new BoardRepository();
            order.AddBoard(new Board(1000, br));
            order.AddBoard(new Board(1100, br));
            order.AddBoard(new Board(1200, br));

            Board boardOne = order.GetBoard();
            Board boardTwo = order.GetBoard(1);
            Board boardThree = order.GetBoard(2);

            Assert.AreEqual(1000, boardOne.WareId);
            Assert.AreEqual(100, boardOne.Length);
            Assert.AreEqual(100, boardOne.Width);

            Assert.AreEqual(1100, boardTwo.WareId);
            Assert.AreEqual(200, boardTwo.Length);
            Assert.AreEqual(150, boardTwo.Width);

            Assert.AreEqual(1200, boardThree.WareId);
            Assert.AreEqual(400, boardThree.Length);
            Assert.AreEqual(300, boardThree.Width);
        }

        [TestMethod]
        public void CanAddMoreBoardsOfSameType()
        {
            Order order = new Order();
            IBoardRepository br = new BoardRepository();
            order.AddBoard(new Board(1000, br));
            order.AddBoard(new Board(1000, br));

            Board board = order.GetBoard();

            Assert.AreEqual(2, board.Quantity);
        }

        [TestMethod]
        public void CanEditQuantity()
        {
            Order order = new Order();
            IBoardRepository br = new BoardRepository();
            Board board = new Board(1000, br);
            board.Quantity = 5;
            order.AddBoard(board);

            order.EditQuantity(1000, 10);
            Board expectedBoard = order.GetBoard();

            Assert.AreEqual(10, expectedBoard.Quantity);
        }

        [TestMethod]
        public void CanAddTableNotInRepository()
        {
            IBoardRepository br = new BoardRepository();
            Board board = new Board(1400, br);

            board.Width = 340;
            board.Length = 400;
            board.Extension = 1;
            br.SaveBoard(board);

            board = new Board(1400, br);

            Assert.AreEqual(1400, board.WareId);
            Assert.AreEqual(340, board.Width);
            Assert.AreEqual(400, board.Length);
        }
        
    }
}