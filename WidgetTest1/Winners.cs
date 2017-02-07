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
        }
    }
}
