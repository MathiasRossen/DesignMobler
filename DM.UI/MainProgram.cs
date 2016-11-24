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
        public void Run()
        {
            bool running = true;
            string input;
            order = new Order();

            do
            {
                Console.Clear();
                DisplayMenu();
                input = GetInput();
            }
            while (running);
        }

        private string GetInput()
        {
            Console.Write("");
            return Console.ReadLine();
        }

        private string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("");
        }

        private void InsertBoard()
        {
            string wareIdString = GetInput("Vare nummer: ");

            int wareId;
            if(int.TryParse(wareIdString, out wareId))
            {
                IBoardRepository br = new BoardRepository();
                Board board = new Board(wareId, br);

                if (board.Length != 0)
                {
                    string boardLengthString = GetInput("Længde på plade: ");

                    if (board.Width != 0)
                    {
                        string boardWidthString = GetInput("Bredde på plade: ");
                    }
                }

                
            }
        }
    }
}
