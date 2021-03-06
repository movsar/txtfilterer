﻿namespace TxtFilterer
{
    partial class FrmMain
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
            this.btnGo = new System.Windows.Forms.Button();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.btnBrowseRef = new System.Windows.Forms.Button();
            this.prgbMain = new System.Windows.Forms.ProgressBar();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.txtFileB = new System.Windows.Forms.TextBox();
            this.txtFileA = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rdbIntersect = new System.Windows.Forms.RadioButton();
            this.rdbExceptRef = new System.Windows.Forms.RadioButton();
            this.rdbExceptInput = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRegexp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Enabled = false;
            this.btnGo.Location = new System.Drawing.Point(265, 82);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(78, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Вперед!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(265, 31);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(78, 23);
            this.btnBrowseInput.TabIndex = 3;
            this.btnBrowseInput.Text = "Обзор";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // btnBrowseRef
            // 
            this.btnBrowseRef.Location = new System.Drawing.Point(265, 5);
            this.btnBrowseRef.Name = "btnBrowseRef";
            this.btnBrowseRef.Size = new System.Drawing.Size(78, 23);
            this.btnBrowseRef.TabIndex = 5;
            this.btnBrowseRef.Text = "Обзор";
            this.btnBrowseRef.UseVisualStyleBackColor = true;
            this.btnBrowseRef.Click += new System.EventHandler(this.btnBrowseRef_Click);
            // 
            // prgbMain
            // 
            this.prgbMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prgbMain.Location = new System.Drawing.Point(0, 200);
            this.prgbMain.Name = "prgbMain";
            this.prgbMain.Size = new System.Drawing.Size(351, 20);
            this.prgbMain.TabIndex = 7;
            // 
            // ofdMain
            // 
            this.ofdMain.Filter = "Text files | *.txt; *.docx; *.doc; *.xls; *.xlsx; *.odt; *.pdf; *.htm; *.html";
            this.ofdMain.RestoreDirectory = true;
            // 
            // txtFileB
            // 
            this.txtFileB.Location = new System.Drawing.Point(11, 34);
            this.txtFileB.Name = "txtFileB";
            this.txtFileB.ReadOnly = true;
            this.txtFileB.Size = new System.Drawing.Size(248, 20);
            this.txtFileB.TabIndex = 8;
            this.txtFileB.Text = "Файл B";
            // 
            // txtFileA
            // 
            this.txtFileA.Location = new System.Drawing.Point(11, 8);
            this.txtFileA.Name = "txtFileA";
            this.txtFileA.ReadOnly = true;
            this.txtFileA.Size = new System.Drawing.Size(248, 20);
            this.txtFileA.TabIndex = 9;
            this.txtFileA.Text = "Файл A";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Кодировка *.txt файлов:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "UTF8",
            "CP1251",
            "KOI8"});
            this.comboBox1.Location = new System.Drawing.Point(265, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(78, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // rdbIntersect
            // 
            this.rdbIntersect.AutoSize = true;
            this.rdbIntersect.Checked = true;
            this.rdbIntersect.Location = new System.Drawing.Point(11, 52);
            this.rdbIntersect.Name = "rdbIntersect";
            this.rdbIntersect.Size = new System.Drawing.Size(148, 17);
            this.rdbIntersect.TabIndex = 14;
            this.rdbIntersect.TabStop = true;
            this.rdbIntersect.Text = "и в файле A и в файле B";
            this.rdbIntersect.UseVisualStyleBackColor = true;
            // 
            // rdbExceptRef
            // 
            this.rdbExceptRef.AutoSize = true;
            this.rdbExceptRef.Location = new System.Drawing.Point(11, 36);
            this.rdbExceptRef.Name = "rdbExceptRef";
            this.rdbExceptRef.Size = new System.Drawing.Size(114, 17);
            this.rdbExceptRef.TabIndex = 15;
            this.rdbExceptRef.Text = "только в файле B";
            this.rdbExceptRef.UseVisualStyleBackColor = true;
            // 
            // rdbExceptInput
            // 
            this.rdbExceptInput.AutoSize = true;
            this.rdbExceptInput.Location = new System.Drawing.Point(11, 19);
            this.rdbExceptInput.Name = "rdbExceptInput";
            this.rdbExceptInput.Size = new System.Drawing.Size(114, 17);
            this.rdbExceptInput.TabIndex = 16;
            this.rdbExceptInput.Text = "только в файле A";
            this.rdbExceptInput.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbIntersect);
            this.groupBox1.Controls.Add(this.rdbExceptInput);
            this.groupBox1.Controls.Add(this.rdbExceptRef);
            this.groupBox1.Location = new System.Drawing.Point(0, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 75);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбирает слова, которые встречаются:";
            // 
            // txtRegexp
            // 
            this.txtRegexp.Location = new System.Drawing.Point(11, 174);
            this.txtRegexp.Name = "txtRegexp";
            this.txtRegexp.Size = new System.Drawing.Size(332, 20);
            this.txtRegexp.TabIndex = 18;
            this.txtRegexp.Text = "(\\w+-\\w+)|\\w+";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Регулярное выражение для выборки слов / выражений";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 220);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegexp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtFileA);
            this.Controls.Add(this.txtFileB);
            this.Controls.Add(this.prgbMain);
            this.Controls.Add(this.btnBrowseRef);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.btnGo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMain";
            this.Text = "TxtFilterer - Отдел прикладной семиотики АНЧР";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.Button btnBrowseRef;
        private System.Windows.Forms.ProgressBar prgbMain;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.TextBox txtFileB;
        private System.Windows.Forms.TextBox txtFileA;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton rdbIntersect;
        private System.Windows.Forms.RadioButton rdbExceptRef;
        private System.Windows.Forms.RadioButton rdbExceptInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRegexp;
        private System.Windows.Forms.Label label2;
    }
}

