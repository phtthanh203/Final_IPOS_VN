using IPOS.DataAccess;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IPOS.Business
{
    public class WorkScheduleService
    {
        private readonly WorkScheduleRepository _repo = new WorkScheduleRepository();

        public bool CanAccessShiftManager(int userId)
        {
            return _repo.HasWorkToday(userId, DateTime.Today);
        }

        public void update_WorkSchedule(int UserId, int? ScheduleId,DateTimePicker dtpStart, DateTimePicker dtpDate)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd;

                if (ScheduleId.HasValue)
                {
                    // Update
                    cmd = new SqlCommand("UPDATE WorkSchedule SET StartTime = @Time WHERE ScheduleId = @ScheduleId", conn);
                    cmd.Parameters.AddWithValue("@Time", dtpStart.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@ScheduleId", ScheduleId.Value);
                }
                else
                {
                    // Insert
                    cmd = new SqlCommand("INSERT INTO WorkSchedule (UserId, WorkDate, StartTime) VALUES (@UserId, @Date, @Time)", conn);
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Time", dtpStart.Value.TimeOfDay);
                }

                cmd.ExecuteNonQuery();
            }
        }

        public void LoadData(int scheduleId, DateTimePicker dtpStart, DateTimePicker dtpDate)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT WorkDate, StartTime FROM WorkSchedule WHERE ScheduleId = @ScheduleId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ScheduleId", scheduleId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dtpDate.Value = Convert.ToDateTime(reader["WorkDate"]);
                    dtpStart.Value = DateTime.Today.Add((TimeSpan)reader["StartTime"]);
                }
            }
        }

    }
}
