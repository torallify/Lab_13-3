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

        public OrderDetail GetOrderDetailById(int id)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM [Order Details] WHERE OrderID = @id";
            OrderDetail orderDetail = null;

            try
            {
                connection = new SqlConnection(connectionString);
                orderDetail = connection.QueryFirstOrDefault<OrderDetail>(queryString, new { id = id });
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

            return orderDetail;
        }

        public Product GetProductById(int id)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Products WHERE ProductID = @id";
            Product product = null;

            try
            {
                connection = new SqlConnection(connectionString);
                product = connection.QueryFirstOrDefault<Product>(queryString, new { id = id });
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

            return product;
        }

        public int CreateProduct(Product p)
        {
            SqlConnection connection = null;
            string queryString = "INSERT INTO Products (ProductName, Category, QuantityPerUnit, UnitPrice, UnitsInStock, Discontinued)";
            queryString += " VALUES (@ProductName, @Category, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @Discontinued);";
            queryString += " SELECT SCOPE_IDENTITY();";
            int newId;

            try
            {
                connection = new SqlConnection(connectionString);
                newId = connection.ExecuteScalar<int>(queryString, p);
            }
            catch (Exception e)
            {
                newId = -1;
                //log the error--get details from e
            }
            finally //cleanup!
            {
                if (connection != null)
                {
                    connection.Close(); //explicitly closing the connection
                }
            }

            return newId;
        }
        public int DeleteProductById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string deleteCommand = "DELETE FROM Products WHERE ProductID = @id";
            int rows = connection.Execute(deleteCommand, new { id = id });
            return rows;
        }
    }
}
