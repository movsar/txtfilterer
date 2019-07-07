using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using System;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using System.IO.Compression;

namespace TxtFilterer
{
    public class GetWordPlainText : IDisposable
    {
        // Specify whether the instance is disposed.
        private bool disposed = false;

        // The word package
        private WordprocessingDocument package = null;

        /// <summary>
        ///  Get the file name
        /// </summary>
        private string FileName = string.Empty;

        /// <summary>
        ///  Initialize the WordPlainTextManager instance
        /// </summary>
        /// <param name="filepath"></param>
        public GetWordPlainText(string filepath)
        {
            this.FileName = filepath;
            if (string.IsNullOrEmpty(filepath) || !File.Exists(filepath))
            {
                Console.WriteLine("The file is invalid.Please select an existing file again");
                //throw new Exception("The file is invalid. Please select an existing file again");
            }

            this.package = WordprocessingDocument.Open(filepath, true);
        }

        /// <summary>
        ///  Read Word Document
        /// </summary>
        /// <returns>Plain Text in document </returns>
        public string ReadWordDocument()
        {
            StringBuilder sb = new StringBuilder();
            OpenXmlElement element = package.MainDocumentPart.Document.Body;
            if (element == null)
            {
                return string.Empty;
            }

            sb.Append(GetPlainText(element));
            return sb.ToString();
        }

        /// <summary>
        ///  Read Plain Text in all XmlElements of word document
        /// </summary>
        /// <param name="element">XmlElement in document</param>
        /// <returns>Plain Text in XmlElement</returns>
        public string GetPlainText(OpenXmlElement element)
        {
            StringBuilder PlainTextInWord = new StringBuilder();
            foreach (OpenXmlElement section in element.Elements())
            {
                switch (section.LocalName)
                {
                    // Text
                    case "t":
                        PlainTextInWord.Append(section.InnerText);
                        break;

                    case "cr":                          // Carriage return
                    case "br":                          // Page break
                        PlainTextInWord.Append(Environment.NewLine);
                        break;

                    // Tab
                    case "tab":
                        PlainTextInWord.Append("\t");
                        break;

                    // Paragraph
                    case "p":
                        PlainTextInWord.Append(GetPlainText(section));
                        PlainTextInWord.AppendLine(Environment.NewLine);
                        break;

                    default:
                        PlainTextInWord.Append(GetPlainText(section));
                        break;
                }
            }

            return PlainTextInWord.ToString();
        }

        #region IDisposable interface

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Protect from being called multiple times.
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Clean up all managed resources.
                if (this.package != null)
                {
                    this.package.Dispose();
                }
            }

            disposed = true;
        }
        #endregion
    }


    class HtmlProcessor : ITextProcessor
    {

        // Make it into a singleton
        private static readonly ITextProcessor _instance = new HtmlProcessor();
        public static ITextProcessor GetInstance() { return _instance; }
        private HtmlProcessor() { }

        public string GetAllText(string path)
        {
            return Extract(new FileInfo(path).OpenRead());
        }


        public string Extract(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var fileContent = reader.ReadToEnd();

                if (fileContent.StartsWith("<?xml"))
                {
                    var document = XDocument.Parse(fileContent);
                    stream.Seek(0, SeekOrigin.Begin);
                    using (var xmlStream = new StreamReader(stream, Encoding.GetEncoding(document.Declaration.Encoding)))
                    {
                        var xmlContent = xmlStream.ReadToEnd();
                        var xDocument = XDocument.Parse(xmlContent);

                        var metaNodes = xDocument.Descendants().Where(x => x.Name == "documentMetas");
                        foreach (var metaNode in metaNodes.ToList())
                            metaNode.Remove();

                        var result = new StringBuilder();

                        foreach (var element in xDocument.Descendants())
                        {
                            if (element.Descendants().Any())
                                continue;

                            result.Append(element.Value);
                            result.AppendLine();
                        }

                        return result.ToString();
                    }
                }

                var htmlDocument = new HtmlAgilityPack.HtmlDocument();

                htmlDocument.LoadHtml(fileContent);

                var scriptNodes = htmlDocument.DocumentNode.SelectNodes("//script");

                if (scriptNodes != null)
                    foreach (var scriptNode in scriptNodes)
                        scriptNode.Remove();

                var styleNodes = htmlDocument.DocumentNode.SelectNodes("//style");

                if (styleNodes != null)
                    foreach (var styleNode in styleNodes)
                        styleNode.Remove();

                return HttpUtility.HtmlDecode(htmlDocument.DocumentNode.InnerText).Trim();
            }
        }
    }

    class XlsProcessor : ITextProcessor
    {
        // Make it into a singleton
        private static readonly ITextProcessor _instance = new XlsProcessor();
        public static ITextProcessor GetInstance() { return _instance; }
        private XlsProcessor() { }

        private const string SheetEntryName = @"xl/worksheets/sheet(\d+)\.xml";
        private const string SharedStringsEntryName = @"xl/sharedStrings.xml";

        public string GetAllText(string path)
        {
            return Extract(new FileInfo(path).OpenRead());
        }

        public string Extract(Stream stream)
        {
            var result = new StringBuilder();

            using (var zipArchive = new ZipArchive(stream))
            {
                var sharedStringsEntry = zipArchive.Entries.SingleOrDefault(x => x.FullName == SharedStringsEntryName);
                var sharedStrings = GetSharedStrings(sharedStringsEntry);

                var sheetEntries = zipArchive.Entries
                                             .Where(x => Regex.IsMatch(x.FullName, SheetEntryName))
                                             .OrderBy(x => x.Name)
                                             .ToList();

                foreach (var sheetEntry in sheetEntries)
                    ExtractTextFromSheet(sheetEntry, sharedStrings, result);
            }

            return result.ToString();
        }

        private string[] GetSharedStrings(ZipArchiveEntry sharedStringsEntry)
        {
            if (sharedStringsEntry == null)
                return null;

            using (var sharedStringsEntryStream = sharedStringsEntry.Open())
            {
                var document = XDocument.Load(sharedStringsEntryStream);
                var defaultNamespace = document.Root.GetDefaultNamespace();

                var sharedStrings = document.Descendants(XName.Get("si", defaultNamespace.NamespaceName));

                return sharedStrings.Select(x => x.Value)
                                    .ToArray();
            }
        }

        private void ExtractTextFromSheet(ZipArchiveEntry sheetEntry, string[] sharedStrings, StringBuilder result)
        {
            if (sheetEntry == null)
                return;

            using (var sheetEntryStream = sheetEntry.Open())
            {
                var document = XDocument.Load(sheetEntryStream);
                var defaultNamespace = document.Root.GetDefaultNamespace();

                foreach (var row in document.Descendants(XName.Get("row", defaultNamespace.NamespaceName)))
                {
                    var columnValues = row.Descendants(XName.Get("c", defaultNamespace.NamespaceName))
                                          .Select(x => GetColumnValue(x, sharedStrings));

                    result.AppendLine(string.Join(" ", columnValues));
                }
            }
        }

        private string GetColumnValue(XElement column, string[] sharedStrings)
        {
            var typeAttribute = column.Attribute("t");

            if (typeAttribute == null)
                return column.Value;

            if (typeAttribute.Value != "s")
                return null;

            return sharedStrings[int.Parse(column.Value)];
        }
    }

    class TxtProcessor : ITextProcessor
    {
      
        // Make it into a singleton
        private static readonly ITextProcessor _instance = new TxtProcessor();
        public static ITextProcessor GetInstance() { return _instance; }
        private TxtProcessor() { }

        public string GetAllText(string path)
        {
            int stgCodepage = Utils.StgGetInt("TxtCodepage"); // UTF8
            if (stgCodepage == 0)
            {
                using (StreamReader reader = new StreamReader(path, Encoding.UTF8, true))
                {
                    reader.Peek(); // you need this!
                    var encoding = reader.CurrentEncoding;
                    return File.ReadAllText(path, encoding);
                }
            }
            else
            {
                return File.ReadAllText(path, Encoding.GetEncoding(stgCodepage));
            }
        }
    }

    public class RtfProcessor : ITextProcessor
    {
        // Make it into a singleton
        private static readonly ITextProcessor _instance = new RtfProcessor();
        public static ITextProcessor GetInstance() { return _instance; }
        RichTextBox rtb;
        private RtfProcessor() { rtb = new RichTextBox(); }

        public string GetAllText(string path)
        {
            rtb.Rtf = File.ReadAllText(path);
            return rtb.Text;
        }
    }

    class PdfProcessor : ITextProcessor
    {
        // Make it into a singleton
        private static readonly ITextProcessor _instance = new PdfProcessor();
        public static ITextProcessor GetInstance() { return _instance; }
        private PdfProcessor() { }


        public string GetAllText(string path)
        {
            return pdfText(path);
        }

        public static string pdfText(string path)
        {
            PdfReader reader = new PdfReader(path);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                try
                {
                    text += PdfTextExtractor.GetTextFromPage(reader, page);
                }
                catch (Exception ex)
                {
                    //   Utils.ErrLog("Error processing page: " + page.ToString(), ex.Message);
                }
            }
            reader.Close();
            return text;
        }
    }

    public class OdtProcessor : ITextProcessor
    {
        // Make it into a singleton
        private static readonly ITextProcessor _instance = new OdtProcessor();
        public static ITextProcessor GetInstance() { return _instance; }
        private OdtProcessor() { }

        private const string ContentFileName = "content.xml";

        public string GetAllText(string path)
        {
            return Extract(new FileInfo(path).OpenRead());
        }


        public string Extract(Stream stream)
        {
            using (var zipArchive = new ZipArchive(stream))
            {
                var contentEntry = zipArchive.Entries.SingleOrDefault(x => x.Name == ContentFileName);

                if (contentEntry == null)
                    throw new InvalidOperationException("Can not find content.xml in ODT file");

                using (var contentEntryStream = contentEntry.Open())
                {
                    var document = XDocument.Load(contentEntryStream);

                    return document.Root?.Value;
                }
            }
        }
    }

    public sealed class DocxProcessor : ITextProcessor
    {
        // Make it into a singleton
        private static readonly ITextProcessor _instance = new DocxProcessor();
        public static ITextProcessor GetInstance() { return _instance; }
        private DocxProcessor() { }

        public string GetAllText(string path)
        {
            GetWordPlainText docxReaderObj = new GetWordPlainText(path);
            return docxReaderObj.ReadWordDocument();
        }
    }

    public sealed class DocProcessor : ITextProcessor
    {
        // Make it into a singleton
        private static readonly ITextProcessor _instance = new DocProcessor();
        public static ITextProcessor GetInstance() { return _instance; }
        static Microsoft.Office.Interop.Word.Application wordApplication; // Make only one instance to make it work faster
        private DocProcessor() { }

        public string GetAllText(string path)
        {
            try
            {
                if (wordApplication == null) wordApplication = new Microsoft.Office.Interop.Word.Application();
                var srcFile = new FileInfo(path);
                var doc = wordApplication.Documents.Open(srcFile.FullName);
                return doc.Content.Text;
            }
            finally
            {
                // we want to make sure the document is always closed 
                wordApplication.ActiveDocument.Close();
            }
        }

        public static void Dispose()
        {
            try
            {
                wordApplication.Quit();
            }
            catch (Exception ex)
            {
                //    Utils.ErrLog(ex);
            }
        }
    }


}
