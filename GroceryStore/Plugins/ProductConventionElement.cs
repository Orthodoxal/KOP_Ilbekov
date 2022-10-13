using GroceryStoreContracts.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Plugins
{
    public class ProductConventionElement : PluginsConventionElement
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double? Count { get; set; }
    }
}
