using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DM.Core
{
    public class PlateCalculator
    {
        List<Board> boardList;
        List<Plate> plateList;

        public List<Plate> Plates
        {
            get { return plateList; }
        }

        public PlateCalculator(Order order)
        {
            boardList = order.GetBoards();
            plateList = new List<Plate>();
        }

        public void CalculateBoards()
        {
            for (int i = 0; i < boardList.Count; i++)
            {
                Board board = boardList[i];

                int width = 0;
                int length = 0;
                int quantity = board.Quantity;
                Surfaces surface = Surfaces.H1;

                if (board.Extension)
                {
                    width = board.Width;
                    length = board.Length / 2;
                    surface = board.Surface;
                    quantity *= 2;
                }
                else
                {
                    width = board.Width;
                    length = board.Length;
                    surface = board.Surface;
                }

                length += 10;
                width += 10;

                Plate plate = new Plate(width, length, surface);
                plate.Quantity = quantity;
                AddPlate(plate);
            }
        }

        public Plate GetPlate()
        {
            return plateList.First();
        }

        public Plate GetPlate(int index)
        {
            return plateList[index];
        }

        public void AddPlate(Plate plate)
        {
            if (plateList.Exists(x => x.Equals(plate)))
                plateList.Find(x => x.Equals(plate)).Quantity += plate.Quantity;
            else
                plateList.Add(plate);
        }
    }
}
