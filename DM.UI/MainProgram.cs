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
            Console.WriteLine(" 1. Intast ny ordre");
            Console.WriteLine(" 2. Redigér en ordre");
            Console.WriteLine(" 3. Se den nuværende ordre");
            Console.WriteLine();
            string choice = GetInput("Valg: ");

            switch (choice)
            {
                case "1":
                    InsertBoard();
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("NOT IMPLEMENTED");
                    Console.ReadLine();
                    break;

                case "3":
                    ShowOrders();
                    break;
            }
        }

        private void InsertBoard()
        {
            Console.Clear();
            int wareId = GetParsedInput("Vare nummer: ");

            Board board = new Board(wareId, br);

            if (board.Length == 0)
                board.Length = GetParsedInput("Længde på plade: ");
            else
                Console.WriteLine("Længde på plade: " + board.Length);

            if (board.Width == 0)
                board.Width = GetParsedInput("Bredde på plade: ");
            else
                Console.WriteLine("Bredde på plade: " + board.Width);

            if()

            board.Quantity = GetParsedInput("Antal: ");

            order.AddBoard(board);
            Console.WriteLine("Varen blev gemt!");
            Console.ReadLine();
        }

        private void EditWareId(int wareId)
        {

        }

        private void ShowOrders()
        {
            Console.Clear();

            foreach(Board board in order.GetBoards())
            {
                Console.WriteLine("VareNr: {0}\tLængde: {1}\tBredde: {2}\tAntal: {3}", board.WareId, board.Length, board.Width, board.Quantity);
            }

            Console.ReadLine();
        }
    }
}
