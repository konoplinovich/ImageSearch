using ClosedXML.Excel;
using FileCollector;
using ImageIndex;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media;

// Modify Excel file

namespace XlsxModifier
{
    public class XlsxEditor : IDisposable
    {
        private const string Suffix = "with images";

        private XLWorkbook workbook;
        private string xlsxfile;
        private int lastColumnNumber;
        private int lastRowNumber;
        private Collector collector;

        public List<string> Sheets { get { return GetSheetsNames(); } }
        public int FilesToCollect { get { return collector.Count; } }

        public XLColor R { get; set; }
        public XLColor W { get; set; }

        public XlsxEditor(string xlsxfile)
        {
            this.xlsxfile = xlsxfile;
            workbook = new XLWorkbook(xlsxfile);
        }

        public Tuple<int, string> Change(Index index, int sheet, string outputFolder, bool moveLinks)
        {
            collector = new Collector(outputFolder);
            IXLWorksheet worksheet = workbook.Worksheet(sheet + 1);
            lastColumnNumber = worksheet.LastColumnUsed(false).ColumnNumber();
            lastRowNumber = worksheet.LastRowUsed(false).RowNumber();

            int pluColumnNumber = GetPluColumn(xlsxfile, sheet + 1);

            int count = 0;
            Regex regex = new Regex(index.Pattern);

            foreach (IXLRow row in worksheet.Rows())
            {
                string pluValue = row.Cell(pluColumnNumber).Value.ToString();
                if (regex.Matches(pluValue).Count == 0) continue;
                List<string> searched = index.Search(pluValue);

                XLColor color = XLColor.NoColor;

                if (searched.Count != 0)
                {
                    StringBuilder fileNames = new StringBuilder();

                    if (moveLinks)
                    {
                        foreach (string file in searched)
                        {
                            collector.Add(file);
                            fileNames.Append($"{collector.GetCopyByOriginal(file)}");
                        }
                    }
                    else
                    {
                        foreach (string file in searched)
                        {
                            fileNames.Append($"{file}");
                        }
                    }

                    row.Cell(lastColumnNumber + 1).Value = searched.Count;
                    row.Cell(lastColumnNumber + 2).Value = fileNames.ToString();

                    color = R;

                    count++;
                }
                else
                {
                    color = W;
                }

                row.Style.Fill.BackgroundColor = color;
            }

            string ext = Path.GetExtension(xlsxfile);
            string folder = Path.GetDirectoryName(xlsxfile);
            string nameWithoutExt = $"{Path.GetFileNameWithoutExtension(xlsxfile)} {Suffix}{ext}";
            string newName = Path.Combine(folder, nameWithoutExt);

            workbook.SaveAs(newName, true);

            return new Tuple<int, string>(count, newName);
        }

        public async Task<int> CollectFiles(IProgress<Tuple<string, string, int, int>> progress)
        {
            int count = await collector.Copy(progress);
            return count;
        }

        private int GetPluColumn(string path, int sheet)
        {
            int column = 1;
            string val = "";

            XLWorkbook workbook = new XLWorkbook(path);
            IXLWorksheet worksheet = workbook.Worksheet(sheet);

            foreach (IXLRow row in worksheet.Rows())
            {
                foreach (IXLCell cell in row.Cells())
                {
                    if (cell.HasFormula) continue;

                    bool success = cell.TryGetValue(out val);
                    if (!success) continue;

                    if (val.IndexOf("plu", StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        column = cell.Address.ColumnNumber;

                        workbook.Dispose();
                        GC.Collect();
                        return column;
                    }
                }
            }

            workbook.Dispose();
            GC.Collect();
            return column;
        }

        private List<string> GetSheetsNames()
        {
            List<string> names = new List<string>();

            foreach (var s in workbook.Worksheets)
            {
                names.Add(s.Name);
            }

            return names;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    workbook.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}