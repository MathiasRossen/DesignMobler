using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Core
{
    public class Board
    {
        int width, length;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public Board(int width, int length)
        {
            this.width = width;
            this.length = length;
        }
    }
}
