using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Core
{
    public class PlateCalculator
    {
        List<Board> boardList;
        List<Plate> plateList;

        public PlateCalculator(Order order)
        {
            boardList = order.GetBoards();
            plateList = new List<Plate>();
        }

        public void CalculateBoards()
        {
            Board board = boardList.First();
            int width = 0;
            int length = 0;
            int quantity = 0;
            Surfaces surface = Surfaces.H1;

            if (board.Extension)
            {
                width = board.Width / 2;
                length = board.Length / 2;
                surface = board.Surface;
                quantity = 2;
            }

            Plate plate = new Plate(width, length, surface);
            plate.Quantity = quantity;
            AddPlate(plate);
        }

        public Plate GetPlate()
        {
            return plateList.First();
        }
    }
}
