namespace DM.Core
{
    public enum Surfaces { H1, F2, F3 ,F4, F5, F6, F7, N8, N9, N10 }
    public class Board
    {
        private int quantity;
        private int extension;
        public int Width { get; set; }
        public int Length { get; set; }
        public int WareId { get; set; }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value <= 0)
                    quantity = 1;
                else
                    quantity = value;
            }
        }
        public Surfaces Surface { get; set; }
        public int Extension
        {
            get { return extension; }
            set
            {
                if (value >= 3)
                    extension = 3;
                else if (value == 1 || value <= 0)
                    extension = 0;
                else
                    extension = value;
            }
        }

        public Board(int wareId, IBoardRepository br)
        {
            Board boardToLoad = br.LoadBoard(wareId);
            WareId = boardToLoad.WareId;
            Length = boardToLoad.Length;
            Width = boardToLoad.Width;
            Quantity = 1;
        }

        public Board(int length, int width)
        {
            Width = width;
            Length = length;
            Quantity = 1;
        }

        public Board(int wareId, int length, int width)
            :this(length, width)
        {
            WareId = wareId;
        }

        public Board(int wareId, int length, int width, IBoardRepository br)
            :this(wareId, length, width)
        {
            br.SaveBoard(this);
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
//          Form 1/2 + udtræk til fast,2,3 plader - 1,2,3 plader 
//          Ved fast plade er pladerne i ét stykke og ikke 2x halv.
//    
//  Form1   Kvadrat: 90x90, 100x100, 110x110, 120x120
//  Form2 Rektangel: Bredde x Længde
//           Bredde: 90,100,110,120
//           Længde: 140,160,180,200,220,240,250,260,270
//  