using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.Core;

namespace DM.UI
{
    public class MainProgram
    {
        private Order order;
        private IBoardRepository br;

        public void Run()
        {
            bool running = true;

            order = new Order();
            br = new BoardRepository();

            do
            {
                Console.Clear();
                DisplayMenu();

                string choice = GetInput("Valg: ");

                switch (choice.ToLower())
                {
                    case "1":
                        Console.Clear();
                        InsertBoard();
                        break;

                    case "2":
                        Console.Clear();
                        EditWare();
                        break;

                    case "3":
                        Console.Clear();
                        ShowOrders();
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Clear();
                        EditQuantity();
                        break;

                    case "q":
                        running = false;
                        break;
                }
            }
            while (running);
        }

        private string GetInput()
        {
            Console.Write("Indtast noget: ");
            return Console.ReadLine();
        }

        private string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private int GetParsedInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            int inputToInt;
            if(int.TryParse(input, out inputToInt))
                return inputToInt;

            return 0;
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Vælg en af mulighederne fra menuen eller skriv Q for at lukke programmet.");
            Console.WriteLine();
            Console.WriteLine(" 1. Indtast ny ordre");
            Console.WriteLine(" 2. Redigér ordre længde og bredde");
            Console.WriteLine(" 3. Se den nuværende ordre");
            Console.WriteLine(" 4. Redigér antal");
            Console.WriteLine();
        }

        private void InsertBoard()
        {
            int wareId = GetParsedInput("Vare nummer: ");

            Board board = new Board(wareId, br);

            if (board.Length == 0)
                board.Length = GetParsedInput("Længde på plade: ");
            else
                Console.WriteLine("Længde på plade: " + board.Length);

            if (board.Width == 0)
            {
                board.Width = GetParsedInput("Bredde på plade: ");
                //board = new Board(board.WareId, board.Length, board.Width, br);
            }
            else
                Console.WriteLine("Bredde på plade: " + board.Width);

            board.Quantity = GetParsedInput("Antal: ");

            order.AddBoard(board);
            Console.WriteLine("Varen blev gemt!");
            Console.ReadLine();
        }

        private void EditWare()
        {
            ShowOrders();
            Console.WriteLine();

            int wareId = GetParsedInput("Vælg vare nummer, som skal redigéres: ");

            Board boardToEdit = order.GetBoard(wareId);

            if(boardToEdit != null)
            {
                Console.Clear();
                DisplayBoardInfo(boardToEdit);

                boardToEdit.Length = GetParsedInput("Indtast ny længde: ");
                boardToEdit.Width = GetParsedInput("Indtast ny bredde: ");

                order.EditBoard(boardToEdit, br);
            }
        }

        private void EditQuantity()
        {
            ShowOrders();
            Console.WriteLine();

            int wareId = GetParsedInput("Vælg vare nummer, som skal redigéres: ");

            Board boardToEdit = order.GetBoard(wareId);

            if(boardToEdit != null)
            {
                int quantity = GetParsedInput("Skriv nyt antal: ");
                order.EditQuantity(wareId, quantity);
            }
        }

        private void ShowOrders()
        {
            foreach(Board board in order.GetBoards())
            {
                DisplayBoardInfo(board);
            }
        }

        private void DisplayBoardInfo(Board board)
        {
            Console.WriteLine("VareNr: {0,-7}Længde: {1,-7}Bredde: {2,-7}Antal: {3}", board.WareId, board.Length, board.Width, board.Quantity);
        }
    }
}
