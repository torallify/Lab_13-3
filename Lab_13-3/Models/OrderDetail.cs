using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_13_3.Models
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Single Discount { get; set; }

    }
}
