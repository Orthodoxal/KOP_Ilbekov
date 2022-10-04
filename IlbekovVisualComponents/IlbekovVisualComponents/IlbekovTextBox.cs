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

namespace IlbekovVisualComponents
{
    public partial class IlbekovTextBox : UserControl
    {
        private event EventHandler textChanged;
        private string toolTipText = "No tooltip";
        private string template = "";
        public string Template
        {
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                template = value;
            }
            get
            {
                return template;
            }
        }
        public string CurrentValue
        {
            set
            {
                if (template != "" && !Regex.IsMatch(value, template))
                {
                    textBox.Text = value;
                }
            }
            get
            {
                if (textBox.Text == null)
                    throw new ArgumentNullException("value");
                if (template == "")
                    throw new Exception("No template");
                if (!Regex.IsMatch(textBox.Text, template))
                {
                    throw new Exception("Invalid format");
                }
                return textBox.Text;
            }
        }
        public IlbekovTextBox()
        {
            InitializeComponent();
            textBox.TextChanged += (sender, e) => textChanged?.Invoke(sender, e);
        }

        public void AddToolTipText(string toolTip)
        {
            toolTipText = toolTip;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox myTextBox = (TextBox)sender;
            int VisibleTime = 3000;  //in milliseconds

            ToolTip toolTip = new ToolTip();
            toolTip.Show(toolTipText, myTextBox, 10, -25, VisibleTime);
        }

        public event EventHandler TextChangedEvent
        {
            add { textChanged += value; }
            remove { textChanged -= value; }
        }
    }
}
