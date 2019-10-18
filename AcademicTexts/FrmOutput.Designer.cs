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
            this.lblFileB = new System.Windows.Forms.Label();
            this.lblFileBWordsC = new System.Windows.Forms.Label();
            this.lblFileBUniqueWordsC = new System.Windows.Forms.Label();
            this.lblFileAUniqueWordsC = new System.Windows.Forms.Label();
            this.lblFileAWordsC = new System.Windows.Forms.Label();
            this.lblFileA = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.olvOutput = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.olvOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileB
            // 
            this.lblFileB.AutoSize = true;
            this.lblFileB.Location = new System.Drawing.Point(264, 10);
            this.lblFileB.Name = "lblFileB";
            this.lblFileB.Size = new System.Drawing.Size(52, 13);
            this.lblFileB.TabIndex = 16;
            this.lblFileB.Text = "Файл Б: ";
            // 
            // lblFileBWordsC
            // 
            this.lblFileBWordsC.AutoSize = true;
            this.lblFileBWordsC.Location = new System.Drawing.Point(264, 23);
            this.lblFileBWordsC.Name = "lblFileBWordsC";
            this.lblFileBWordsC.Size = new System.Drawing.Size(92, 13);
            this.lblFileBWordsC.TabIndex = 17;
            this.lblFileBWordsC.Text = "Слов в файле Б: ";
            // 
            // lblFileBUniqueWordsC
            // 
            this.lblFileBUniqueWordsC.AutoSize = true;
            this.lblFileBUniqueWordsC.Location = new System.Drawing.Point(264, 36);
            this.lblFileBUniqueWordsC.Name = "lblFileBUniqueWordsC";
            this.lblFileBUniqueWordsC.Size = new System.Drawing.Size(209, 13);
            this.lblFileBUniqueWordsC.TabIndex = 19;
            this.lblFileBUniqueWordsC.Text = "Уникальных слов во входном файле Б: ";
            // 
            // lblFileAUniqueWordsC
            // 
            this.lblFileAUniqueWordsC.AutoSize = true;
            this.lblFileAUniqueWordsC.Location = new System.Drawing.Point(1, 36);
            this.lblFileAUniqueWordsC.Name = "lblFileAUniqueWordsC";
            this.lblFileAUniqueWordsC.Size = new System.Drawing.Size(209, 13);
            this.lblFileAUniqueWordsC.TabIndex = 23;
            this.lblFileAUniqueWordsC.Text = "Уникальных слов во входном файле А: ";
            // 
            // lblFileAWordsC
            // 
            this.lblFileAWordsC.AutoSize = true;
            this.lblFileAWordsC.Location = new System.Drawing.Point(1, 23);
            this.lblFileAWordsC.Name = "lblFileAWordsC";
            this.lblFileAWordsC.Size = new System.Drawing.Size(92, 13);
            this.lblFileAWordsC.TabIndex = 22;
            this.lblFileAWordsC.Text = "Слов в файле А: ";
            // 
            // lblFileA
            // 
            this.lblFileA.AutoSize = true;
            this.lblFileA.Location = new System.Drawing.Point(1, 10);
            this.lblFileA.Name = "lblFileA";
            this.lblFileA.Size = new System.Drawing.Size(52, 13);
            this.lblFileA.TabIndex = 21;
            this.lblFileA.Text = "Файл А: ";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(442, 390);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(88, 24);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // olvOutput
            // 
            this.olvOutput.AllColumns.Add(this.olvColumn1);
            this.olvOutput.AllColumns.Add(this.olvColumn2);
            this.olvOutput.AllColumns.Add(this.olvColumn3);
            this.olvOutput.CellEditUseWholeCell = false;
            this.olvOutput.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.olvOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvOutput.FullRowSelect = true;
            this.olvOutput.GridLines = true;
            this.olvOutput.HideSelection = false;
            this.olvOutput.Location = new System.Drawing.Point(3, 54);
            this.olvOutput.Name = "olvOutput";
            this.olvOutput.ShowGroups = false;
            this.olvOutput.Size = new System.Drawing.Size(526, 335);
            this.olvOutput.TabIndex = 24;
            this.olvOutput.TintSortColumn = true;
            this.olvOutput.UseCompatibleStateImageBehavior = false;
            this.olvOutput.UseExplorerTheme = true;
            this.olvOutput.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "title";
            this.olvColumn1.Groupable = false;
            this.olvColumn1.Text = "Слово";
            this.olvColumn1.Width = 350;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "InA";
            this.olvColumn2.Groupable = false;
            this.olvColumn2.Sortable = false;
            this.olvColumn2.Text = "В файле А";
            this.olvColumn2.Width = 80;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "InB";
            this.olvColumn3.Groupable = false;
            this.olvColumn3.Sortable = false;
            this.olvColumn3.Text = "В файле Б";
            this.olvColumn3.Width = 80;
            // 
            // FrmOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 415);
            this.Controls.Add(this.olvOutput);
            this.Controls.Add(this.lblFileAUniqueWordsC);
            this.Controls.Add(this.lblFileAWordsC);
            this.Controls.Add(this.lblFileA);
            this.Controls.Add(this.lblFileBUniqueWordsC);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblFileBWordsC);
            this.Controls.Add(this.lblFileB);
            this.Name = "FrmOutput";
            this.Text = "Просмотр результата проверки";
            this.Load += new System.EventHandler(this.FrmOutput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.olvOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFileB;
        private System.Windows.Forms.Label lblFileBWordsC;
        private System.Windows.Forms.Label lblFileBUniqueWordsC;
        private System.Windows.Forms.Label lblFileAUniqueWordsC;
        private System.Windows.Forms.Label lblFileAWordsC;
        private System.Windows.Forms.Label lblFileA;
        private System.Windows.Forms.Button btnExport;
        private BrightIdeasSoftware.ObjectListView olvOutput;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
    }
}