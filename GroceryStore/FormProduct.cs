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
    public partial class FormProduct : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private IProductLogic _productLogic;
        private ICategoryLogic _categoryLogic;
        private bool flagChanges = false;

        public FormProduct(IProductLogic productLogiс, ICategoryLogic categoryLogic)
        {
            InitializeComponent();
            _productLogic = productLogiс;
            _categoryLogic = categoryLogic;
            _categoryLogic.Read(null).ForEach(category => ilbekovComboBoxCategory.AddItem(category.Name));

            ilbekovComboBoxCategory.SelectedIndexChanged += DataChanged;
            madyshevTextBoxCount.CheckedChanged += DataChanged;
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _productLogic.Read(new ProductViewModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        textBoxDescription.Text = view.Description;
                        ilbekovComboBoxCategory.ChoosenItem = view.Category;
                        madyshevTextBoxCount.TextBoxValue = view.Count;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            flagChanges = false;
        }

        private void DataChanged(object sender, EventArgs e)
        {
            flagChanges = true;
        }

        private void save()
        {
            if (textBoxName.Text != "" && textBoxDescription.Text != "" && ilbekovComboBoxCategory.ChoosenItem != "")
            {
                try
                {
                    _productLogic.CreateOrUpdate(new ProductViewModel
                    {
                        Id = id,
                        Name = textBoxName.Text,
                        Description = textBoxDescription.Text,
                        Category = ilbekovComboBoxCategory.ChoosenItem,
                        Count = madyshevTextBoxCount.TextBoxValue
                    });
                    flagChanges = false;
                    DialogResult = DialogResult.OK;
                    Close();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Все поля кроме количества обязательны к заполнению");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void FormProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flagChanges)
            {
                if (MessageBox.Show("Сохранить изменения перед закрытием?", "Закрыть", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    save();
                }
            }
        }
    }
}
