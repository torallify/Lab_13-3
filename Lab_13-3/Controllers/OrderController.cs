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
    public class OrderController : ControllerBase
    {
        private IDAL dal;

        public OrderController(IDAL dalObject)
        {
            dal = dalObject;
        }
        [HttpGet]
        public IEnumerable<Order> Get(string country)
        {
            if (country == null)
            {
                IEnumerable<Order> Orders = dal.GetOrdersAll();
                return Orders; //serialize the parameter into JSON and return an Ok (20x)
            }
            
            else
            {
                IEnumerable<Order> Orders = dal.GetOrdersByCountry(country);
                return Orders;
            }
        }
        [HttpPost]
        public Object Post(Order o)
        {
            int newId = dal.CreateOrder(o);
            if (newId < 0)
            {
                return new { success = false };
            }

            return new { status = true, id = newId };
        }
    }
}