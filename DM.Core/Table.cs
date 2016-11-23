namespace DM.Core
{
    public class Table
    {
        int width, length;
        int wareId;

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

        public int WareId
        {
            get { return wareId; }
            set { wareId = value; }
        }

        public enum Shape
        {
            Square, Circle, oval, Special,
        };

        public Table(int width, int length)
        {
            this.width = width;
            this.length = length;
        }

        public Table(int wareId, int width, int length)
        {
            this.width = width;
            this.length = length;
            this.wareId = wareId;
        }

        #region Overrides

        public override string ToString()
        {
            return "VareNR=" + wareId + "width=" + width + " length=" + length;
        }

        #endregion
    }
}
// Mål:
//       Parentes er ekstra pris.
//          Form 1/2 + udtræk til fast,2,3 plader - 1,2,(3) plader 
//          Ved fast plade er pladerne i ét stykke og ikke 2x halv.
//    
//  Form1   Kvadrat: 90x90, 100x100, 110x110, (120x120)
//  Form2 Rektangel: Bredde x Længde
//           Bredde: 90,100,110,120
//           Længde: 140,160,180,200,220,240,(250),(260),(270)
// 