namespace DM.Core
{
    public class Table
    {
        int width, height;
        int wareId;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int WareId
        {
            get { return wareId; }
            set { wareId = value; }
        }

        public Table(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public Table(int wareId, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.wareId = wareId;
        }

        #region Overrides

        public override string ToString()
        {
            return "VareNR=" + wareId + "width=" + width + " height=" + height;
        }

        #endregion
    }
}
