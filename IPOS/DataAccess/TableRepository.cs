using IPOS.DB;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace IPOS.DataAccess
{
    public class TableRepository
    {
        public List<Table_Details> GetAllTables()
        {
            var tables = new List<Table_Details>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Table_Details", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tables.Add(new Table_Details
                    {
                        ID = (int)reader["ID"],
                        nameTable = reader["nameTable"].ToString(),
                        IsTakeAway = (bool)reader["IsTakeAway"]
                    });
                }
            }
            return tables;
        }

        public bool IsTableOccupied(int tableId)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT COUNT(*) 
                    FROM Orders 
                    WHERE TableId = @TableId AND Status IN ('New', 'Preparing')", conn);

                cmd.Parameters.AddWithValue("@TableId", tableId);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
