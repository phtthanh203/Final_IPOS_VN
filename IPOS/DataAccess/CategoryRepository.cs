using IPOS.DB;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace IPOS.DataAccess
{
    public class CategoryRepository
    {
        public List<Category> GetAll()
        {
            var list = new List<Category>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Category", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Category
                    {
                        CategoryId = (int)reader["CategoryId"],
                        CategoryName = reader["CategoryName"].ToString()
                    });
                }
            }
            return list;
        }
    }
}
