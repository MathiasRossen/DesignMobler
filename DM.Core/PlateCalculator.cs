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

        }

        public Plate GetPlate()
        {
            return new Plate();
        }
    }
}
