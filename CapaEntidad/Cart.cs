using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cart
    {
        public int IdCart { get; set; }
        public Client objClient { get; set; }
        public Product objProduct { get; set; }
        public int Quantity { get; set; }
    }
}
