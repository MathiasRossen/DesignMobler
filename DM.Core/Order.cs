using System.Collections.Generic;

namespace DM.Core
{
    public class Order
    {
        List<Table> tables = new List<Table>();

        public void AddTable(Table table)
        {
            tables.Add(table);
        }

        public void RemoveTable(int index)
        {
            tables.RemoveAt(index);
        }

        public void ClearOrder()
        {
            tables.Clear();
        }

        public Table GetTable(int index)
        {
            return tables[index];
        }

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj.ToString() == ToString())
                return true;
            return false;
        }

        public override string ToString()
        {
            return tables.Count.ToString();
        }

        #endregion
    }
}
