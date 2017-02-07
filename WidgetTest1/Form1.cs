using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidgetTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("google.com");
            pictureBox1.ImageLocation = "https://www.google.ru/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";
            //pictureBox1.Image = System.Drawing.Image.FromFile("https://www.google.ru/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate("www.elecomt.ru/");
            pictureBox1.ImageLocation = "http://www.elecomt.ru/images/logo.png";
            //pictureBox1.Image = System.Drawing.Image.FromFile("http://www.elecomt.ru/images/logo.png");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }
    }
}
