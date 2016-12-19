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

        public Plate(int length, int width, Surfaces surface)
        {
            Length = length;
            Width = width;
            Surface = surface;
        }

        #region Overrides
        public override string ToString()
        {
            return string.Format("L:{0} W:{1} S:{2}", Length, Width, Surface);
        }

        public override bool Equals(object obj)
        {
            if (ToString() == obj.ToString())
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
