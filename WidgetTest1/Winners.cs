using System;
using System.Text.RegularExpressions;

namespace WidgetTest1
{

    public class Winners
    {
        public int id;
        public string company;
        public string date;
        public string winner;
        public string prize;

        public Winners() { }
                
        public Winners(int id, string company, string date, string winner, string prize)
        {
            this.id = id;
            this.company = company;
            this.date = date;
            this.winner = winner;
            this.prize = prize;
        }
        
        public void allClear()
        {
            string regExp = @"[<,>]|alt=|[\u0022,\\]";
            company = Regex.Replace(company, regExp, string.Empty);
            date = Regex.Replace(date, regExp, string.Empty);
            winner = Regex.Replace(winner, regExp, string.Empty);
            prize = Regex.Replace(prize, regExp, string.Empty);
        }

        public void PrintinRow()
        {
            //заполнение в Excel.

            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            //Книга.
            ObjWorkBook = ObjExcel.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];


            //Заполняем значениями.
            //Значения [y - строка,x - столбец]
            ObjWorkSheet.Cells[3, 1] = 1;
            ObjWorkSheet.Cells[3, 2] = 2;
            ObjWorkSheet.Cells[3, 3] = 3;


            //В итоге, делаем созданную эксельку видимой и доступной!
            ObjExcel.Visible = true;
            ObjExcel.UserControl = true;
        }
    }
}
