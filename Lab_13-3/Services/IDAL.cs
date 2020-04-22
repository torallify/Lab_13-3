using Lab_13_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_13_3.Services
{
    public interface IDAL
    {
        public IEnumerable<Product> GetProductsAll();
        public IEnumerable<Order> GetOrdersAll();
        public IEnumerable<OrderDetail> GetOrderDetailsAll();
        public IEnumerable<Order> GetOrdersByCountry(string country);
    }
}
