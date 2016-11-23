namespace DM.Core
{
    public enum Edge { Nature, Black, White }
    public enum Shape { Rectangle, Circle, Oval, Curved }
    public enum Surface { H1, F2, F3, F4, F5, F6, F7, N8, N9, N10 }
    public class Table
    {
        int width, height;
        int wareId;
        Edge tableEdge;
        Shape tableShape;
        Surface tableSurface;
        int extraBoards;
        int quantity;
        int extractions;

        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public int WareId
        {
            get
            {
                return wareId;
            }
            set
            {
                wareId = value;
            }
        }

        public Edge TableEdge
        {
            get
            {
                return tableEdge;
            }
            set
            {
                tableEdge = value;
            }
        }

        public Shape TableShape
        {
            get
            {
                return tableShape;
            }
            set
            {
                tableShape = value;
            }
        }

        public Surface TableSurface
        {
            get
            {
                return tableSurface;
            }
            set
            {
                tableSurface = value;
            }
        }

        public int ExtraBoards
        {
            get
            {
                return extraBoards;
            }
            set
            {
                extraBoards = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public int Extractions
        {
            get
            {
                return extractions;
            }
            set
            {
                extractions = value;
            }
        }


        public Table(int width, int height)
        {
            this.width = width;
            this.height = height;
            wareId = 0;
            tableEdge = Edge.Nature;
            tableShape = Shape.Rectangle;
            tableSurface = Surface.H1;
            extraBoards = 0;
            quantity = 1;
            extractions = 0;
        }

        public Table(int wareId, int width, int height)
            :this(width, height)
        {
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
