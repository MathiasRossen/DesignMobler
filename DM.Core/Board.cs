namespace DM.Core
{
    public enum Surfaces { H1, F2, F3 ,F4, F5, F6, F7, N8, N9, N10 }
    public class Board
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int WareId { get; set; }
        public int Quantity { get; set; }
        public Surfaces Surface { get; set; }
        public int Extension { get; set; }

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