using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreContracts.ViewModels
{
    public class ProductViewModel
    {
        [DisplayName("Идентификатор")]
        public int? Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Категория")]
        public string Category { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
