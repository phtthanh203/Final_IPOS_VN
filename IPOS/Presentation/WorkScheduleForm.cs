using IPOS.Business;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IPOS
{
    public partial class WorkScheduleForm : Form
    {
        public int? ScheduleId { get; set; }
        public int UserId { get; set; }

        public WorkScheduleForm(int userId, int? scheduleId = null)
        {
            InitializeComponent();
            this.UserId = userId;
            this.ScheduleId = scheduleId;

            if (scheduleId.HasValue)
            {
                var Service = new WorkScheduleService();
                Service.LoadData(scheduleId.Value, dtpStart, dtpDate);
                this.Text = "Sửa lịch làm việc";
                dtpDate.Enabled = false; // ❌ Không cho sửa ngày
            }
            else
            {
                this.Text = "Thêm lịch làm việc";
                dtpDate.Value = DateTime.Today;
                dtpStart.Value = DateTime.Now;
            }
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            var Service = new WorkScheduleService();
            Service.update_WorkSchedule(UserId, ScheduleId, dtpStart, dtpDate);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
