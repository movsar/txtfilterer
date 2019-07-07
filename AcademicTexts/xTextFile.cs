using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TxtFilterer
{
    public class xTextFile
    {
        public long fileId { get; set; }
        public String fileName { get; set; }
        public int wordsCount { get; set; }
        public int charactersCount { get; set; }
        public int uniqueWordsCount { get; set; }
        public int categoryIndex { get; set; }
        public string created_at { get; set; }
     
        public String filePath { get; set; }

        // For XML export inclusion and exclusion
        public bool isSelected { get; set; }

        public bool isFiction { get; set; }
        public bool isReligious { get; set; }
        public bool isSocPol { get; set; }
        public bool isPoetry { get; set; }
        public bool isScientific { get; set; }

        public int getCategoryIndex()
        {
            if (isFiction)
            {
                return 1;
            }
            else if (isSocPol)
            {
                return 2;
            }
            else if (isReligious)
            {
                return 3;
            }
            else if (isPoetry)
            {
                return 4;
            }
            else if (isScientific)
            {
                return 5;
            }
            return 0;
        }
        public string getCategoryName()
        {
            switch (categoryIndex)
            {
                case 1:
                    return "Художественная";
                case 2:
                    return "Социально - Политическая";
                case 3:
                    return "Религиозная";
                case 4:
                    return "Поэтическая";
                case 5:
                    return "Научная";
            }
            return "Неизвестно";
        }

        public bool isProcessed { get; set; }
        public bool isProblematic { get; set; }
        public ITextProcessor Processor { get; set; }
        public xTextFile()
        {
            isSelected = true;

            this.words = new List<xWord>();
        }
      

        public xTextFile(string filePath)
        {
            this.words = new List<xWord>();
          //  this.frequencies = new List<xWordFrequencies>();
            this.filePath = filePath;
            fileName = (new FileInfo(filePath)).Name;
            if (fileName.EndsWith(".doc"))
            {
                Processor = DocProcessor.GetInstance();
            }
            else if (fileName.EndsWith("docx"))
            {
                Processor = DocxProcessor.GetInstance();
            }
            else if (fileName.EndsWith("htm") || fileName.EndsWith("html"))
            {
                Processor = HtmlProcessor.GetInstance();
            }
            else if (fileName.EndsWith("odt"))
            {
                Processor = OdtProcessor.GetInstance();
            }
            else if (fileName.EndsWith("pdf"))
            {
                Processor = PdfProcessor.GetInstance();
            }
            else if (fileName.EndsWith("rtf"))
            {
                Processor = RtfProcessor.GetInstance();
            }
            else if (fileName.EndsWith("txt"))
            {
                Processor = TxtProcessor.GetInstance();
            }
            else if (fileName.EndsWith("xlsx"))
            {
                Processor = XlsProcessor.GetInstance();
            }
        }


        public void SaveFileInfo()
        {
             
        }


        public List<xWord> words;
    }
}