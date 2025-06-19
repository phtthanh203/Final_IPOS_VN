using IPOS.Business;
using IPOS.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IPOS
{
    public partial class Form_Table : Form
    {
        private readonly TableService _tableService = new TableService();
        private readonly WorkScheduleService _workScheduleService = new WorkScheduleService();

        public Form_Table()
        {
            InitializeComponent();
        }

        private void Form_Table_Load(object sender, EventArgs e)
        {
            LoadBanButtons();
        }

        private void LoadBanButtons()
        {
            List<Table_Details> danhSachBan = _tableService.GetAllTables();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            ToolTip tooltip = new ToolTip();

            foreach (var ban in danhSachBan)
            {
                bool isOccupied = _tableService.IsTableOccupied(ban.ID);

                Button btn = new Button
                {
                    Size = button1.Size,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Margin = button1.Margin,
                    ForeColor = isOccupied ? Color.Red : Color.Green,
                    TextAlign = ContentAlignment.BottomCenter,
                    FlatStyle = button1.FlatStyle,
                    Text = ban.nameTable,
                    Tag = ban,
                    Name = $"btnBan{ban.ID}",
                    ImageAlign = ContentAlignment.TopCenter,
                    Image = isOccupied ? Properties.Resources.Table_Occupied : Properties.Resources.Table_Free
                };

                tooltip.SetToolTip(btn, $"Bàn: {ban.nameTable}\nTrạng thái: {(isOccupied ? "Đang phục vụ" : "Trống")}");
                btn.Click += Btn_Click;

                if (ban.IsTakeAway)
                    flowLayoutPanel2.Controls.Add(btn);
                else
                    flowLayoutPanel1.Controls.Add(btn);
            }

            button1.Visible = false;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Table_Details ban)
            {
                if (_tableService.IsTableOccupied(ban.ID))
                {
                    MessageBox.Show("Bàn này đang có khách hoặc đang xử lý đơn hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Order ord = new Order(ban.ID); // truyền ID bàn
                ord.Show();
                this.Hide();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int userId = Session.CurrentUserId;

            if (!_workScheduleService.CanAccessShiftManager(userId))
            {
                MessageBox.Show("Bạn không có ca làm việc hôm nay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Shift_Manager shiftManagerForm = new Shift_Manager(userId);
            shiftManagerForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
