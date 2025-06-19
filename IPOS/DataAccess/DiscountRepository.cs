using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using IPOS.Models;

namespace IPOS.DataAccess
{
    public class DiscountRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public List<DiscountCodeModel> GetAvailableDiscounts()
        {
            var list = new List<DiscountCodeModel>();
            string query = @"
                SELECT * FROM DiscountCodes
                WHERE IsActive = 1 AND IsUsed = 0 AND ExpiryDate >= GETDATE()
                ORDER BY ExpiryDate ASC
            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DiscountCodeModel
                        {
                            DiscountId = reader.GetInt32(reader.GetOrdinal("DiscountId")),
                            Code = reader["Code"].ToString(),
                            Description = reader["Description"]?.ToString(),
                            DiscountType = reader["DiscountType"].ToString(),
                            DiscountValue = reader.GetInt32(reader.GetOrdinal("DiscountValue")),
                            ExpiryDate = reader.GetDateTime(reader.GetOrdinal("ExpiryDate")),
                            MinOrderAmount = reader.IsDBNull(reader.GetOrdinal("MinOrderAmount")) ? 0 : reader.GetInt32(reader.GetOrdinal("MinOrderAmount")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                            IsUsed = reader.GetBoolean(reader.GetOrdinal("IsUsed"))
                        });
                    }
                }
            }

            return list;
        }

        public void MarkDiscountAsUsed(int discountId)
        {
            string query = "UPDATE DiscountCodes SET IsUsed = 1 WHERE DiscountId = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", discountId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
