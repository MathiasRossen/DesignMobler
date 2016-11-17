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
        //Table loadtable

        public Table Savetable
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

        //public table Loadtable
        //{
        //    get
        //    {
        //        return loadtable;
        //    }

        //    set
        //    {
        //        loadtable = value;
        //    }
        //}
    }
}
