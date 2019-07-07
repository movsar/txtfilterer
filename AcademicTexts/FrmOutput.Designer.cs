namespace TxtFilterer
{
    partial class FrmOutput
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
            this.olvOutput = new BrightIdeasSoftware.ObjectListView();
            this.olvClmWord = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvClmIsItThere = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lblInputFileName = new System.Windows.Forms.Label();
            this.lblInputWordsCount = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblInputUniqueWordsCount = new System.Windows.Forms.Label();
            this.lblRefWordsCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.olvOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // olvOutput
            // 
            this.olvOutput.AllColumns.Add(this.olvClmWord);
            this.olvOutput.AllColumns.Add(this.olvClmIsItThere);
            this.olvOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvOutput.CellEditUseWholeCell = false;
            this.olvOutput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvClmWord,
            this.olvClmIsItThere});
            this.olvOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.olvOutput.FullRowSelect = true;
            this.olvOutput.GridLines = true;
            this.olvOutput.Location = new System.Drawing.Point(0, 72);
            this.olvOutput.Name = "olvOutput";
            this.olvOutput.ShowGroups = false;
            this.olvOutput.Size = new System.Drawing.Size(508, 455);
            this.olvOutput.TabIndex = 15;
            this.olvOutput.TintSortColumn = true;
            this.olvOutput.UseAlternatingBackColors = true;
            this.olvOutput.UseCompatibleStateImageBehavior = false;
            this.olvOutput.UseExplorerTheme = true;
            this.olvOutput.UseFilterIndicator = true;
            this.olvOutput.UseFiltering = true;
            this.olvOutput.View = System.Windows.Forms.View.Details;
            // 
            // olvClmWord
            // 
            this.olvClmWord.AspectName = "title";
            this.olvClmWord.Groupable = false;
            this.olvClmWord.Text = "Слово";
            this.olvClmWord.Width = 273;
            // 
            // olvClmIsItThere
            // 
            this.olvClmIsItThere.AspectName = "isPresentStr";
            this.olvClmIsItThere.Groupable = false;
            this.olvClmIsItThere.Text = "Присутствие в Эталонной БД";
            this.olvClmIsItThere.Width = 215;
            // 
            // lblInputFileName
            // 
            this.lblInputFileName.AutoSize = true;
            this.lblInputFileName.Location = new System.Drawing.Point(1, 27);
            this.lblInputFileName.Name = "lblInputFileName";
            this.lblInputFileName.Size = new System.Drawing.Size(147, 13);
            this.lblInputFileName.TabIndex = 16;
            this.lblInputFileName.Text = "Название входного файла: ";
            // 
            // lblInputWordsCount
            // 
            this.lblInputWordsCount.AutoSize = true;
            this.lblInputWordsCount.Location = new System.Drawing.Point(1, 40);
            this.lblInputWordsCount.Name = "lblInputWordsCount";
            this.lblInputWordsCount.Size = new System.Drawing.Size(134, 13);
            this.lblInputWordsCount.TabIndex = 17;
            this.lblInputWordsCount.Text = "Слов во входном файле: ";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(431, 43);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblInputUniqueWordsCount
            // 
            this.lblInputUniqueWordsCount.AutoSize = true;
            this.lblInputUniqueWordsCount.Location = new System.Drawing.Point(1, 53);
            this.lblInputUniqueWordsCount.Name = "lblInputUniqueWordsCount";
            this.lblInputUniqueWordsCount.Size = new System.Drawing.Size(193, 13);
            this.lblInputUniqueWordsCount.TabIndex = 19;
            this.lblInputUniqueWordsCount.Text = "Уникальных слов во входном файле";
            // 
            // lblRefWordsCount
            // 
            this.lblRefWordsCount.AutoSize = true;
            this.lblRefWordsCount.Location = new System.Drawing.Point(1, 2);
            this.lblRefWordsCount.Name = "lblRefWordsCount";
            this.lblRefWordsCount.Size = new System.Drawing.Size(123, 13);
            this.lblRefWordsCount.TabIndex = 20;
            this.lblRefWordsCount.Text = "Слов в Эталонной БД: ";
            // 
            // FrmOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 527);
            this.Controls.Add(this.lblRefWordsCount);
            this.Controls.Add(this.lblInputUniqueWordsCount);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblInputWordsCount);
            this.Controls.Add(this.lblInputFileName);
            this.Controls.Add(this.olvOutput);
            this.Name = "FrmOutput";
            this.Text = "Просмотр результата проверки";
            this.Load += new System.EventHandler(this.FrmOutput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olvOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olvOutput;
        private BrightIdeasSoftware.OLVColumn olvClmWord;
        private BrightIdeasSoftware.OLVColumn olvClmIsItThere;
        private System.Windows.Forms.Label lblInputFileName;
        private System.Windows.Forms.Label lblInputWordsCount;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblInputUniqueWordsCount;
        private System.Windows.Forms.Label lblRefWordsCount;
    }
}