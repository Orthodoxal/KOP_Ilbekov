using GroceryStoreContracts.StoragesContracts;
using GroceryStoreContracts.ViewModels;
using GroceryStoreDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreDatabase.Implements
{
    public class ProductStorage : IProductStorage
    {
        public List<ProductViewModel> GetFullList()
        {
            using (var context = new GroceryStoreDatabase())
            {
                return context.Products.Select(CreateModel).ToList();
            }
        }

        public ProductViewModel GetElement(ProductViewModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new GroceryStoreDatabase())
            {
                var product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                return product != null ? CreateModel(product) : null;
            }
        }

        public void Insert(ProductViewModel model)
        {
            using (var context = new GroceryStoreDatabase())
            {
                context.Products.Add(CreateModel(model, new Product()));
                context.SaveChanges();
            }
        }

        public void Update(ProductViewModel model)
        {
            using (var context = new GroceryStoreDatabase())
            {
                Product product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (product == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, product);
                context.SaveChanges();
            }
        }

        public void Delete(ProductViewModel model)
        {
            using (var context = new GroceryStoreDatabase())
            {
                Product product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private ProductViewModel CreateModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Count = product.Count
            };
        }

        private Product CreateModel(ProductViewModel model, Product product)
        {
            product.Name = model.Name;
            product.Description = model.Description;
            product.Category = model.Category;
            product.Count = model.Count;
            return product;
        }
    }
}
