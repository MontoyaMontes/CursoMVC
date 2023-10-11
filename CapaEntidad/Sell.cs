using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Sell
    {
        public int IdSell { get; set; }
        public int IdClient { get; set; }
        public int TotalProduct { get; set; }
        public decimal TotalAmount { get; set; }
        public string Contact { get; set; }
        public string IdDistrict { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }
        public string IdTransaction { get; set; }
        public string DateSell { get; set; }
        public List<SellDetail>  objSellDetail { get; set; }
    }
}
