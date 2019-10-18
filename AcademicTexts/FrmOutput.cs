using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TxtFilterer
{
    public partial class FrmOutput : Form
    {
        public FrmOutput(List<xWord> words, xTextFile fileA, xTextFile fileB)
        {

            InitializeComponent();

            lblFileB.Text += fileB.fileName;
            lblFileBWordsC.Text += fileB.wordsCount.ToString();
            lblFileBUniqueWordsC.Text += fileB.uniqueWordsCount.ToString();

            lblFileA.Text += fileA.fileName;
            lblFileAWordsC.Text += fileA.wordsCount.ToString();
            lblFileAUniqueWordsC.Text += fileA.uniqueWordsCount.ToString();


            olvOutput.AlternateRowBackColor = Color.AliceBlue;
            olvOutput.SetObjects(words);
            olvOutput.Sort(olvColumn1, SortOrder.Ascending);
        }

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            this.Enabled = false;
            Utils.ExcelExport(olvOutput, "TxtFilterer " + Utils.GetCurrentDateTime());
            this.Enabled = true;
        }

        private void FrmOutput_Load(object sender, System.EventArgs e)
        {
              olvOutput.Sort(0);
        }
    }
}
