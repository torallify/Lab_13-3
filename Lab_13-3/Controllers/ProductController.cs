using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_13_3.Models;
using Lab_13_3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_13_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IDAL dal;

        public ProductController(IDAL dalObject)
        {
            dal = dalObject;
        }

        [HttpGet("{id}")]
        public Product GetSingleProduct(int id)
        {
            Product Prod = dal.GetProductById(id);
            return Prod; //serialize the parameter into JSON and return an Ok (20x)

        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            IEnumerable<Product> Products = dal.GetProductsAll();
            return Products; //serialize the parameter into JSON and return an Ok (20x

            // TODO: Add something to this
            //if (country == null)
            //{
            //    IEnumerable<Order> Orders = dal.GetOrdersAll();
            //    return Orders; //serialize the parameter into JSON and return an Ok (20x)
            //}

            //else
            //{
            //    IEnumerable<Order> Orders = dal.GetOrdersByCountry(country);
            //    return Orders;
            //}
        }

        [HttpPost]
        public Object Post(Product p)
        {
            int newId = dal.CreateProduct(p);
            if (newId < 0)
            {
                return new { success = false };
            }

            return new { status = true, id = newId };
        }

        [HttpDelete("Delete/{id}")]
        public Object Delete(int id)
        {
            int result = dal.DeleteProductById(id);
            if (result >= 0)
            {
                return new { success = true };
            }
            else
            {
                return new { success = false };
            }
        }
    }
}