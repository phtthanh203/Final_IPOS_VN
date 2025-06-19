using System.Drawing;
using System.Windows.Forms;

namespace IPOS
{
    partial class Payment
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.flowLayoutPanelMethod = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.lblGot = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtGot = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.flowLayoutPanelPad = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.flowLayoutPanelMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMethod
            // 
            this.flowLayoutPanelMethod.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelMethod.Controls.Add(this.btnCash);
            this.flowLayoutPanelMethod.Controls.Add(this.btnTransfer);
            this.flowLayoutPanelMethod.Location = new System.Drawing.Point(12, 189);
            this.flowLayoutPanelMethod.Name = "flowLayoutPanelMethod";
            this.flowLayoutPanelMethod.Size = new System.Drawing.Size(223, 132);
            this.flowLayoutPanelMethod.TabIndex = 0;
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.LightGreen;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnCash.Location = new System.Drawing.Point(3, 3);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(220, 60);
            this.btnCash.TabIndex = 0;
            this.btnCash.Text = "💵 Tiền mặt";
            this.btnCash.UseVisualStyleBackColor = false;
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.Location = new System.Drawing.Point(3, 69);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(220, 60);
            this.btnTransfer.TabIndex = 1;
            this.btnTransfer.Text = "🏦 Chuyển khoản";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // lblGot
            // 
            this.lblGot.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblGot.Location = new System.Drawing.Point(300, 40);
            this.lblGot.Name = "lblGot";
            this.lblGot.Size = new System.Drawing.Size(200, 40);
            this.lblGot.TabIndex = 1;
            this.lblGot.Text = "💰 Khách đưa:";
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(630, 40);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(200, 40);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "🧾 Tổng tiền:";
            // 
            // txtGot
            // 
            this.txtGot.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.txtGot.Location = new System.Drawing.Point(345, 80);
            this.txtGot.Name = "txtGot";
            this.txtGot.Size = new System.Drawing.Size(177, 52);
            this.txtGot.TabIndex = 2;
            this.txtGot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.LightGray;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.txtTotal.Location = new System.Drawing.Point(636, 80);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(219, 52);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightCoral;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnClear.Location = new System.Drawing.Point(528, 78);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 45);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "🧹 Xóa";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // flowLayoutPanelPad
            // 
            this.flowLayoutPanelPad.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelPad.Location = new System.Drawing.Point(385, 189);
            this.flowLayoutPanelPad.Name = "flowLayoutPanelPad";
            this.flowLayoutPanelPad.Size = new System.Drawing.Size(563, 363);
            this.flowLayoutPanelPad.TabIndex = 8;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.IndianRed;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(12, 83);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(223, 43);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "⏪ Trở lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(861, 83);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(165, 43);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "✅ Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // Payment
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1080, 640);
            this.Controls.Add(this.flowLayoutPanelMethod);
            this.Controls.Add(this.lblGot);
            this.Controls.Add(this.txtGot);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.flowLayoutPanelPad);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnConfirm);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "💳 Thanh toán";
            this.flowLayoutPanelMethod.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelMethod;
        private Button btnCash;
        private Button btnTransfer;
        private Label lblGot;
        private Label lblTotal;
        private TextBox txtGot;
        private TextBox txtTotal;
        private Button btnClear;
        private FlowLayoutPanel flowLayoutPanelPad;
        private Button btnBack;
        private Button btnConfirm;
    }
}
