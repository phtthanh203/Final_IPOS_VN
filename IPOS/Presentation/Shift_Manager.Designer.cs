using System.Drawing;
using System.Windows.Forms;

namespace IPOS
{
    partial class Shift_Manager
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label lblShiftCode;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblOpenTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnCloseShift;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TabPage tabTodayOrders;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.TabPage tabWorkSchedule;
        private System.Windows.Forms.FlowLayoutPanel flowOrders;
        private System.Windows.Forms.SplitContainer splitTodayOrders;
        private System.Windows.Forms.DataGridView dgvTodayOrders;
        private System.Windows.Forms.ListBox listTodayOrderItems;
        private System.Windows.Forms.ComboBox cmbFilterTodayOrders;
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.GroupBox groupProductList;
        private System.Windows.Forms.TableLayoutPanel productLayout;
        private System.Windows.Forms.DataGridView dgvWorkSchedule;
        private TabPage tabTimeSchedule;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {

            this.components = new System.ComponentModel.Container();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.lblShiftCode = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblOpenTime = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCloseShift = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.flowOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.tabTodayOrders = new System.Windows.Forms.TabPage();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.tabWorkSchedule = new System.Windows.Forms.TabPage();
            this.splitTodayOrders = new System.Windows.Forms.SplitContainer();
            this.dgvTodayOrders = new System.Windows.Forms.DataGridView();
            this.listTodayOrderItems = new System.Windows.Forms.ListBox();
            this.cmbFilterTodayOrders = new System.Windows.Forms.ComboBox();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.groupProductList = new System.Windows.Forms.GroupBox();
            this.productLayout = new System.Windows.Forms.TableLayoutPanel();
            this.dgvWorkSchedule = new System.Windows.Forms.DataGridView();
            var lblFilter = new System.Windows.Forms.Label();

            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(1280, 960);
            this.Text = "Quản lý ca";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.RowCount = 1;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Controls.Add(this.tableLayout);

            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.leftPanel.Padding = new System.Windows.Forms.Padding(30);
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblShiftCode.Text = "Mã ca:";
            this.lblEmployee.Text = "Nhân viên:";
            this.lblOpenTime.Text = "Giờ mở ca:";
            this.lblStatus.Text = "Trạng thái:";
            this.lblStatus.ForeColor = System.Drawing.Color.Teal;

            int labelTop = 10;
            int labelSpacing = 40;
            foreach (var label in new[] { lblShiftCode, lblEmployee, lblOpenTime, lblStatus })
            {
                label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(10, labelTop);
                labelTop += labelSpacing;
                this.leftPanel.Controls.Add(label);
            }

            this.btnCloseShift.Text = "Đóng ca";
            this.btnCloseShift.Size = new System.Drawing.Size(180, 50);
            this.btnCloseShift.Location = new System.Drawing.Point(10, labelTop + 10);
            this.btnCloseShift.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCloseShift.ForeColor = System.Drawing.Color.White;
            this.btnCloseShift.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCloseShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseShift.Click += new System.EventHandler(this.btnCloseShift_Click_1);
            this.leftPanel.Controls.Add(this.btnCloseShift);

            this.tableLayout.Controls.Add(this.leftPanel, 0, 0);

            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.tabControl.Controls.Add(this.tabOrders);
            this.tabControl.Controls.Add(this.tabTodayOrders);
            this.tabControl.Controls.Add(this.tabProducts);
            this.tabControl.Controls.Add(this.tabWorkSchedule);
            this.tableLayout.Controls.Add(this.tabControl, 1, 0);

            this.tabOrders.Text = "📋 Danh sách đơn hàng";
            this.tabOrders.BackColor = System.Drawing.Color.White;
            this.tabOrders.Controls.Add(this.flowOrders);

            this.flowOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowOrders.AutoScroll = true;
            this.flowOrders.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowOrders.Padding = new System.Windows.Forms.Padding(20);

            this.tabTodayOrders.Text = "📅 Quản lý đơn hàng trong ngày";
            this.tabTodayOrders.BackColor = System.Drawing.Color.White;
            this.tabTodayOrders.Padding = new System.Windows.Forms.Padding(10);

            lblFilter.Text = "Lọc đơn hàng:";
            lblFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblFilter.Location = new System.Drawing.Point(10, 10);
            lblFilter.Size = new System.Drawing.Size(150, 28);
            this.tabTodayOrders.Controls.Add(lblFilter);

            this.cmbFilterTodayOrders.Items.AddRange(new object[] { "Chỉ hôm nay", "Tất cả" });
            this.cmbFilterTodayOrders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterTodayOrders.SelectedIndex = 0;
            this.cmbFilterTodayOrders.Location = new System.Drawing.Point(160, 10);
            this.cmbFilterTodayOrders.Size = new System.Drawing.Size(180, 32);
            this.cmbFilterTodayOrders.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.tabTodayOrders.Controls.Add(this.cmbFilterTodayOrders);

            this.splitTodayOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTodayOrders.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitTodayOrders.SplitterDistance = 700;
            this.splitTodayOrders.Panel1.Controls.Add(this.dgvTodayOrders);
            this.splitTodayOrders.Panel2.Controls.Add(this.listTodayOrderItems);
            this.tabTodayOrders.Controls.Add(this.splitTodayOrders);

            this.dgvTodayOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTodayOrders.BackgroundColor = System.Drawing.Color.White;

            this.listTodayOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTodayOrderItems.Font = new System.Drawing.Font("Segoe UI", 12F);

            this.tabProducts.Text = "📦 Quản lý sản phẩm";
            this.tabProducts.BackColor = System.Drawing.Color.White;
            this.tabProducts.Padding = new System.Windows.Forms.Padding(10);

            this.groupProductList.Text = "📦 Danh sách sản phẩm";
            this.groupProductList.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.groupProductList.Dock = DockStyle.Fill;
            this.groupProductList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupProductList.ForeColor = System.Drawing.Color.Teal;
            this.groupProductList.Padding = new Padding(10);
            this.tabProducts.Controls.Add(this.groupProductList);

            this.productLayout.Dock = DockStyle.Fill;
            this.productLayout.ColumnCount = 1;
            this.productLayout.RowCount = 2;
            this.productLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.productLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            this.groupProductList.Controls.Add(this.productLayout);

            this.dgvProductList.Dock = DockStyle.Fill;
            this.dgvProductList.BackgroundColor = Color.White;
            this.dgvProductList.ReadOnly = true;
            this.dgvProductList.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dgvProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductList.AllowUserToAddRows = false;
            this.dgvProductList.AllowUserToDeleteRows = false;
            this.productLayout.Controls.Add(this.dgvProductList, 0, 0);

            this.btnAddProduct.Text = "➕ Thêm sản phẩm";
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnAddProduct.Size = new System.Drawing.Size(180, 45);
            this.btnAddProduct.Anchor = AnchorStyles.Right;
            this.btnAddProduct.BackColor = Color.SeaGreen;
            this.btnAddProduct.ForeColor = Color.White;
            this.btnAddProduct.FlatStyle = FlatStyle.Flat;
            this.btnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            var panelBtn = new Panel { Dock = DockStyle.Fill };
            panelBtn.Controls.Add(this.btnAddProduct);
            this.btnAddProduct.Location = new System.Drawing.Point(panelBtn.Width - 190, 10);
            this.btnAddProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.productLayout.Controls.Add(panelBtn, 0, 1);

            this.tabWorkSchedule.Text = "🕒 Quản lý thời gian làm việc";
            this.tabWorkSchedule.BackColor = Color.White;
            this.dgvWorkSchedule = new System.Windows.Forms.DataGridView();
            this.dgvWorkSchedule.Dock = DockStyle.Fill;
            this.dgvWorkSchedule.BackgroundColor = Color.White;
            this.dgvWorkSchedule.ReadOnly = true;
            this.dgvWorkSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWorkSchedule.Font = new Font("Segoe UI", 11F);
            this.tabWorkSchedule.Controls.Add(this.dgvWorkSchedule);

            this.ResumeLayout(false);
        }
    }
}
