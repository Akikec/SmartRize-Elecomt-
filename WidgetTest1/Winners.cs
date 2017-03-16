using System;
using System.Text.RegularExpressions;
using System.Globalization;

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
            string regExp;
            if (Properties.Settings.Default.RegExSetting != null) regExp = @"[<,>]|alt=|[\u0022,\\]|(Smartрица )|(от компании )|( для менеджеров компании)|" + Properties.Settings.Default.RegExSetting;
            else regExp = @"[<,>]|alt=|[\u0022,\\]|(Smartрица )|(от компании )|( для менеджеров компании)"; 
            company = Regex.Replace(company, regExp, string.Empty);
            date = Regex.Replace(date, regExp, string.Empty);
            date = correctDate(date);
            winner = Regex.Replace(winner, regExp, string.Empty);
            prize = Regex.Replace(prize, regExp, string.Empty);
        }

        string correctDate(string date)
        {
            DateTime dt = DateTime.Parse(date);
            dt.AddYears(2017);
            date = dt.ToString("dd.MM.yyyy");
            return date;
        }
    }
}
