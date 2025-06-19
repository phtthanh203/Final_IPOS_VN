using System.Drawing;
using System.Windows.Forms;

namespace IPOS
{
    partial class WorkScheduleForm
    {
        private System.ComponentModel.IContainer components = null;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpStart;
        private Button btnSave;
        private Label lblDate;
        private Label lblStart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpDate = new DateTimePicker();
            this.dtpStart = new DateTimePicker();
            this.btnSave = new Button();
            this.lblDate = new Label();
            this.lblStart = new Label();

            this.SuspendLayout();

            // Label Ngày làm
            lblDate.Text = "📅 Ngày làm:";
            lblDate.Location = new Point(30, 10);
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);

            // DateTimePicker Ngày làm
            dtpDate.Location = new Point(30, 30);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Width = 180;
            dtpDate.Font = new Font("Segoe UI", 10F);

            // Label Giờ bắt đầu
            lblStart.Text = "🕒 Giờ bắt đầu:";
            lblStart.Location = new Point(30, 60);
            lblStart.AutoSize = true;
            lblStart.Font = new Font("Segoe UI", 10F);

            // DateTimePicker Giờ bắt đầu
            dtpStart.Location = new Point(30, 80);
            dtpStart.Format = DateTimePickerFormat.Time;
            dtpStart.ShowUpDown = true;
            dtpStart.Width = 180;
            dtpStart.Font = new Font("Segoe UI", 10F);

            // Nút Lưu
            btnSave.Text = "💾 Lưu";
            btnSave.Location = new Point(30, 130);
            btnSave.Size = new Size(120, 40);
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.BackColor = Color.MediumSeaGreen;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Form
            this.ClientSize = new Size(260, 200);
            this.Controls.Add(lblDate);
            this.Controls.Add(dtpDate);
            this.Controls.Add(lblStart);
            this.Controls.Add(dtpStart);
            this.Controls.Add(btnSave);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Lịch làm việc";

            this.ResumeLayout(false);
        }
    }
}
