using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace IlbekovNonVisualComponents
{
    public partial class IlbekovContextExcel : Component
    {
        public IlbekovContextExcel()
        {
            InitializeComponent();
        }

        public IlbekovContextExcel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void CreateFile(string path, string titleName, List<string> text)
        {
            if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(titleName) && text != null)
            {
                if (!File.Exists(path))
                {
                    Application excel = new Application { SheetsInNewWorkbook = 1, Visible = false, DisplayAlerts = false };
                    Workbook workBook = excel.Workbooks.Add(Type.Missing);
                    Worksheet sheet = (Worksheet)excel.Worksheets.get_Item(1);
                    sheet.Cells[1, 1] = titleName;
                    int index = 3;
                    foreach (var element in text)
                    {
                        sheet.Cells[index, 1] = element;
                        index++;
                    }
                    var rangeTitle = sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 1]];
                    var rangeText = sheet.Range[sheet.Cells[3, 1], sheet.Cells[1, text.Count + 2]];
                    rangeTitle.Cells.Font.Size = 12;
                    rangeTitle.Cells.Font.Bold = true;
                    rangeText.Cells.Font.Size = 12;
                    sheet.Columns[1].ColumnWidth = 55;
                    excel.Application.ActiveWorkbook.SaveAs(path, XlSaveAsAccessMode.xlNoChange);
                    excel.Quit();
                }
                else
                {
                    throw new MyException("File with the same name if already exist");
                }
            }
            else
            {
                throw new MyException("At least one argument is empty");
            }
        }
        class MyException : Exception
        {
            public MyException(string message)
                : base(message)
            { }
        }
    }
}
