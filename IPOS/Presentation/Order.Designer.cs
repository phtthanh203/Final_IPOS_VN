// Order.Designer.cs – sửa lỗi sản phẩm bị tràn sang panelRight (giải pháp tốt nhất: padding phải + layout chuẩn)
namespace IPOS
{
    partial class Order
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.flowLayoutPanelProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.cartPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelProduct = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAddToCart = new System.Windows.Forms.Button();
            this.buttonDiscount = new System.Windows.Forms.Button();
            this.buttonCheckout = new System.Windows.Forms.Button();
            this.buttonLeave = new System.Windows.Forms.Button();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.flowLayoutPanelProducts);
            this.panelLeft.Controls.Add(this.flowLayoutPanelCategories);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.Size = new System.Drawing.Size(1600, 900);
            this.panelLeft.TabIndex = 1;
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.AutoScroll = true;
            this.flowLayoutPanelProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(10, 70);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Padding = new System.Windows.Forms.Padding(10, 10, 510, 10);
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(1580, 820);
            this.flowLayoutPanelProducts.TabIndex = 0;
            this.flowLayoutPanelProducts.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelProducts_Paint);
            // 
            // flowLayoutPanelCategories
            // 
            this.flowLayoutPanelCategories.AutoScroll = true;
            this.flowLayoutPanelCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanelCategories.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanelCategories.Name = "flowLayoutPanelCategories";
            this.flowLayoutPanelCategories.Size = new System.Drawing.Size(1580, 60);
            this.flowLayoutPanelCategories.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.txtSearch);
            this.panelRight.Controls.Add(this.labelTime);
            this.panelRight.Controls.Add(this.cartPanel);
            this.panelRight.Controls.Add(this.labelProduct);
            this.panelRight.Controls.Add(this.pictureBox1);
            this.panelRight.Controls.Add(this.buttonAddToCart);
            this.panelRight.Controls.Add(this.buttonDiscount);
            this.panelRight.Controls.Add(this.buttonCheckout);
            this.panelRight.Controls.Add(this.buttonLeave);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1100, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(20);
            this.panelRight.Size = new System.Drawing.Size(500, 900);
            this.panelRight.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(10, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 32);
            this.txtSearch.TabIndex = 0;
            // 
            // labelTime
            // 
            this.labelTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelTime.Location = new System.Drawing.Point(320, 10);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(160, 30);
            this.labelTime.TabIndex = 1;
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cartPanel
            // 
            this.cartPanel.AutoScroll = true;
            this.cartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cartPanel.Location = new System.Drawing.Point(10, 50);
            this.cartPanel.Name = "cartPanel";
            this.cartPanel.Padding = new System.Windows.Forms.Padding(5);
            this.cartPanel.Size = new System.Drawing.Size(460, 200);
            this.cartPanel.TabIndex = 2;
            // 
            // labelProduct
            // 
            this.labelProduct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelProduct.Location = new System.Drawing.Point(10, 260);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(460, 40);
            this.labelProduct.TabIndex = 3;
            this.labelProduct.Text = "Chi tiết sản phẩm";
            this.labelProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(10, 310);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // buttonAddToCart
            // 
            this.buttonAddToCart.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonAddToCart.FlatAppearance.BorderSize = 0;
            this.buttonAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddToCart.Location = new System.Drawing.Point(200, 310);
            this.buttonAddToCart.Name = "buttonAddToCart";
            this.buttonAddToCart.Size = new System.Drawing.Size(150, 40);
            this.buttonAddToCart.TabIndex = 5;
            this.buttonAddToCart.Text = "➕ Thêm vào giỏ";
            this.buttonAddToCart.UseVisualStyleBackColor = false;
            // 
            // buttonDiscount
            // 
            this.buttonDiscount.BackColor = System.Drawing.Color.LightYellow;
            this.buttonDiscount.FlatAppearance.BorderSize = 0;
            this.buttonDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscount.Location = new System.Drawing.Point(200, 360);
            this.buttonDiscount.Name = "buttonDiscount";
            this.buttonDiscount.Size = new System.Drawing.Size(150, 40);
            this.buttonDiscount.TabIndex = 6;
            this.buttonDiscount.Text = "🏷 Mã giảm";
            this.buttonDiscount.UseVisualStyleBackColor = false;
            // 
            // buttonCheckout
            // 
            this.buttonCheckout.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonCheckout.FlatAppearance.BorderSize = 0;
            this.buttonCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckout.ForeColor = System.Drawing.Color.White;
            this.buttonCheckout.Location = new System.Drawing.Point(10, 520);
            this.buttonCheckout.Name = "buttonCheckout";
            this.buttonCheckout.Size = new System.Drawing.Size(460, 50);
            this.buttonCheckout.TabIndex = 7;
            this.buttonCheckout.Text = "💰 Thanh toán (0 đ)";
            this.buttonCheckout.UseVisualStyleBackColor = false;
            // 
            // buttonLeave
            // 
            this.buttonLeave.BackColor = System.Drawing.Color.LightGray;
            this.buttonLeave.FlatAppearance.BorderSize = 0;
            this.buttonLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeave.Location = new System.Drawing.Point(10, 580);
            this.buttonLeave.Name = "buttonLeave";
            this.buttonLeave.Size = new System.Drawing.Size(460, 40);
            this.buttonLeave.TabIndex = 8;
            this.buttonLeave.Text = "⏎ Rời khỏi";
            this.buttonLeave.UseVisualStyleBackColor = false;
            // 
            // Order
            // 
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Order";
            this.Text = "Gọi món";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCategories;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.FlowLayoutPanel cartPanel;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddToCart;
        private System.Windows.Forms.Button buttonDiscount;
        private System.Windows.Forms.Button buttonCheckout;
        private System.Windows.Forms.Button buttonLeave;
    }
}