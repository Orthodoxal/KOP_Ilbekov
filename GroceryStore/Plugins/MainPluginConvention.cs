using GroceryStoreContracts.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LipatovVisualComponents;
using GroceryStoreContracts.ViewModels;
using GroceryStoreContracts.BusinessLogicContracts;
using GroceryStoreBusinessLogic;
using Unity;

namespace GroceryStore.Plugins
{
    public class MainPluginConvention : IPluginsConvention
    {
        private LipatovTreeView treeView = new LipatovTreeView();
        private IProductLogic _productLogic;

        public MainPluginConvention(IProductLogic productLogiс)
        {
            _productLogic = productLogiс;
            ReloadData();
        }
        public string PluginName => "Продукты";

        public UserControl GetControl => treeView;

        public PluginsConventionElement GetElement => treeView.GetSelectedNode<ProductConventionElement>();

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            throw new NotImplementedException();
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            throw new NotImplementedException();
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            throw new NotImplementedException();
        }

        public bool DeleteElement(PluginsConventionElement element)
        {
            try
            {
                _productLogic.Delete(new ProductViewModel() { Id = element.Id });
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public Form GetForm(PluginsConventionElement element)
        {
            return Program.Container.Resolve<FormProduct>();
        }

        public void ReloadData()
        {
            treeView.Dispose();
            treeView = new LipatovTreeView();
            treeView.SetHierarchy(new List<string> { "Category", "Count", "Id", "Name" });
            _productLogic.Read(null).ForEach(product => treeView.AddItem(new ProductConventionElement 
            { 
                Id = (int)product.Id,
                Name = product.Name,
                Category = product.Category,
                Count = product.Count
            }));
        }
    }
}
