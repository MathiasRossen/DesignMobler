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

                int width = board.Width;
                int length = board.Length;
                int quantity = board.Quantity;
                Surfaces surface = board.Surface;

                if (board.Extension)
                {
                    length = board.Length / 2;
                    quantity *= 2;
                }

                length += 10;
                width += 10;

                Plate plate = new Plate(length, width, surface);
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
