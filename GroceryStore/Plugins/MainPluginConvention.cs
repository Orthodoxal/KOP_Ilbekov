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
using IlbekovNonVisualComponents;
using MadyshevUnvisualComponents;
using MadyshevUnvisualComponents.Models;
using LipatovNonVisualComponents;
using LipatovNonVisualComponents.HelperModels;
using LipatovNonVisualComponents.Enums;

namespace GroceryStore.Plugins
{
    public class MainPluginConvention : IPluginsConvention
    {
        private LipatovTreeView treeView = new LipatovTreeView();
        private IProductLogic _productLogic;
        private ICategoryLogic _categoryLogic;

        public MainPluginConvention(IProductLogic productLogiс, ICategoryLogic categoryLogic)
        {
            _productLogic = productLogiс;
            _categoryLogic = categoryLogic;
            treeView.SetHierarchy(new List<string> { "Category", "Count", "Id", "Name" });
            ReloadData();
        }
        public string PluginName => "Продукты";

        public UserControl GetControl => treeView;

        public PluginsConventionElement GetElement => treeView.GetSelectedNode<ProductConventionElement>();

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                LipatovChartPdf chartPdf = new LipatovChartPdf();
                var data = new List<LipatovNonVisualComponents.HelperModels.ChartData>();
                foreach (var category in _categoryLogic.Read(null))
                {
                    int count = _productLogic.Read(null)
                        .Where(product => product.Category == category.Name && product.Count == null)
                        .Count();
                    if (count > 0)
                    {
                        data.Add(new LipatovNonVisualComponents.HelperModels.ChartData() { Series = count, XSeries = category.Name });
                    }
                }
                chartPdf.CreateDocument(new ChartParameters()
                {
                    Path = saveDocument.FileName,
                    Title = "Продукты",
                    ChartName = "Отсутствующие продукты",
                    ChartLegendLocation = ChartLegendLocation.Right,
                    Data = data
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
            
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                IlbekovContextExcel contextExcel = new IlbekovContextExcel();
                var strings = new List<string>();
                _productLogic.Read(null).ForEach(product => 
                {
                    if (product.Count != null)
                        strings.Add($"{product.Name} - {product.Description}");
                });
                contextExcel.CreateFile(saveDocument.FileName, "Продукты", strings);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                MadyshevCustomTableComponent tableWord = new MadyshevCustomTableComponent();
                tableWord.CreateDoc(new CustomTableData<ProductViewModel>()
                {
                    FileName = saveDocument.FileName,
                    Title = "Продукты",
                    HeaderHeight = 1200,
                    RowsHeight = 800,
                    ColumnsHeaders = new List<string>()
                                {
                                "Идентификатор", "Название", "Описание", "Категория", "Количество"
                                },
                    ColumnsWidth = new List<int>()
                                {
                                1000, 1000, 1000, 800
                                },
                    ColumnsProperties = new List<string>()
                                {
                                "Id", "Name", "Description", "Category", "Count"
                                },
                    Data = _productLogic.Read(null)
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
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
            var form = Program.Container.Resolve<FormProduct>();
            if (element != null)
                form.Id = element.Id;
            return form;
        }

        public void ReloadData()
        {
            treeView.Clear();
            //treeView.SetHierarchy(new List<string> { "Category", "Count", "Id", "Name" });
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
