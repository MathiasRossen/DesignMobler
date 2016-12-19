using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace DM.Core
{
    public class ExcelCreator
    {
        private List<Plate> plateList;
        public ExcelCreator(List<Plate> plateList)
        {
            this.plateList = plateList;
        }

        public void CreateExcel()
        {
            Application excelApplication = new Application();
            Workbook workBook = excelApplication.Workbooks.Add();
            Worksheet workSheet = workBook.Sheets[1];


            int column = 1;
            foreach(Plate plate in plateList)
            {
                workSheet.Cells[1, column] = plate.Width + "x" + plate.Length;

                column++;
            }

            workSheet.Cells[2, 2] = "Søren (faggot)";

            workBook.Save();
            workBook.Close();
        }
    }
}
