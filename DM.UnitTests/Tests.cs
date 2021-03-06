﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DM.Core;

namespace DM.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        Order order;
        IBoardRepository br;

        [TestInitialize]
        public void Setup()
        {
            order = new Order();
            br = new BoardRepository();
        }

        [TestMethod]
        public void CanCreateEmptyOrder()
        {
            Order expected = new Order();

            Assert.IsTrue(order.Equals(expected));
        }

        [TestMethod]
        public void CanAddBoardsToOrder()
        {
            Board board = new Board(100, 100);
            order.AddBoard(board);

            string expected = "1";

            Assert.AreEqual(expected, order.ToString());
            Assert.AreEqual(board.ToString(), order.GetBoard(0).ToString());
            Assert.AreNotEqual(new Board(150, 100).ToString(), order.GetBoard(0).ToString());
        }

        [TestMethod]
        public void CanDeleteBoardFromOrder()
        {
            order.AddBoard(new Board(1000, 100, 100, Surfaces.H1, true));
            order.AddBoard(new Board(1100, 150, 150, Surfaces.H1, true));

            string expected = "2";
            Assert.AreEqual(expected, order.ToString());

            order.RemoveBoard(1000);
            expected = "1";
            Assert.AreEqual(expected, order.ToString());

            order.RemoveBoard(1100);
            expected = "0";
            Assert.AreEqual(expected, order.ToString());
        }

        [TestMethod]
        public void CanClearBoardsFromOrder()
        {
            order.AddBoard(new Board(100, 100));
            order.AddBoard(new Board(150, 150));

            string expected = "2";
            Assert.AreEqual(expected, order.ToString());

            order.ClearOrder();
            expected = "0";
            Assert.AreEqual(expected, order.ToString());
        }

        [TestMethod]
        public void OrderAddsAndUpdatesBoard()
        {
            IBoardRepository brf = new BoardRepositoryFile(@"C:\VareNr");

            Board newBoard = new Board(2000, 150, 500, Surfaces.H1, true, brf);
            newBoard.Quantity = 2;
            Board anotherBoard = new Board(2000, 300, 400, Surfaces.H1, true, brf);
            anotherBoard.Quantity = 2;
            Board thirdBoard = new Board(2000, brf);
            thirdBoard.Quantity = 2;

            order.AddBoard(newBoard, brf);
            order.AddBoard(anotherBoard, brf);
            order.AddBoard(thirdBoard, brf);

            Board actualBoard = order.GetBoard();
            Board boardFromRepo = new Board(2000, brf);

            Assert.AreEqual(300, actualBoard.Length);
            Assert.AreEqual(400, actualBoard.Width);
            Assert.AreEqual(6, actualBoard.Quantity);

            Assert.AreEqual(300, boardFromRepo.Length);
            Assert.AreEqual(400, boardFromRepo.Width);
        }

        [TestMethod]
        public void CanGetBoardInfo()
        {
            order.AddBoard(new Board(1000, br));

            Board board = order.GetBoard();

            Assert.AreEqual(1000, board.WareId);
            Assert.AreEqual(100, board.Length);
            Assert.AreEqual(100, board.Width);
        }

        [TestMethod]
        public void CanFindBoardByWareId()
        {
            order.AddBoard(new Board(1000, br));
            order.AddBoard(new Board(1100, br));
            order.AddBoard(new Board(1200, br));

            Board boardOne = order.GetBoard(1000);
            Board boardTwo = order.GetBoard(1100);
            Board boardThree = order.GetBoard(1200);

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
            order.AddBoard(new Board(1000, br));
            order.AddBoard(new Board(1000, br));

            Board board = order.GetBoard();

            Assert.AreEqual(2, board.Quantity);
        }

        [TestMethod]
        public void CanEditQuantity()
        {
            Board board = new Board(1000, br);
            board.Quantity = 5;
            order.AddBoard(board);

            order.EditQuantity(1000, 10);
            Board expectedBoard = order.GetBoard(1000);

            Assert.AreEqual(10, expectedBoard.Quantity);
        }

        [TestMethod]
        public void CanAddTableNotInRepository()
        {
            Board board = new Board(1400, br);

            board.Width = 340;
            board.Length = 400;
            board.Extension = false;
            br.SaveBoard(board);

            board = new Board(1400, br);

            Assert.AreEqual(1400, board.WareId);
            Assert.AreEqual(340, board.Width);
            Assert.AreEqual(400, board.Length);
        }

        [TestMethod]
        public void RepoCanEditBoard()
        {
            Board board = new Board(1000, 350, 400, Surfaces.F2, false, br);

            board = br.LoadBoard(1000);

            Assert.AreEqual(350, board.Length);
            Assert.AreEqual(400, board.Width);
            Assert.AreEqual(Surfaces.F2, board.Surface);
            Assert.AreEqual(false, board.Extension);
        }

        [TestMethod]
        public void SaveBoardToFile()
        {
            IBoardRepository br = new BoardRepositoryFile(@"C:\VareNumre");
            Board board = new Board(1000, 100, 100, Surfaces.H1, true, br);

            Board actualBoard = br.LoadBoard(1000);

            Assert.AreEqual(100, actualBoard.Width);
            Assert.AreEqual(Surfaces.H1, actualBoard.Surface);
        }

        [TestMethod]
        public void SaveBoardToFileDirectWithRepo()
        {
            IBoardRepository br = new BoardRepositoryFile(@"C:\VareNumre\Ny");
            Board board = new Board(1000, 100, 100, Surfaces.H1, true);

            br.SaveBoard(board);
            Board actualBoard = br.LoadBoard(1000);

            Assert.AreEqual(100, actualBoard.Width);
            Assert.AreEqual(Surfaces.H1, actualBoard.Surface);
        }

    }

    [TestClass]
    public class OutputTests
    {
        IBoardRepository br;
        Order order;
        PlateCalculator pc;

        [TestInitialize]
        public void Setup()
        {
            br = new BoardRepository();
            order = new Order();
            pc = new PlateCalculator(order);
        }

        [TestMethod]
        public void ConvertBoardToPlate()
        {
            order.AddBoard(new Board(1000, br));
            pc.CalculateBoards();
            Plate actualPlate = pc.GetPlate();

            Assert.AreEqual(60, actualPlate.Length);
            Assert.AreEqual(110, actualPlate.Width);
            Assert.AreEqual(2, actualPlate.Quantity);
            Assert.AreEqual(Surfaces.H1, actualPlate.Surface);
        }

        [TestMethod]
        public void ConvertTwoDifferentBoardsToPlates()
        {
            order.AddBoard(new Board(1000, br));
            order.AddBoard(new Board(1100, br));
            pc.CalculateBoards();
            Plate actualPlate = pc.GetPlate(1);

            Assert.AreEqual(160, actualPlate.Width);
            Assert.AreEqual(110, actualPlate.Length);
            Assert.AreEqual(Surfaces.H1, actualPlate.Surface);
        }

        [TestMethod]
        public void ConvertTwoOfTheSameBoardsToPlates()
        {
            order.AddBoard(new Board(1000, br));
            order.AddBoard(new Board(1000, br));
            pc.CalculateBoards();
            Plate actualPlate = pc.GetPlate();

            Assert.AreEqual(4, actualPlate.Quantity);
        }

        [TestMethod]
        public void ConvertTwoDifferentBoardsWithSamePlateOutput()
        {
            order.AddBoard(new Board(1000, br));
            order.AddBoard(new Board(1300, br));
            pc.CalculateBoards();
            Plate actualPlate = pc.GetPlate();

            Assert.AreEqual(3, actualPlate.Quantity);
        }

        [TestMethod]
        public void ExcelThing()
        {
            order.AddBoard(new Board(1000, br));
            order.AddBoard(new Board(1100, br));
            order.AddBoard(new Board(1200, br));
            order.AddBoard(new Board(1300, br));
            order.AddBoard(new Board(1400, br));
            pc.CalculateBoards();

            ExcelCreator ec = new ExcelCreator(pc.Plates, @"C:\Users\Mathias\Documents\PathToExcel");
            //ec.CreateExcel();
        }
    }
}