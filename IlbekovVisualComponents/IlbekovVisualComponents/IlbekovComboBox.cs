using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IlbekovVisualComponents
{
    public partial class IlbekovComboBox : UserControl
    {
        private event EventHandler selectedIndexChanged;

        public string ChoosenItem
        {
            set
            {
                if (comboBox.Items.Contains(value))
                {
                    comboBox.SelectedIndex = comboBox.Items.IndexOf(value); ;
                }
            }
            get
            {
                if (comboBox != null && comboBox.SelectedItem != null)
                {
                    return comboBox.SelectedItem.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
        public IlbekovComboBox()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) => selectedIndexChanged?.Invoke(sender, e);
        }

        public void AddItem(string item)
        {
            comboBox.Items.Add(item);
        }

        public void Clear()
        {
            comboBox.Items.Clear();
            comboBox.ResetText();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
            base.OnSizeChanged(e);
        }

        public event EventHandler SelectedIndexChanged
        {
            add { selectedIndexChanged += value; }
            remove { selectedIndexChanged -= value; }
        }
    }
}
