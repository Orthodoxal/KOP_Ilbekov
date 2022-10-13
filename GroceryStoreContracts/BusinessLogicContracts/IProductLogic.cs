using GroceryStoreContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreContracts.BusinessLogicContracts
{
    public interface IProductLogic
    {
        List<ProductViewModel> Read(ProductViewModel model);
        void CreateOrUpdate(ProductViewModel model);
        void Delete(ProductViewModel model);
    }
}
