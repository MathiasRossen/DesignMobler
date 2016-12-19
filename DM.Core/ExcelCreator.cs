using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace DM.Core
{
    public class ExcelCreator
    {
        List<Plate> plateList;
        string path;

        public ExcelCreator(List<Plate> plateList, string path)
        {
            this.plateList = plateList;
            this.path = path;
            Directory.CreateDirectory(path);
        }

        public void CreateExcel()
        {
            DateTime date = DateTime.Now;
            string currentCellValue;
            int currentColumn = 2;

            Application excelApplication = new Application();
            Workbook workBook = excelApplication.Workbooks.Add(path + "/Template.xlsx");
            Worksheet workSheet = workBook.Sheets[1];

            foreach(Plate plate in plateList)
            {
                currentCellValue = plate.Width + "x" + plate.Length;
                currentColumn = FindNextColumn(currentCellValue, workSheet);

                workSheet.Cells[1, currentColumn] = currentCellValue;
                workSheet.Cells[plate.Surface + 2, currentColumn] = plate.Quantity;
            }

            workBook.SaveAs(path + "/" + date.Day + "-" + date.Month + "-" + date.Year);
            excelApplication.Visible = true;
            //workBook.Close();
        }

        private int FindNextColumn(string cellValueToFind, Worksheet workSheet)
        {
            string cellValue;

            for(int i = 2; i < plateList.Count + 2; i++)
            {
                cellValue = (workSheet.Cells[1, i] as Range).Text;

                if (cellValue == "")
                    return i;
                else if (cellValue == cellValueToFind)
                    return i;
            }

            return 2;
        }
    }
}
