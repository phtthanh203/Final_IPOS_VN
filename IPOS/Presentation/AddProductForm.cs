using IPOS.Business;
using IPOS.DataAccess;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IPOS
{
    public partial class AddProductForm : Form
    {
        public string ProductName => txtName.Text;
        public int Price => int.TryParse(txtPrice.Text, out var p) ? p : 0;
        public string ImagePath => txtImage.Text;
        public int CategoryId => (int)cmbCategory.SelectedValue;



        public AddProductForm()
        {
            InitializeComponent();
            LoadCategories();
        }



        private void LoadCategories()
        {
            var service = new CategoryService();
            var categories = service.GetAllCategories();

            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           ProductRepository pr = new ProductRepository();
            pr.AddProduct(ProductName, Price, ImagePath, CategoryId);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
