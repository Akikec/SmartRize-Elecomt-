using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WidgetTest1
{
    public partial class RegExEdit : Form
    {
        public RegExEdit()
        {
            InitializeComponent();
            label1.Text = Properties.Settings.Default.RegExSetting;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Properties.Settings.Default.RegExSetting += textBox1.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RegExSetting = null;
            Properties.Settings.Default.Save();
            label1.Text = "";
        }
    }
}
