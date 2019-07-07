using System.Drawing;
using System.Windows.Forms;

namespace TxtFilterer
{
    public partial class FrmOutput : Form
    {
        xTextFile xTFile;
        public FrmOutput(xTextFile xt, int rc)
        {
            xTFile = xt;

            InitializeComponent();
            lblRefWordsCount.Text += rc.ToString();
            lblInputFileName.Text += xTFile.fileName;
            lblInputWordsCount.Text += xTFile.wordsCount.ToString();
            lblInputUniqueWordsCount.Text += xTFile.words.Count.ToString();
             olvOutput.AlternateRowBackColor = Color.AliceBlue;
            olvOutput.SetObjects(xTFile.words);
           
        }

        private void btnExport_Click(object sender, System.EventArgs e)
        {
            Utils.ExcelExport(olvOutput, "TxtFilterer " + Utils.GetCurrentDateTime());
        }

        private void FrmOutput_Load(object sender, System.EventArgs e)
        {
            olvOutput.Sort(0);
        }
    }
}
