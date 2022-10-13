using GroceryStoreContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreContracts.BusinessLogicContracts
{
    public interface ICategoryLogic
    {
        List<CategoryViewModel> Read(CategoryViewModel model);
        void CreateOrUpdate(CategoryViewModel model);
        void Delete(CategoryViewModel model);
    }
}
