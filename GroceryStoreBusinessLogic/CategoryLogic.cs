using GroceryStoreContracts.BusinessLogicContracts;
using GroceryStoreContracts.StoragesContracts;
using GroceryStoreContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreBusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryStorage _categoryStorage;

        public CategoryLogic(ICategoryStorage categoryStorage)
        {
            _categoryStorage = categoryStorage;
        }
        List<CategoryViewModel> ICategoryLogic.Read(CategoryViewModel model)
        {
            if (model == null)
            {
                return _categoryStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CategoryViewModel> { _categoryStorage.GetElement(model)
};
            }
            return null;
        }

        void ICategoryLogic.CreateOrUpdate(CategoryViewModel model)
        {
            var element = _categoryStorage.GetElement(new CategoryViewModel { Name = model.Name });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Категория с таким именем уже существует");
            }
            if (model.Id.HasValue)
            {
                _categoryStorage.Update(model);
            }
            else
            {
                _categoryStorage.Insert(model);
            }
        }

        void ICategoryLogic.Delete(CategoryViewModel model)
        {
            var element = _categoryStorage.GetElement(new CategoryViewModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _categoryStorage.Delete(model);
        }
    }
}
