using Dapper;
using Lab_13_3.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_13_3.Services
{
    public class DALSqlServer : IDAL
    {
        private string connectionString;
        public DALSqlServer(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        public IEnumerable<Order> GetOrdersByCountry(string country)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Orders WHERE ShipCountry = @cat";
            IEnumerable<Order> Orders = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Orders = connection.Query<Order>(queryString, new { cat = country });
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Orders;
        }

        public IEnumerable<OrderDetail> GetOrderDetailsAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM [Order Details]";
            IEnumerable<OrderDetail> OrderDetails = null;

            try
            {
                connection = new SqlConnection(connectionString);
                OrderDetails = connection.Query<OrderDetail>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return OrderDetails;
        }

        public IEnumerable<Order> GetOrdersAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Orders";
            IEnumerable<Order> Orders = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Orders = connection.Query<Order>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Orders;
        }

        public IEnumerable<Product> GetProductsAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Products";
            IEnumerable<Product> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Product>(queryString);
            }
            catch (Exception e)
            {
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return Movies;
        }
    }
}
