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

        public OrderDetail GetOrderDetailById(int id);
        public Product GetProductById(int id);

        public int CreateProduct(Product p);
        public int CreateOrder(Order o);
        public int DeleteOrderDetailById(int id);

        public int DeleteProductById(int id);
    }
}
