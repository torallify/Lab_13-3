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
    public class OrderDetailController : ControllerBase
    {
        private IDAL dal;

        public OrderDetailController(IDAL dalObject)
        {
            dal = dalObject;
        }
        [HttpGet]
        public IEnumerable<OrderDetail> Get()
        {
            IEnumerable<OrderDetail> OrderDetails = dal.GetOrderDetailsAll();
            return OrderDetails; //serialize the parameter into JSON and return an Ok (20x
            
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
    }
}