using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestComponentsProject
{
    public partial class TestForm : Form
    {
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
            ilbekovListBox.Add<Test1>(new Test1 { Header = "H1", Description = "D1"});
            ilbekovListBox.Add<Test1>(new Test1 { Header = "H2", Description = "D2"});
            ilbekovListBox.Add<Test1>(new Test1 { Header = "H3", Description = "D3"});
            ilbekovListBox.Add<Test1>(new Test1 { Header = "H4", Description = "D4"});
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
            } catch(Exception ex) 
            {
                labelCheckedText.Text = ex.Message;
            }
        }

        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            try
            {
                //Test1? test = ilbekovListBox.GetSelectedItem<Test1>();
                Test1? test = ilbekovListBox.GetSI<Test1>();
                if (test != null)
                {
                    labelItemFromList.Text = test.Header + " " + test.Description;
                }
            } catch(Exception ex) { labelItemFromList.Text = ex.Message; }
        }
    }
}
