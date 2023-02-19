using Microsoft.Data.SqlClient;
using ShoppingAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppWPF.Repositories
{
    public class ProductRepository
    {
        private readonly string connectionString;

        public ProductRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["StoreDatabase"].ConnectionString;
        }

        private Product ReadNextProduct(SqlDataReader reader)
        {
            int id = reader.GetInt32(0); //the param is index of the column
            string category = reader.GetString(1);
            string name = reader.GetString(2);
            string description = reader.GetString(3);
            double price = reader.GetDouble(4);
            int inventory = reader.GetInt32(5);
            string imageUrl = reader.GetString(6);

            return new Product(id,category,name,description,price,inventory,imageUrl);
        }

        public List<Product> GetProducts()
        {

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();

            command.CommandText =
                "SELECT Id,Category,Name,Description,Price,Inventory,ImageUrl " +
                "FROM dbo.Products";

            using SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();
            while (reader.Read())
            {

                products.Add(ReadNextProduct(reader));
            }
            return products;
        }

        public bool UpdateProductInventory(int id, int quantity)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = connection.CreateCommand();

            command.CommandText = "UPDATE dbo.Products" +
                " SET Inventory=@Inventory" +
                " WHERE Id=@Id";

            command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@Inventory", SqlDbType.Int).Value = quantity;
            command.Parameters.Add("@DateUpdated", SqlDbType.NVarChar).Value = DateTime.UtcNow;

            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
