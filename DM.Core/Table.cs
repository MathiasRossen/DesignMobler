namespace DM.Core
{
    public class Table
    {
        int width, length;
        int wareId;

        public int Width // 
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
            return "VareNR=" + wareId + "width=" + width + " height=" + height;
        }

        #endregion
    }
}
