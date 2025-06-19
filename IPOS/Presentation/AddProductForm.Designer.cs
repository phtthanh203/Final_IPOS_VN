namespace IPOS
{
    partial class AddProductForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblName
            this.lblName.Text = "Tên sản phẩm:";
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Size = new System.Drawing.Size(120, 25);

            // txtName
            this.txtName.Location = new System.Drawing.Point(160, 30);
            this.txtName.Size = new System.Drawing.Size(250, 25);

            // lblPrice
            this.lblPrice.Text = "Giá:";
            this.lblPrice.Location = new System.Drawing.Point(30, 70);
            this.lblPrice.Size = new System.Drawing.Size(120, 25);

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(160, 70);
            this.txtPrice.Size = new System.Drawing.Size(250, 25);

            // lblImage
            this.lblImage.Text = "Link ảnh:";
            this.lblImage.Location = new System.Drawing.Point(30, 110);
            this.lblImage.Size = new System.Drawing.Size(120, 25);

            // txtImage
            this.txtImage.Location = new System.Drawing.Point(160, 110);
            this.txtImage.Size = new System.Drawing.Size(250, 25);

            // lblCategory
            this.lblCategory.Text = "Danh mục:";
            this.lblCategory.Location = new System.Drawing.Point(30, 150);
            this.lblCategory.Size = new System.Drawing.Size(120, 25);

            // cmbCategory
            this.cmbCategory.Location = new System.Drawing.Point(160, 150);
            this.cmbCategory.Size = new System.Drawing.Size(250, 25);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // btnSave
            this.btnSave.Text = "Lưu";
            this.btnSave.Location = new System.Drawing.Point(160, 200);
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.Location = new System.Drawing.Point(310, 200);
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddProductForm
            this.ClientSize = new System.Drawing.Size(480, 270);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "AddProductForm";
            this.Text = "Thêm Sản Phẩm Mới";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
