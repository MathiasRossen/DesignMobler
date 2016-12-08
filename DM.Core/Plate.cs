using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Core
{
    public class Plate
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public Surfaces Surface { get; set; }
        public int Quantity { get; set; }
    }
}
