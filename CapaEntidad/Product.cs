using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public Brand objBrand { get; set; }
        public Category objCategory { get; set; }
        public decimal Price { get; set; }

        public string PriceText { get; set; }
        public int Stock { get; set; }
        public string ImageName { get; set; }
        public string ImageRoute { get; set; }
        public bool Active { get; set; }
        public string Base64 { get; set; }
        public string ExtensionImage { get; set; }
    }
}
