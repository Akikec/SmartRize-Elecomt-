using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WidgetTest1
{
    public partial class Form2 : Form
    {
        List<string> massKL = new List<string>();
        List<string> massMP = new List<string>();
        List<Winners> win = new List<Winners>();
        int kolVo;
        int numberPosition = 0;

        public Form2()
        {
            InitializeComponent();
        }

        //public void Run()
        //{
        //    int i = 0;
        //    WebClient client = new WebClient();
        //    client.Encoding = Encoding.GetEncoding(1251);
        //    //client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        //    Stream data = client.OpenRead("http://www.elecomt.ru/smartritsa/prize");
        //    StreamReader reader = new StreamReader(data, Encoding.GetEncoding(1251));
        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        line = reader.ReadLine();
        //        //if (i == 1000) break;
        //        massL.Add(line);
        //        //mass[i] = line;
        //        i++;
        //    }
        //    data.Close();
        //    reader.Close();

        //    //for (int j = 0; j < i - 5; j++)
        //    //{
        //    //    if (mass[j].IndexOf("hidden-tablet") >= 0) k = j;
        //    //}

        //    //line = mass[k].Trim();
        //    //line = line.Substring(39, 3);
        //    //numberPosition = Convert.ToInt32(Regex.Replace(line, @"[^\d]+", ""));
        //    //label1.Text = Convert.ToString("Позиция: " + numberPosition + " Время: " + System.DateTime.Now.ToLongTimeString());
        //    client.DownloadFile("http://www.elecomt.ru/smartritsa/prize", @"localfile.html");

        //    StreamWriter file = new StreamWriter (@"stat.txt", false, Encoding.GetEncoding(1251));
        //    for(int j = 0; j < massL.Count; j++)
        //    {
        //        file.WriteLine(massL[j]);
        //    }
        //    file.Close();
            
        //}

        //public void FindPos()
        //{
        //    int i = 0;
        //    StreamReader reader = new StreamReader(@"localfile.html"); //, Encoding.GetEncoding(1251)
        //    StreamWriter file = new StreamWriter(@"stat.txt",false);
        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        line = reader.ReadLine();
        //        //if (i == 1000) break;
        //        massL.Add(line);
        //        file.WriteLine(massL[i]);
        //        //mass[i] = line;
        //        i++;
        //    }
        //    file.Close();
        //    reader.Close();
        //    File.Move(@"localfile.html", Path.ChangeExtension(@"localfile.html", ".txt"));

        //    //StreamWriter file = new StreamWriter(@"stat.txt");
        //    //for (int j = 0; j < massL.Count; j++)
        //    //{
        //    //    file.WriteLine(massL[j]);
        //    //}
        //    //file.Close();
        //}


        public bool parseHTML(string link, string nameLocal)
        {
            try
            {
                WebClient client = new WebClient();
                string pathTxt = Path.ChangeExtension(nameLocal, ".txt");
                client.DownloadFile(link, nameLocal);                           //Скачать страницу.
                if (File.Exists(pathTxt)) File.Delete(pathTxt);
                File.Move(nameLocal, pathTxt);  //Изменить формат полученной страницы.
                return true;
            }
            catch { return false; }
        }

        public int findWinners() // первую строку код, hidden-tablet
        {
            int startSearch = 0; //Нужно найти позицию <div class = "hidden-tablet">.
            string line = "";
            StreamReader reader = new StreamReader(@"localfile1.txt");
            while (!line.Contains("<div class = \"hidden-tablet\">")) // 
            {
                line = reader.ReadLine();
                startSearch++;
            }
            reader.Close();
            return startSearch;
        }

        public int findWinners(List<string> fullTXT, int curPos) // последующий поиск span3
        {
            curPos += 50; //Нужно найти позицию <div class = \"span3\".
            StreamReader reader = new StreamReader(@"localfile1.txt");
            while (!fullTXT[curPos].Contains("<div class = \"span3\">")) // 
            {
                curPos++;
            }
            reader.Close();
            return curPos - 1;
        }

        public List<string> stringMassive(string fileN) // Получить лист ТХТ
        {
            List<string> fullTXT = new List<string>();
            string line;
            StreamReader reader = new StreamReader(fileN);
            //string s = File.ReadAllText(fileN);
            while((line = reader.ReadLine()) != null)
            {
                fullTXT.Add(line);
            }
            reader.Close();
            return fullTXT;
        }

        public Winners getWinners(List<string> fullTXT,int posSearch) // Ключевой поиск 1ой позиции
        {
            int id;
            string company, date, winner, prize;
            //win[numberPosition].company = Regex.Match(fullTXT[startSearch + 5], @"(>)S.+(<)").Value;
            //Regex.Match(fullTXT[0], @"(>)S.+(<)");
            //Console.WriteLine(match[0].Groups[1].Value);
            id = Convert.ToInt32(Regex.Match(fullTXT[posSearch + 3], @"\d{3}").Value);
            company = Regex.Match(fullTXT[posSearch + 5], @"(>)S.+(<)").Value;
            date = Regex.Match(fullTXT[posSearch + 9], @"\d{2}").Value + Regex.Match(fullTXT[posSearch + 11], @"(>)\S{3}(<)").Value;
            winner = Regex.Match(fullTXT[posSearch + 33], @"(>)\S.+(<)").Value;
            prize = Regex.Match(fullTXT[posSearch + 36], @"(alt=\u0022).+(\u0022)\s").Value;
            Winners fWin = new Winners(id, company, date, winner, prize);
            return fWin;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            kolVo = Convert.ToInt32(textBox1.Text);
            numberPosition = findWinners();
            massKL = stringMassive(@"localfile1.txt");
            for (int i = 0; i < kolVo; i++)
            {
                if (i == 0) win.Add(getWinners(massKL, numberPosition)); //1вый проход
                else
                {
                    //2рой проход
                    numberPosition = findWinners(massKL, numberPosition);
                    win.Add(getWinners(massKL, numberPosition));
                }
                win[i].allClear();
            }
            //parseHTML("http://www.elecomt.ru/smartritsa/prize", @"localfile1.html");
            //parseHTML("http://www.elecomt.ru/smartritsa_managers/prize", @"localfile2.html");
            //Timer t = new Timer();
            //t.Interval = 600000;
            //t.Tick += (timer, arguments) => Run();
            //t.Start();
            toolStripStatusLabel1.Text = "Получен список победителей.";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //if (parseHTML("http://www.elecomt.ru/smartritsa/prize", @"localfile1.html")) checkBox_client.Checked = true;
                //if (parseHTML("http://www.elecomt.ru/smartritsa_managers/prize", @"localfile2.html")) checkBox_manager.Checked = true;
                toolStripStatusLabel1.Text = "Выгрузка страницы завершена.";
            }
            catch
            {
                toolStripStatusLabel1.Text = "Ошибка в открытии страницы!";
            }

        }

        private void import_Excel_Click(object sender, EventArgs e)
        {
            Excel excelImp = new Excel();
            for (int i = 1; i <= kolVo; i++)
            {
                excelImp.PrintinRow(i + 1, win[i - 1], true);
            }
            excelImp.excelVisible();
        }
    }
}