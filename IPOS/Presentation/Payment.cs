using IPOS.DB;
using IPOS.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace IPOS
{
    public partial class Payment : Form
    {
        private bool isInputForGot = true;
        private readonly string maDonHang;
        private readonly int tongTien;
        private readonly List<ProductDetails> cart;
        private readonly int? selectedTableId;

        public Payment(string maDon, int total, List<ProductDetails> cartItems, int? tableId)
        {
            InitializeComponent();
            CreateNumberButtons();

            maDonHang = maDon;
            tongTien = total;
            cart = cartItems;
            selectedTableId = tableId;

            txtTotal.Text = total.ToString("#,##0");
        }

        private void CreateNumberButtons()
        {
            flowLayoutPanelPad.Controls.Clear();
            flowLayoutPanelPad.WrapContents = true;
            flowLayoutPanelPad.AutoScroll = true;
            flowLayoutPanelPad.FlowDirection = FlowDirection.LeftToRight;

            string[] buttons = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "000", "0", "Del" };

            foreach (string text in buttons)
            {
                var btn = new Button
                {
                    Text = text,
                    Width = 160,
                    Height = 70,
                    Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Margin = new Padding(10)
                };

                btn.Click += NumberButton_Click;
                flowLayoutPanelPad.Controls.Add(btn);
            }
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string input = btn.Text;
            var targetBox = isInputForGot ? txtGot : txtTotal;

            string current = targetBox.Text.Replace(",", "").Replace(".", "");

            if (input == "Del")
            {
                if (current.Length > 0)
                    current = current.Substring(0, current.Length - 1);
            }
            else
            {
                current += input;
            }

            if (string.IsNullOrEmpty(current))
            {
                targetBox.Text = "";
            }
            else if (long.TryParse(current, out long number))
            {
                targetBox.Text = number.ToString("#,##0");
                targetBox.SelectionStart = targetBox.Text.Length;
            }
        }

        private void BtnInputGot_Click(object sender, EventArgs e)
        {
            isInputForGot = true;
            txtGot.BackColor = Color.LightYellow;
            txtTotal.BackColor = Color.White;
        }

        private void BtnInputTotal_Click(object sender, EventArgs e)
        {
            isInputForGot = false;
            txtGot.BackColor = Color.White;
            txtTotal.BackColor = Color.LightYellow;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtGot.Text = "";
            txtGot.BackColor = Color.White;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            long got = 0;
            long total = 0;
            long.TryParse(txtGot.Text.Replace(",", "").Replace(".", ""), out got);
            long.TryParse(txtTotal.Text.Replace(",", "").Replace(".", ""), out total);

            if (total == 0)
            {
                MessageBox.Show("Vui lòng nhập tổng tiền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long change = got - total;

            if (change < 0)
            {
                MessageBox.Show($"Khách còn thiếu {-change:#,##0} VND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var paymentService = new PaymentService();
            paymentService.ProcessPayment(maDonHang, tongTien, cart, selectedTableId);

            MessageBox.Show($"Thanh toán thành công!\nTiền thừa: {change:#,##0} VND", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            new Form_Table().Show();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {

        }
    }
}
