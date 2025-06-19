using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IPOS.Models;
using IPOS.DataAccess;

namespace IPOS
{
    public partial class DiscountForm : Form
    {
        private List<DiscountCodeModel> discountList;
        public DiscountCodeModel SelectedDiscount { get; private set; }

        public DiscountForm()
        {
            InitializeComponent();
            LoadDiscounts();
        }

        private void LoadDiscounts()
        {
            var repo = new DiscountRepository();
            discountList = repo.GetAvailableDiscounts();

            listDiscounts.Items.Clear();
            foreach (var discount in discountList)
                listDiscounts.Items.Add(discount);  // ToString() sẽ tự hiển thị
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            if (listDiscounts.SelectedIndex >= 0)
            {
                SelectedDiscount = discountList[listDiscounts.SelectedIndex];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
