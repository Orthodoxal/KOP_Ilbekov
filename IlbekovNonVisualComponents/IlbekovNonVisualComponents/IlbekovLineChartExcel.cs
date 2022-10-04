using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlbekovNonVisualComponents
{
    public partial class IlbekovLineChartExcel : Component
    {
        public struct ChartSeries
        {
            public string Name { get; set; }
            public double[] Values { get; set; }
        }
        public enum LegendPosition
        {
            Top = 1,
            Right = 2,
            Bottom = 3,
            Left = 4
        }
        public IlbekovLineChartExcel()
        {
            InitializeComponent();
        }

        public IlbekovLineChartExcel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void CreateFile(string path,
            string docTitle,
            string diagTitle,
            List<ChartSeries> data,
            LegendPosition chartLocation = LegendPosition.Bottom,
            string Ox = "X",
            string Oy = "Y",
            string[] _xSeries = null)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new MyException("File path is not correct");
            }
            if (string.IsNullOrEmpty(docTitle))
            {
                throw new MyException("Header is empty");
            }
            if (string.IsNullOrEmpty(diagTitle))
            {
                throw new MyException("Chart header is empty");
            }
            if (data == null)
            {
                throw new MyException("Data list is empty");
            }
            Application excel = new Application();
            Workbook book;
            Worksheet sheet;
            book = excel.Workbooks.Add(System.Reflection.Missing.Value);
            sheet = (Worksheet)book.Sheets[1];
            Chart excelchart = (Chart)excel.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelchart.Activate();
            excelchart.Select(Type.Missing);
            excel.ActiveChart.ChartType = XlChartType.xlLineMarkers;
            excel.ActiveChart.HasTitle = true;
            excel.ActiveChart.ChartTitle.Text = diagTitle;
            excel.ActiveChart.ChartTitle.Font.Size = 14;
            excel.ActiveChart.ChartTitle.Font.Color = 255;
            ((Axis)excel.ActiveChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Axis)excel.ActiveChart.Axes(XlAxisType.xlCategory,
                XlAxisGroup.xlPrimary)).AxisTitle.Text = Ox;
            ((Axis)excel.ActiveChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary)).HasTitle = true;
            ((Axis)excel.ActiveChart.Axes(XlAxisType.xlValue,
                XlAxisGroup.xlPrimary)).AxisTitle.Text = Oy;
            excel.ActiveChart.HasLegend = true;
            //Расположение легенды
            switch (chartLocation)
            {
                case LegendPosition.Top:
                    {
                        excel.ActiveChart.Legend.Position = XlLegendPosition.xlLegendPositionTop;
                        break;
                    }
                case LegendPosition.Right:
                    {
                        excel.ActiveChart.Legend.Position = XlLegendPosition.xlLegendPositionRight;
                        break;
                    }
                case LegendPosition.Bottom:
                    {
                        excel.ActiveChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom;
                        break;
                    }
                case LegendPosition.Left:
                    {
                        excel.ActiveChart.Legend.Position = XlLegendPosition.xlLegendPositionLeft;
                        break;
                    }
                default:
                    {
                        excel.ActiveChart.Legend.Position = XlLegendPosition.xlLegendPositionBottom;
                        break;
                    }
            }

            SeriesCollection seriesCollection = (SeriesCollection)excel.ActiveChart.SeriesCollection(Type.Missing);
            int index = 1;
            foreach (var element in data)
            {
                var this_series = seriesCollection.NewSeries();
                this_series.Name = data.ElementAt(index - 1).Name;
                this_series.Values = data.ElementAt(index - 1).Values;
                if (_xSeries != null)
                {
                    this_series.XValues = _xSeries;
                }
                index++;
            }

            excel.ActiveChart.Location(XlChartLocation.xlLocationAsObject, "Лист1");
            var excelsheets = book.Worksheets;
            sheet = (Worksheet)excelsheets.get_Item(1);
            sheet.Shapes.Item(1).Height = 450;
            sheet.Shapes.Item(1).Width = 500;
            sheet.Cells[1, 1] = docTitle;
            excel.Application.ActiveWorkbook.SaveAs(path, XlSaveAsAccessMode.xlNoChange);
            excel.Quit();
        }
        class MyException : Exception
        {
            public MyException(string message): base(message) { }
        }
    }
}
