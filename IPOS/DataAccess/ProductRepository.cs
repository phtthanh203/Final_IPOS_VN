using IPOS.DB;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Diagnostics;

namespace IPOS.DataAccess
{
    public class ProductRepository
    {
        public List<ProductDetails> GetAll()
        {
            var list = new List<ProductDetails>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Products", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new ProductDetails
                    {
                        ProductId = reader["ProductId"] != DBNull.Value ? Convert.ToInt32(reader["ProductId"]) : 0,
                        ProductName = reader["ProductName"]?.ToString(),
                        Price = reader["Price"] != DBNull.Value ? Convert.ToInt32(reader["Price"]) : 0,
                        ImagePath = reader["ImagePath"]?.ToString(),
                        CategoryId = reader["CategoryId"] != DBNull.Value ? Convert.ToInt32(reader["CategoryId"]) : 0
                    });
                }
            }
            return list;
        }

        public void AddProduct(string ProductName, int Price, string ImagePath, int CategoryId)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO Products (ProductName, Price, ImagePath, CategoryId) VALUES (@name, @price, @image, @cat)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", ProductName);
                cmd.Parameters.AddWithValue("@price", Price);
                cmd.Parameters.AddWithValue("@image", ImagePath);
                cmd.Parameters.AddWithValue("@cat", CategoryId);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
