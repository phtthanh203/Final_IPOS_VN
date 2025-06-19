// Order.cs - Presentation Layer (giữ nguyên logic, chuẩn bị cho UI mới theo layout Dock)
using IPOS.Business;
using IPOS.DataAccess;
using IPOS.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IPOS
{
    public partial class Order : Form
    {
        private readonly OrderService _orderService = new OrderService();
        private readonly CategoryService _categoryService = new CategoryService();

        private List<ProductDetails> cart = new List<ProductDetails>();
        private ProductDetails selectedProduct = null;
        private int? selectedTableId;
        private string appliedDiscountCode = null;
        private int appliedDiscountValue = 0;
        private bool isPercentDiscount = false;

        public Order(int tableId)
        {
            InitializeComponent();
            selectedTableId = tableId;
            this.Load += Order_Load;
            buttonAddToCart.Click += buttonAddToCart_Click;
            buttonCheckout.Click += buttonThanhToan_Click;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            SetupSearchBoxEvents();
            LoadCategoryButtonsSafe();
            LoadAllProducts();

            buttonCheckout.Text = "💰 Thanh toán (0 đ)";

            buttonDiscount.Click += (s, evt) =>
            {
                var discountForm = new DiscountForm();
                if (discountForm.ShowDialog() == DialogResult.OK && discountForm.SelectedDiscount != null)
                {
                    var discount = discountForm.SelectedDiscount;
                    isPercentDiscount = discount.DiscountType == "percent";
                    appliedDiscountValue = discount.DiscountValue;
                    appliedDiscountCode = discount.Code;

                    var repo = new DiscountRepository();
                    repo.MarkDiscountAsUsed(discount.DiscountId);

                    UpdateCartUI();
                    MessageBox.Show($"Đã áp dụng mã: {discount.Code}", "Thông báo");
                }
            };

            buttonLeave.Click += ButtonLeave_Click;
        }

        private void ButtonLeave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn rời đi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new Form_Table().Show();
            }
        }

        private void SetupSearchBoxEvents()
        {
            txtSearch.TextChanged += (s, ev) =>
            {
                if (txtSearch.Text == "Tìm kiếm sản phẩm...") return;
                UpdateProductList(_orderService.FilterProductsByKeyword(txtSearch.Text));
            };
        }

        private void LoadCategoryButtonsSafe()
        {
            var categories = _categoryService.GetAllCategories();

            var toRemove = flowLayoutPanelCategories.Controls
                .OfType<Control>()
                .Where(c => c is Button)
                .ToList();

            foreach (var ctrl in toRemove)
                flowLayoutPanelCategories.Controls.Remove(ctrl);

            foreach (var cat in categories)
                flowLayoutPanelCategories.Controls.Add(CreateCategoryButton(cat));
        }

        private Button CreateCategoryButton(Category category)
        {
            var btn = new Button
            {
                Size = new Size(100, 40),
                Font = new Font("Segoe UI", 10F),
                Margin = new Padding(5),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Text = category.CategoryName,
                Tag = category,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.WhiteSmoke
            };
            btn.FlatAppearance.BorderSize = 1;
            btn.Click += Btn_ClickDanhMuc;
            return btn;
        }

        private void LoadAllProducts()
        {
            UpdateProductList(_orderService.GetAllProducts());
        }

        private void UpdateProductList(List<ProductDetails> products)
        {
            flowLayoutPanelProducts.Controls.Clear();
            foreach (var product in products)
                flowLayoutPanelProducts.Controls.Add(CreateProductButton(product));
        }

        private Button CreateProductButton(ProductDetails product)
        {
            var btn = new Button
            {
                Size = new Size(200, 230),
                Margin = new Padding(10, 10, 20, 10),
                Font = new Font("Segoe UI", 15F),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = $"{product.ProductName}\n{product.Price:N0} đ",
                Tag = product
            };

            if (System.IO.File.Exists(product.ImagePath))
            {
                using (var original = Image.FromFile(product.ImagePath))
                {
                    btn.Image = new Bitmap(original, new Size(150, 150));
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.TextImageRelation = TextImageRelation.ImageAboveText;
                }
            }

            btn.Click += Btn_ClickSanPham;
            return btn;
        }

        private void Btn_ClickDanhMuc(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Category category)
            {
                UpdateProductList(_orderService.FilterProductsByCategory(category.CategoryId));
            }
        }

        private void Btn_ClickSanPham(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is ProductDetails product)
            {
                selectedProduct = product;
                labelProduct.Text = $"Sản phẩm: {product.ProductName}\nGiá: {product.Price:N0} đ";

                if (System.IO.File.Exists(product.ImagePath))
                {
                    pictureBox1.Image = Image.FromFile(product.ImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }

        private void buttonAddToCart_Click(object sender, EventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Hãy chọn một món trước khi thêm vào giỏ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cart.Add(selectedProduct);
            UpdateCartUI();
        }

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong giỏ hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDon = "ORD" + DateTime.Now.Ticks;
            this.Hide();

            int tongTienGoc = _orderService.CalculateTotalPrice(cart);
            int giam = _orderService.ApplyDiscount(tongTienGoc, appliedDiscountValue, isPercentDiscount);
            int tongSauGiam = Math.Max(tongTienGoc - giam, 0);

            var paymentForm = new Payment(maDon, tongSauGiam, cart, selectedTableId);
            paymentForm.FormClosed += (s, ev) => this.Show();
            paymentForm.Show();
        }

        private void UpdateCartUI()
        {
            cartPanel.Controls.Clear();

            for (int i = 0; i < cart.Count; i++)
            {
                var item = cart[i];

                var itemPanel = new Panel
                {
                    Width = 260,
                    Height = 40,
                    Margin = new Padding(5),
                    BackColor = Color.FromArgb(245, 245, 245)
                };

                var label = new Label
                {
                    Text = $"- {item.ProductName} ({item.Price:N0} đ)",
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 11F),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(5, 0, 0, 0)
                };

                var removeBtn = new Button
                {
                    Text = "❌",
                    Width = 30,
                    Dock = DockStyle.Right,
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = i,
                    Cursor = Cursors.Hand
                };
                removeBtn.FlatAppearance.BorderSize = 0;
                removeBtn.Click += (s, e) =>
                {
                    cart.RemoveAt((int)((Button)s).Tag);
                    UpdateCartUI();
                };

                itemPanel.Controls.Add(label);
                itemPanel.Controls.Add(removeBtn);
                cartPanel.Controls.Add(itemPanel);
            }

            int tongTienGoc = _orderService.CalculateTotalPrice(cart);
            int giam = _orderService.ApplyDiscount(tongTienGoc, appliedDiscountValue, isPercentDiscount);
            int tongSauGiam = Math.Max(tongTienGoc - giam, 0);

            buttonCheckout.Text = $"💰 Thanh toán ({tongSauGiam:N0} đ)";
        }

        private void flowLayoutPanelProducts_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}