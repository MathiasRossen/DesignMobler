using System.Collections.Generic;
using System.Linq;


namespace DM.Core
{
    public class Order
    {
        List<Table> tables = new List<Table>();

        public void AddTable(Table table)
        {
            if (!tables.Exists(x => x.Equals(table)))
                tables.Add(table);
            else
                tables.Find(x => x.WareId == table.WareId).Quantity += table.Quantity;
        }

        public void EditQuantity(int wareId, int newQuantity)
        {
            tables.Find(x => x.WareId == wareId).Quantity = newQuantity;
        }

        public void RemoveTable(int index)
        {
            tables.RemoveAt(index);
        }

        public void RemoveTable(Table table)
        {
            tables.RemoveAll(x => x.Equals(table));
        }

        public void ClearOrder()
        {
            tables.Clear();
        }
        public Table GetTable()
        {
            return tables.First();
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
