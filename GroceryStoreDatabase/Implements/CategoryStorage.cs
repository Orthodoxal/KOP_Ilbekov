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
    public class CategoryStorage : ICategoryStorage
    {
        public List<CategoryViewModel> GetFullList()
        {
            using (var context = new GroceryStoreDatabase())
            {
                return context.Categories.Select(CreateModel).ToList();
            }
        }

        public CategoryViewModel GetElement(CategoryViewModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new GroceryStoreDatabase())
            {
                var category = context.Categories.FirstOrDefault(rec => rec.Id == model.Id);
                return category != null ? CreateModel(category) : null;
            }
        }

        public void Insert(CategoryViewModel model)
        {
            using (var context = new GroceryStoreDatabase())
            {
                context.Categories.Add(CreateModel(model, new Category()));
                context.SaveChanges();
            }
        }

        public void Update(CategoryViewModel model)
        {
            using (var context = new GroceryStoreDatabase())
            {
                Category category = context.Categories.FirstOrDefault(rec => rec.Id == model.Id);
                if (category == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, category);
                context.SaveChanges();
            }
        }

        public void Delete(CategoryViewModel model)
        {
            using (var context = new GroceryStoreDatabase())
            {
                Category category = context.Categories.FirstOrDefault(rec => rec.Id == model.Id);
                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private CategoryViewModel CreateModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        private Category CreateModel(CategoryViewModel model, Category category)
        {
            category.Name = model.Name;
            return category;
        }
    }
}
