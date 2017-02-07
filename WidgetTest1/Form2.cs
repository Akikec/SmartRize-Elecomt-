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
        List<string> massL = new List<string>();
        string[] mass = new string[1000];
        List<Winners> win = new List<Winners>();

        int k = 0;
        public int numberPosition = 0;

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


        public void parseHTML(string link, string nameLocal)
        {
            WebClient client = new WebClient(); 
            client.DownloadFile(link, nameLocal);                           //Скачать страницу.
            File.Move(nameLocal, Path.ChangeExtension(nameLocal, ".txt"));  //Изменить формат полученной страницы.
        }

        public int wrestWinners(int i)
        {
            int startSearch = 0; //Нужно найти позицию <div class = "hidden-tablet">.
            string line = "";
            StreamReader reader = new StreamReader(@"localfile1.txt");
            while (!line.Contains("<div class = \"hidden-tablet\">")) // Попробовать RegEx
            {
                line = reader.ReadLine();
                startSearch++;
            }
            reader.Close();
            return startSearch;
        }

        public List<string> stringMassive(string fileN)
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

        public Winners findWinners(List<string> fullTXT,int posSearch)
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
            win.Add(findWinners(stringMassive(@"localfile1.txt"), wrestWinners(numberPosition)));
            
            
            parseHTML("http://www.elecomt.ru/smartritsa/prize", @"localfile1.html");
            parseHTML("http://www.elecomt.ru/smartritsa_managers/prize", @"localfile2.html");
            Timer t = new Timer();
            //t.Interval = 600000;
            //t.Tick += (timer, arguments) => Run();
            //t.Start();
        }
    }
}