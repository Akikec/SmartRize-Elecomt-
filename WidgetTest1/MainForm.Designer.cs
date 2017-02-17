namespace WidgetTest1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.findWin_But = new System.Windows.Forms.Button();
            this.download_But = new System.Windows.Forms.Button();
            this.checkBox_client = new System.Windows.Forms.CheckBox();
            this.checkBox_manager = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.import_Excel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество позиций:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(184, 29);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // findWin_But
            // 
            this.findWin_But.Enabled = false;
            this.findWin_But.Location = new System.Drawing.Point(50, 69);
            this.findWin_But.Name = "findWin_But";
            this.findWin_But.Size = new System.Drawing.Size(200, 23);
            this.findWin_But.TabIndex = 2;
            this.findWin_But.Text = "Получить список победителей";
            this.findWin_But.UseVisualStyleBackColor = true;
            this.findWin_But.Click += new System.EventHandler(this.findWin_Click);
            // 
            // download_But
            // 
            this.download_But.Location = new System.Drawing.Point(40, 141);
            this.download_But.Name = "download_But";
            this.download_But.Size = new System.Drawing.Size(132, 23);
            this.download_But.TabIndex = 4;
            this.download_But.Text = "Выгрузить страницы:";
            this.download_But.UseVisualStyleBackColor = true;
            this.download_But.Click += new System.EventHandler(this.download_But_Click);
            // 
            // checkBox_client
            // 
            this.checkBox_client.AutoCheck = false;
            this.checkBox_client.AutoSize = true;
            this.checkBox_client.Location = new System.Drawing.Point(187, 133);
            this.checkBox_client.Name = "checkBox_client";
            this.checkBox_client.Size = new System.Drawing.Size(70, 17);
            this.checkBox_client.TabIndex = 5;
            this.checkBox_client.TabStop = false;
            this.checkBox_client.Text = "Клиенты";
            this.checkBox_client.UseVisualStyleBackColor = false;
            // 
            // checkBox_manager
            // 
            this.checkBox_manager.AutoCheck = false;
            this.checkBox_manager.AutoSize = true;
            this.checkBox_manager.Location = new System.Drawing.Point(187, 156);
            this.checkBox_manager.Name = "checkBox_manager";
            this.checkBox_manager.Size = new System.Drawing.Size(87, 17);
            this.checkBox_manager.TabIndex = 6;
            this.checkBox_manager.TabStop = false;
            this.checkBox_manager.Text = "Менеджеры";
            this.checkBox_manager.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 363);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // import_Excel
            // 
            this.import_Excel.Enabled = false;
            this.import_Excel.Location = new System.Drawing.Point(40, 323);
            this.import_Excel.Name = "import_Excel";
            this.import_Excel.Size = new System.Drawing.Size(200, 23);
            this.import_Excel.TabIndex = 8;
            this.import_Excel.Text = "Импорт в Excel";
            this.import_Excel.UseVisualStyleBackColor = true;
            this.import_Excel.Click += new System.EventHandler(this.import_Excel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.findWin_But);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-11, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 123);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WidgetTest1.Properties.Resources.logo__1_;
            this.pictureBox1.ImageLocation = "C:\\Users\\Gareev\\Pictures\\logo (1).png";
            this.pictureBox1.Location = new System.Drawing.Point(0, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 385);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.import_Excel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBox_manager);
            this.Controls.Add(this.checkBox_client);
            this.Controls.Add(this.download_But);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Отчет Smart-Рицы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button findWin_But;
        private System.Windows.Forms.Button download_But;
        private System.Windows.Forms.CheckBox checkBox_client;
        private System.Windows.Forms.CheckBox checkBox_manager;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Button import_Excel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}