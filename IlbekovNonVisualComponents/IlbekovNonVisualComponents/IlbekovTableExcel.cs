using Microsoft.Office.Interop.Excel;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace IlbekovNonVisualComponents
{
    public partial class IlbekovTableExcel : Component
    {
        public IlbekovTableExcel()
        {
            InitializeComponent();
        }

        public IlbekovTableExcel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateFile<T>(string path, string titleName, List<List<string>> titles, List<T> text, List<double?> columnWidth = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new MyException("File path is not correct");
            }
            if (string.IsNullOrEmpty(titleName))
            {
                throw new MyException("Header is empty");
            }
            if (titles == null)
            {
                throw new MyException("List of headers is empty");
            }
            if (text == null)
            {
                throw new MyException("List of objects is empty");
            }
            if (!File.Exists(path))
            {
                Application excel = new Application { SheetsInNewWorkbook = 1, Visible = false, DisplayAlerts = false };
                Excel.Workbook workBook = excel.Workbooks.Add(Type.Missing);
                Excel.Worksheet sheet = (Excel.Worksheet)excel.Worksheets.get_Item(1);
                sheet.Cells[1, 1] = titleName;
                List<string> textProperties = new List<string>();
                int indexX = 1;
                foreach (var element in titles)
                {
                    int indexY = 2;
                    if (element.Count() == 1)
                    {
                        sheet.Cells[indexY, indexX] = element.ElementAt(0);
                        var mergeCells = sheet.Range[sheet.Cells[indexY, indexX], sheet.Cells[indexY + 1, indexX]];
                        mergeCells.Merge(Type.Missing);
                        textProperties.Add(element.ElementAt(0));
                        indexX++;
                    }
                    else
                    {
                        sheet.Cells[indexY, indexX] = element.ElementAt(0);
                        var mergeCells = sheet.Range[sheet.Cells[indexY, indexX], sheet.Cells[indexY, indexX + element.Count() - 2]];
                        mergeCells.Merge(Type.Missing);
                        indexY++;
                        for (int number = 1; number < element.Count(); number++)
                        {
                            sheet.Cells[indexY, indexX] = element.ElementAt(number);
                            textProperties.Add(element.ElementAt(number));
                            indexX++;
                        }
                    }
                }
                int indexO = 4;
                foreach (var element in text)
                {
                    var properties = element.GetType().GetProperties();
                    var countProperties = properties.Length;
                    for (int i = 0; i < countProperties; i++)
                    {
                        PropertyInfo property = properties[i];
                        if (property.PropertyType != null)
                            sheet.Cells[indexO, i + 1] = property.GetValue(element).ToString();
                        else
                            throw new MyException("Property is not correct or null");
                    }
                    indexO++;
                }

                var rangeTitle = sheet.Range[sheet.Cells[1, 1], sheet.Cells[3, textProperties.Count()]];
                var rangeText = sheet.Range[sheet.Cells[4, 1], sheet.Cells[text.Count + 3, textProperties.Count()]];
                rangeTitle.Cells.Style.VerticalAlignment = VerticalAlignType.Bottom;
                rangeTitle.Cells.Style.HorizontalAlignment = HorizontalAlignType.Right;
                rangeTitle.Cells.Font.Size = 12;
                rangeTitle.Cells.Font.Bold = true;
                rangeText.Cells.Font.Size = 12;
                sheet.Columns.EntireColumn.AutoFit();
                if (columnWidth != null)
                {
                    for (int indexColumn = 1; indexColumn <= textProperties.Count(); indexColumn++)
                    {
                        if (columnWidth.ElementAt(indexColumn - 1) != null)
                        {
                            string index = NumberToLetters(indexColumn);
                            index = index + ":" + index;
                            sheet.Columns[index].ColumnWidth = columnWidth.ElementAt(indexColumn - 1);
                        }
                    }
                }
                excel.Application.ActiveWorkbook.SaveAs(path, XlSaveAsAccessMode.xlNoChange);
                excel.Quit();
            }
            else
            {
                throw new MyException("File with the same name if already exist");
            }
        }
        private string NumberToLetters(int number)
        {
            string result;
            if (number > 0)
            {
                int alphabets = (number - 1) / 26;
                int remainder = (number - 1) % 26;
                result = ((char)('A' + remainder)).ToString();
                if (alphabets > 0)
                    result = NumberToLetters(alphabets) + result;
            }
            else
                result = null;
            return result;
        }
        class MyException : Exception
        {
            public MyException(string message) : base(message) { }
        }
    }
}
