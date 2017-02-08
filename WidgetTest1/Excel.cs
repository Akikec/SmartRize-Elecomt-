using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetTest1
{

    class Excel
    {
        //заполнение в Excel.
        Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
        
        public Excel()
        {
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
            ObjWorkSheet.Name = "Смартрица";
        }

        public void PrintinRow(int column, Winners win)
        {
            //Заполняем значениями.
            //Значения [y - строка,x - столбец]
            ObjWorkSheet.Cells[column, 1] = win.id;
            ObjWorkSheet.Cells[column, 2] = win.company;
            ObjWorkSheet.Cells[column, 3] = win.prize;
            ObjWorkSheet.Cells[column, 4] = win.winner;
            ObjWorkSheet.Cells[column, 5] = win.date;
        }
        public void excelVisible()
        { 
            //В итоге, делаем созданную эксельку видимой и доступной!
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
        }
    }
}
