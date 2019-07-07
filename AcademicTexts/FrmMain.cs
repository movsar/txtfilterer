using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Linq;

namespace TxtFilterer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private String Replacer(string line)
        {
            line = line.Replace("0", "о");

            line = line.Replace("1", "Ӏ");
            line = line.Replace("I", "Ӏ");
            line = line.Replace("l", "Ӏ");

            line = line.Replace("ѐ", "ё");
            line = line.Replace("e", "е");
            line = line.Replace("a", "а");
            line = line.Replace("p", "р");
            line = line.Replace("o", "о");
            line = line.Replace("i", "Ӏ");
            line = line.Replace("l", "Ӏ");
            line = line.Replace("k", "к");
            line = line.Replace("x", "х");
            line = line.Replace("y", "у");
            line = line.Replace("n", "п");
            line = line.Replace("m", "м");
            line = line.Replace("c", "с");
            line = line.Replace("r", "г");
            line = line.Replace("u", "и");

            line = line.Replace("Ѐ", "Ё");
            line = line.Replace("E", "Е");
            line = line.Replace("A", "А");
            line = line.Replace("B", "В");
            line = line.Replace("P", "Р");
            line = line.Replace("O", "О");
            line = line.Replace("I", "Ӏ");
            line = line.Replace("K", "К");
            line = line.Replace("X", "Х");
            line = line.Replace("T", "Т");
            line = line.Replace("M", "М");
            line = line.Replace("C", "С");

            return line;
        }

        String currentDirectory = Path.GetDirectoryName(Application.ExecutablePath);

        private void cleanUpTheFile()
        {
            string etalonFilePath = "etalon.txt";
            using (StreamReader sr = new StreamReader(etalonFilePath, true))
            using (StreamWriter swOut = new StreamWriter("etalon-clean.txt", false, Encoding.UTF8)) {
                String line = sr.ReadLine();
                int i = 0;
                while (line != null) {
                    swOut.WriteLine(Replacer(line).ToLower());
                    Debug.WriteLine(++i + " / " + 1720205);

                    line = sr.ReadLine();
                }
                swOut.Close();
                sr.Close();
            }
        }

        private void btnLatToCyr_Click(object sender, EventArgs e)
        {
            cleanUpTheFile();
        }

        private HashSet<string> references = new HashSet<string>();
        private HashSet<string> inputs = new HashSet<string>();


        private void getReferences()
        {
            string FilePath = txtRef.Text;
            xTextFile File = new xTextFile(FilePath);
            string Contents = File.Processor.GetAllText(FilePath);

            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            var wordPattern = new Regex(@"\w+");
            File.wordsCount = wordPattern.Matches(Contents).Count;

            // Check if exists

            int progress = 0;
            references = new HashSet<string>();
            foreach (Match match in wordPattern.Matches(Contents)) {
                progress++;
                int currentCount = 0;
                words.TryGetValue(match.Value, out currentCount);
                currentCount++;
                words[match.Value] = currentCount;
                references.Add(Replacer(match.Value.ToLower()));
            }
        }
        private void getInuts()
        {
            string FilePath = txtInput.Text;
            xTextFile File = new xTextFile(FilePath);
            string Contents = File.Processor.GetAllText(FilePath);

            var words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
            var wordPattern = new Regex(@"\w+");
            File.wordsCount = wordPattern.Matches(Contents).Count;

            // Check if exists

            int progress = 0;
            inputs = new HashSet<string>();
            foreach (Match match in wordPattern.Matches(Contents)) {
                progress++;
                int currentCount = 0;
                words.TryGetValue(match.Value, out currentCount);
                currentCount++;
                words[match.Value] = currentCount;
                inputs.Add(Replacer(match.Value.ToLower()));
            }
        }

        public void DoWork()
        {
            // do the comparision
            var watch = Stopwatch.StartNew();
            HashSet<string> result = new HashSet<string>();

            if (rdbIntersect.Checked)
                result = new HashSet<string>(references.Intersect(inputs));
            else if (rdbExceptRef.Checked)
                result = new HashSet<string>(inputs.Except(references));
            else if (rdbExceptInput.Checked)
                result = new HashSet<string>(references.Except(inputs));

            Directory.CreateDirectory("TxtFilterer-"+Utils.GetCurrentDateTime());

            string outFileName = currentDirectory + "\\" + "TxtFilterer-" + Utils.GetCurrentDateTime() + "\\" + "result.txt";
            string outInfoFileName = currentDirectory + "\\" + "TxtFilterer-" + Utils.GetCurrentDateTime() + "\\" + "info.txt";

            File.WriteAllLines(outFileName, result, Encoding.UTF8);
            File.WriteAllText(outInfoFileName, string.Format("Файл A:{0}\r\nФайл B:{1}\r\nРабота выполнена в течении:{2}мсек.", txtRef.Text, txtInput.Text, watch.ElapsedMilliseconds));

            Process.Start("TxtFilterer-" + Utils.GetCurrentDateTime());
            // TODO: change name to TxtFilterer-YYYY.MM.DD-HH.MM,
            // TODO: add an info file 
            watch.Stop();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            getReferences();
            getInuts();

            prgbMain.Maximum = 100;
            DoWork();
        }

        private void btnBrowseRef_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == DialogResult.OK) {

                txtRef.Text = ofdMain.FileName;
                if (txtRef.Text.Contains("\\") && txtInput.Text.Contains("\\")) btnGo.Enabled = true;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            prgbMain.Value = 0;
            switch (comboBox1.Text) {
                case "UTF8":
                    Utils.StgSet("TxtCodepage", 0);
                    break;
                case "CP1251":
                    Utils.StgSet("TxtCodepage", 1251);
                    break;
                case "KOI8":
                    Utils.StgSet("TxtCodepage", 20866);
                    break;
            }


            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (prgbMain.Value < prgbMain.Maximum) prgbMain.Value += 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            Utils.StgSet("TxtCodepage", 0);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //FrmOutput frmOutPut = new FrmOutput(inputFile, references.Count);
            //frmOutPut.Show();
        }


        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == DialogResult.OK) {
                txtInput.Text = ofdMain.FileName;
                if (txtRef.Text.Contains("\\") && txtInput.Text.Contains("\\")) btnGo.Enabled = true;
            }
        }

    }
}
