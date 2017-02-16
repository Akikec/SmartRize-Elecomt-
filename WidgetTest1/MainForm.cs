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
    public partial class MainForm : Form
    {
        List<string> massKL = new List<string>();
        List<string> massMP = new List<string>();
        List<Winners> win = new List<Winners>();

        int kolVo;
        int numberPosition = 0;

        Excel excelImp = new Excel();

        public MainForm()
        {
            InitializeComponent();
            if (File.Exists(@"localfile1.txt") && File.Exists(@"localfile2.txt"))
            {
                checkBox_client.Checked = true;
                checkBox_manager.Checked = true;
                findWin_But.Enabled = true;
            }
        }

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

        public int findWinners(string nameLocal) // первую строку код, hidden-tablet
        {
            int startSearch = 0; //Нужно найти позицию <div class = "hidden-tablet">.
            string line = "";
            StreamReader reader = new StreamReader(nameLocal);
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
            id = Convert.ToInt32(Regex.Match(fullTXT[posSearch + 3], @"\d{3}").Value);
            company = Regex.Match(fullTXT[posSearch + 5], @"(>)S.+(<)").Value;
            date = Regex.Match(fullTXT[posSearch + 9], @"\d{2}").Value + Regex.Match(fullTXT[posSearch + 11], @"(>)\S{3}(<)").Value;
            winner = Regex.Match(fullTXT[posSearch + 33], @"(>)\S.+(<)").Value;
            prize = Regex.Match(fullTXT[posSearch + 36], @"(alt=\u0022).+(\u0022)\s").Value;
            Winners fWin = new Winners(id, company, date, winner, prize);
            return fWin;
        }

        public void setWinners(string nameLocal, int kolVo)
        {
            numberPosition = findWinners(nameLocal);
            massKL = stringMassive(nameLocal);
            for (int i = 0; i < kolVo; i++)
            {
                if (i == 0) win.Add(getWinners(massKL, numberPosition)); //1вый проход
                else
                {
                    //2рой проход
                    numberPosition = findWinners(massKL, numberPosition);
                    win.Add(getWinners(massKL, numberPosition));
                }
            }
        }

        private void findWin_Click(object sender, EventArgs e)
        {
            kolVo = Convert.ToInt32(textBox1.Text);
            setWinners(@"localfile1.txt", kolVo);
            toolStripProgressBar1.Value = 50;
            setWinners(@"localfile2.txt", kolVo);
            toolStripProgressBar1.Value = 100;
            toolStripStatusLabel1.Text = "Получен список победителей.";

            import_Excel.Enabled = true;
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

        private void download_But_Click(object sender, EventArgs e)
        {
            try
            {
                if (parseHTML("http://www.elecomt.ru/smartritsa/prize", @"localfile1.html")) checkBox_client.Checked = true;
                toolStripProgressBar1.Value = 50;
                if (parseHTML("http://www.elecomt.ru/smartritsa_managers/prize", @"localfile2.html")) checkBox_manager.Checked = true;
                toolStripProgressBar1.Value = 100;
                toolStripStatusLabel1.Text = "Выгрузка страницы завершена.";
                findWin_But.Enabled = true;
            }
            catch
            {
                toolStripStatusLabel1.Text = "Ошибка в открытии страницы!";
            }

        }

        private void import_Excel_Click(object sender, EventArgs e)
        {
            bool kl = true;
            for (int i = 1; i <= kolVo*2; i++)
            {
                if (i > kolVo && kl == true) kl = false;
                win[i-1].allClear();
                excelImp.PrintinRow(i + 1, win[i - 1], kl);
            }
            toolStripStatusLabel1.Text = "Выгрузка Excel завершена.";
            excelImp.excelVisible();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            excelImp.Quit();
        }
    }
}