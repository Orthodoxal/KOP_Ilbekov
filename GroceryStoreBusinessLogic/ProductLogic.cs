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
    public class ProductLogic : IProductLogic
    {
        private readonly IProductStorage _productStorage;

        public ProductLogic(IProductStorage productStorage)
        {
            _productStorage = productStorage;
        }
        List<ProductViewModel> IProductLogic.Read(ProductViewModel model)
        {
            if (model == null)
            {
                return _productStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { _productStorage.GetElement(model)
};
            }
            return null;
        }

        void IProductLogic.CreateOrUpdate(ProductViewModel model)
        {
            var element = _productStorage.GetElement(new ProductViewModel { Name = model.Name });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Продукт с таким именем уже существует");
            }
            if (model.Id.HasValue)
            {
                _productStorage.Update(model);
            }
            else
            {
                _productStorage.Insert(model);
            }
        }

        void IProductLogic.Delete(ProductViewModel model)
        {
            var element = _productStorage.GetElement(new ProductViewModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _productStorage.Delete(model);
        }
    }
}
