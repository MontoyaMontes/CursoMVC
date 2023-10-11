using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class SellDetail
    {
        public int IdSellDetail { get; set; }
        public int IdSell { get; set; }
        public Product objProduct { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string IdTransaction { get; set; }

    }
}
