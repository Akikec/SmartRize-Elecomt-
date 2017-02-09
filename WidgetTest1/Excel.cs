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
            ObjWorkSheet.Cells[1, 1] = "ID";
            ObjWorkSheet.Cells[1, 2] = "Компания";
            ObjWorkSheet.Cells[1, 3] = "Приз";
            ObjWorkSheet.Cells[1, 4] = "Победитель";
            ObjWorkSheet.Cells[1, 5] = "Дата начала конкурса";
        }

        public void PrintinRow(int column, Winners win, bool kl)
        {
            string giperLink1 = Convert.ToString("=ГИПЕРССЫЛКА(\"http://www.elecomt.ru/admin/edit/games/" + Convert.ToString(win.id) + "\";" + Convert.ToString(win.id));
            string giperLink2 = Convert.ToString("=ГИПЕРССЫЛКА(\"http://www.elecomt.ru/admin/edit/games/_managers/" + Convert.ToString(win.id) + "\";" + Convert.ToString(win.id));
            //Заполняем значениями.
            //Значения [y - строка,x - столбец]
            if (kl) ObjWorkSheet.Cells[column, 1] = Convert.ToString(win.id); //Нужно исправить ошибку
            else ObjWorkSheet.Cells[column, 1] = Convert.ToString(win.id);
            ObjWorkSheet.Cells[column, 2] = win.company;
            ObjWorkSheet.Cells[column, 3] = win.prize;
            ObjWorkSheet.Cells[column, 4] = win.winner;
            ObjWorkSheet.Cells[column, 5] = win.date;
        }
        public void excelVisible()
        {
            //Делаем созданную эксельку видимой и доступной!
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
        }
        public void Quit()
        {
            ObjExcel.Quit();
        }
    }
}
