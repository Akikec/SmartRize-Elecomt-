using System;

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
        
        public void PrintinRow()
        {
            //заполнение в Excel.
        }
    }
}
