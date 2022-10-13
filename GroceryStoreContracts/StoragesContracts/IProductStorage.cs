using GroceryStoreContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreContracts.StoragesContracts
{
    public interface IProductStorage
    {
        List<ProductViewModel> GetFullList();
        ProductViewModel GetElement(ProductViewModel model);
        void Insert(ProductViewModel model);
        void Update(ProductViewModel model);
        void Delete(ProductViewModel model);
    }
}
