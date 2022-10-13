using GroceryStoreContracts.BusinessLogicContracts;
using GroceryStoreContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStore
{
    public partial class FormUnits : Form
    {
        private ICategoryLogic _categoryLogic;
        List<CategoryViewModel> list;
        public FormUnits(ICategoryLogic categoryLogic)
        {
            InitializeComponent();
            _categoryLogic = categoryLogic;
        }
        private void LoadData()
        {
            try
            {
                list = _categoryLogic.Read(null);
                if (list != null)
                {
                    dataGridViewUnits.DataSource = list;
                    dataGridViewUnits.Columns[0].Visible = false;
                    dataGridViewUnits.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormUnits_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridViewUnits_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var typeName = (string)dataGridViewUnits.CurrentRow.Cells[1].Value;
            if (!string.IsNullOrEmpty(typeName))
            {
                int? id;
                if (dataGridViewUnits.CurrentRow.Cells[0].Value == null)
                    id = null;
                else
                    id = Convert.ToInt32(dataGridViewUnits.CurrentRow.Cells[0].Value);

                _categoryLogic.CreateOrUpdate(new CategoryViewModel
                {
                    Id = id,
                    Name = (string)dataGridViewUnits.CurrentRow.Cells[1].EditedFormattedValue
                });
            }
            else
            {
                MessageBox.Show("Введена пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void dataGridViewUnits_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                if (dataGridViewUnits.Rows.Count == 0)
                {
                    list.Add(new CategoryViewModel());
                    dataGridViewUnits.DataSource = new List<CategoryViewModel>(list);
                    dataGridViewUnits.CurrentCell = dataGridViewUnits.Rows[0].Cells[1];
                    return;
                }
                if (dataGridViewUnits.Rows[dataGridViewUnits.Rows.Count - 1].Cells[1].Value != null)
                {
                    list.Add(new CategoryViewModel());
                    dataGridViewUnits.DataSource = new List<CategoryViewModel>(list);
                    dataGridViewUnits.CurrentCell = dataGridViewUnits.Rows[dataGridViewUnits.Rows.Count - 1].Cells[1];
                    return;
                }
            }
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Удалить выбранный элемент", "Удаление",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _categoryLogic.Delete(new CategoryViewModel() { Id = (int)dataGridViewUnits.CurrentRow.Cells[0].Value });
                    LoadData();
                }
            }
        }
    }
}
