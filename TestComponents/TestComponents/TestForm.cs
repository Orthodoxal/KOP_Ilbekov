using IlbekovNonVisualComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestComponents
{
    public partial class TestForm : Form
    {
        private Pet[] pets = {
            new Pet() {
                Name = "cat",
                Age = 5,
                Description = "Bla bla"
            },
            new Pet() {
                Name = "dog",
                Age = 6,
                Description = "Bla bla1"
            },
             new Pet() {
                Name = "parrot",
                Age = 5,
                Description = "Bla bla2"
            }
        };
        private Person[] persons = {
            new Person("Oleg", 20, "bla", 15000, "xxxx", "yyyy"),
            new Person("Alex", 25, "bla", 25000, "xxxx", "yyyy"),
            new Person("Danil", 29, "bla", 55500, "xxxx", "yyyy")
        };

        public class Test1
        {
            public string Header { get; set; }
            public string Description { get; set; }
        }
        public TestForm()
        {
            InitializeComponent();
            // comboBox
            ilbekovComboBox.AddItem("testItem1");
            ilbekovComboBox.AddItem("testItem2");
            ilbekovComboBox.AddItem("testItem3");
            // textBox
            ilbekovTextBox.AddToolTipText("Example: 05.10.2022");
            ilbekovTextBox.Template = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";
            // listBox
            ilbekovListBox.SetTemplate("Blabla {Header} bla {Description}", '{', '}');
            ilbekovListBox.Add<Test1>(new Test1 { Header = "H1", Description = "D1" });
            ilbekovListBox.Add<Test1>(new Test1 { Header = "H2", Description = "D2" });
            ilbekovListBox.Add<Test1>(new Test1 { Header = "H3", Description = "D3" });
            ilbekovListBox.Add<Test1>(new Test1 { Header = "H4", Description = "D4" });
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ilbekovComboBox.Clear();
        }

        private void buttonGetSelectedItem_Click(object sender, EventArgs e)
        {
            labelItem.Text = ilbekovComboBox.ChoosenItem;
        }

        private void buttonSetSelectedItem_Click(object sender, EventArgs e)
        {
            ilbekovComboBox.ChoosenItem = textBoxSetItem.Text;
        }

        private void buttonGetTextFromTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                labelCheckedText.Text = ilbekovTextBox.CurrentValue;
            }
            catch (Exception ex)
            {
                labelCheckedText.Text = ex.Message;
            }
        }

        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            try
            {
                //Test1? test = ilbekovListBox.GetSelectedItem<Test1>();
                Test1 test = ilbekovListBox.GetSI<Test1>();
                if (test != null)
                {
                    labelItemFromList.Text = test.Header + " " + test.Description;
                }
            }
            catch (Exception ex) { labelItemFromList.Text = ex.Message; }
        }

        private void buttonGetContextExcel_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var doc = new IlbekovContextExcel();
                doc.CreateFile(fbd.SelectedPath + "/Context Report.xls", "Header example", new string[] 
                { 
                    "First string",
                    "Second string",
                    "Third string",
                    "Fourth string" 
                }.ToList()
                );
                MessageBox.Show("Report created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonGetConfigTableExcel_Click(object sender, EventArgs e)
        {
            List<List<string>> tableHeaderList = new List<List<string>>();
            tableHeaderList.Add(new List<string>() { "First column" });
            tableHeaderList.Add(new List<string>() { "Second column", "SecCol1", "SecCol2", "SecCol3" });
            tableHeaderList.Add(new List<string>() { "Third column" });
            tableHeaderList.Add(new List<string>() { "Fourth column", "FourthCol1" });
            var columnSizes = new double?[] { null, null, null, null, 45, 30, 15 }.ToList();
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var doc = new IlbekovTableExcel();
                doc.CreateFile<Person>(fbd.SelectedPath + "/Table Report.xls", "Header", tableHeaderList, persons.ToList(), columnSizes);
                MessageBox.Show("Report created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonGetLineChartExcel_Click(object sender, EventArgs e)
        {
            List<IlbekovLineChartExcel.ChartSeries> chartSeriesList = new List<IlbekovLineChartExcel.ChartSeries>();
            chartSeriesList.Add(new IlbekovLineChartExcel.ChartSeries
            {
                Name = "First object",
                Values = new double[] { 15, 18, 19.5, 23.45, 12, 17.5 }
            });
            chartSeriesList.Add(new IlbekovLineChartExcel.ChartSeries
            {
                Name = "Second object",
                Values = new double[] { 13, 16, 18.2, 21.72, 20, 25.9 }
            });
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var doc = new IlbekovLineChartExcel();
                doc.CreateFile(
                    fbd.SelectedPath + "/Line Chart Report.xls",
                    "Header", "Chart header",
                    chartSeriesList,
                    IlbekovLineChartExcel.LegendPosition.Bottom,
                    _xSeries: new string[] { "Pos1", "Pos2", "Pos3", "Pos4", "Pos5", "Pos6" });
                MessageBox.Show("Report created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
