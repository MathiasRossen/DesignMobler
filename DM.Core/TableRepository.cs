using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Core
{
    public class TableRepository : ITableRepository
    {
        private List<Table> tableList;

        public TableRepository()
        {
            tableList = new List<Table>();

            SaveTable(new Table(1000, 100, 100));
            SaveTable(new Table(1100, 200, 150));
            SaveTable(new Table(1200, 400, 300));
        }

        public Table LoadTable(int wareId)
        {
            return tableList.Find(x => x.WareId == wareId);
        }

        public Table LoadTable(Table table)
        {
            return tableList.Find(x => x.WareId == table.WareId);
        }

        public void SaveTable(Table table)
        {
            tableList.Add(table);
        }


    }
}
