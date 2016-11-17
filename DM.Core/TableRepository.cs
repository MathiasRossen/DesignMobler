using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Core
{
    public class TableRepository : ITableRepository
    {
        Table savetable;

        public Table SaveTable
        {
            get
            {
                return savetable;
            }

            set
            {
                savetable = value;
            }
        }
    }
}
