namespace DM.Core
{
    public class Table
    {
        
        public int Width { get; set; }
        public int Length { get; set; }
        public int WareId { get; set; }

        public Table(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public Table(int wareId, int width, int length)
        {
            Width = width;
            Length = length;
            WareId = wareId;
        }

        #region Overrides

        public override string ToString()
        {
            return "VareNR=" + WareId + " width=" + Width + " length=" + Length;
        }

        public override bool Equals(object obj)
        {
            if (ToString() == obj.ToString())
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return WareId;
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