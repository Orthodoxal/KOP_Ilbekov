using GroceryStoreContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreContracts.StoragesContracts
{
    public interface ICategoryStorage
    {
        List<CategoryViewModel> GetFullList();
        CategoryViewModel GetElement(CategoryViewModel model);
        void Insert(CategoryViewModel model);
        void Update(CategoryViewModel model);
        void Delete(CategoryViewModel model);
    }
}
