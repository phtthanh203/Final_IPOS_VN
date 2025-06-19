using IPOS.Models;
using IPOS_VN.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace IPOS.DataAccess
{
    public class OrderRepository
    {
        private readonly string connectionString;

        public OrderRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public int CreateOrder(OrderModel order)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(@"
                    INSERT INTO Orders (OrderCode, TotalAmount, Status, OrderTime, IsTakeAway, TableId)
                    OUTPUT INSERTED.OrderId
                    VALUES (@code, @total, 'New', GETDATE(), @isTakeAway, @tableId)", conn);

                cmd.Parameters.AddWithValue("@code", order.OrderCode);
                cmd.Parameters.AddWithValue("@total", order.TotalAmount);
                cmd.Parameters.AddWithValue("@isTakeAway", order.IsTakeAway);
                cmd.Parameters.AddWithValue("@tableId", order.TableId.HasValue ? (object)order.TableId.Value : DBNull.Value);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void AddOrderDetail(int orderId, int productId, int unitPrice)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(@"
                    INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice)
                    VALUES (@orderId, @productId, 1, @unitPrice)", conn);

                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.Parameters.AddWithValue("@unitPrice", unitPrice);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
