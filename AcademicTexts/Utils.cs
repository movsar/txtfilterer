using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Linq;
using SpreadsheetLight;
using BrightIdeasSoftware;

namespace TxtFilterer
{
    public class Utils
    {
        public static string WorkDirPath;
        // Tab History
        public static List<xTextFile> history;

        public static List<xTextFile> fList; // Hold the files
        private static string appName = "DoshStat";
        private static string separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

        public static xTextFile GetTextFile(long id)
        {
            return history.First(file => (file.fileId == id));
        }
     
        public static void StgSet(string name, bool value)
        {
            Properties.Settings.Default[name] = value;
            Properties.Settings.Default.Save();
        }

        public static void StgSet(string name, int value)
        {
            Properties.Settings.Default[name] = value;
            Properties.Settings.Default.Save();
        }

        public static void StgSet(string name, string value)
        {
            Properties.Settings.Default[name] = value;
            Properties.Settings.Default.Save();
        }

        public static bool StgGetBool(string name)
        {
            return Convert.ToBoolean(Properties.Settings.Default[name]);
        }
        public static int StgGetInt(string name)
        {
            return Convert.ToInt32(Properties.Settings.Default[name]);
        }
        public static string StgGetString(string name)
        {
            return Convert.ToString(Properties.Settings.Default[name]);
        }

        public static DialogResult msgQuestion(String txt)
        {
            return MessageBox.Show(txt, appName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
        public static DialogResult msgConfirmation(String txt)
        {
            return MessageBox.Show(txt, appName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }
        public static DialogResult msgCriticalError(String txt)
        {
            return MessageBox.Show(txt, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult msgExclamation(String txt)
        {
            return MessageBox.Show(txt, appName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void msgAccessDenied()
        {
            MessageBox.Show("У вас недостаточно привилегий", appName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void msgInformation(String txt)
        {
            MessageBox.Show(txt, appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static int GetColumnIndex(ListView lv, string colTitle)
        {
            foreach (ColumnHeader col in lv.Columns) {
                if (col.Text.ToLower().Equals(colTitle.ToLower())) {
                    return col.Index;
                }
            }
            return -1;
        }
        public static ListViewItem GetLVIByValue(ListView lv, string colTitle, string value)
        {
            int colIndex = GetColumnIndex(lv, colTitle);
            foreach (ListViewItem li in lv.Columns[colIndex].ListView.Items) {
                if (li.Text.ToLower().Equals(value.ToLower())) {
                    return li;
                }
            }
            return null;
        }
        public static ListViewItem GetLVIByValue(ListView lv, int colIndex, string value)
        {
            foreach (ListViewItem li in lv.Columns[colIndex].ListView.Items) {
                if (li.Text.ToLower().Equals(value.ToLower())) {
                    return li;
                }
            }
            return null;
        }



        public static void ErrLog(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter("DoshStat.log", true)) {
                sw.WriteLine(GetCurrentDateTime() + " : " + ex.Message);
                sw.WriteLine(ex.StackTrace.ToString());
                sw.WriteLine();
            }
        }
        public static void ErrLog(String caption, String msg)
        {
            using (StreamWriter sw = new StreamWriter("DoshStat.log", true)) {
                sw.WriteLine(GetCurrentDateTime() + " : " + caption);
                sw.WriteLine(msg);
                sw.WriteLine();
            }
        }
        public static void Logging(String ex)
        {
            Debug.WriteLine("Internal String Error" + ex);
        }
        public static void Logging(string format, params object[] args)
        {
            Debug.WriteLine(format, args);
        }
        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        public static string GetCurrentDateTime()
        {
            string dt = DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss");
            return dt;
        }
        public static void ExcelExport(ObjectListView olv, string defaultName)
        {
            SLDocument sl = new SLDocument();
            SLStyle style = sl.CreateStyle();

            for (int i = 1; i <= olv.Columns.Count; ++i)
            {
                sl.SetCellValue(1, i, olv.Columns[i - 1].Text);
            }

            for (int i = 1; i <= olv.Columns.Count; ++i)
            {
                for (int j = 1; j <= olv.Items.Count; ++j)
                {
                    string cellVal = olv.Items[j - 1].SubItems[i - 1].Text;
                    int cellValNumeric = -1;
                    if (int.TryParse(cellVal, out cellValNumeric))
                    {
                        sl.SetCellValue(j + 1, i, cellValNumeric);
                    }
                    else
                    {
                        sl.SetCellValue(j + 1, i, cellVal);
                    }

                    /*if (StgGetInt("ExStyle") == 0)
                    {
                        System.Drawing.Color backColor = olv.Items[j - 1].BackColor;
                        System.Drawing.Color foreColor = olv.Items[j - 1].ForeColor;
                        style.Fill.SetPattern(PatternValues.Solid, backColor, foreColor);

                        sl.SetCellStyle(j + 1, i, style);
                    }*/


                }
            }

            SLTable tbl = sl.CreateTable(1, 1, olv.Items.Count + 1, olv.Columns.Count);
         
                   // Синий
                    tbl.SetTableStyle(SLTableStyleTypeValues.Medium2);
                     // Зеленый
               //     tbl.SetTableStyle(SLTableStyleTypeValues.Medium4);
                   // Красный
                //    tbl.SetTableStyle(SLTableStyleTypeValues.Medium3);
                  // Никакой
           
            tbl.Sort(1, false);
            sl.InsertTable(tbl);
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + defaultName + ".xlsx";

            sl.SaveAs(filePath);
            Process.Start(filePath);
        }
    }
}