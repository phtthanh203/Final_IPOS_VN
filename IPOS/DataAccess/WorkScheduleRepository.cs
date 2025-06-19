using System;
using System.Configuration;
using System.Data.SqlClient;

namespace IPOS.DataAccess
{
    public class WorkScheduleRepository
    {
        public bool HasWorkToday(int userId, DateTime today)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM WorkSchedule WHERE UserId = @uid AND WorkDate = @today", conn);
                cmd.Parameters.AddWithValue("@uid", userId);
                cmd.Parameters.AddWithValue("@today", today);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
