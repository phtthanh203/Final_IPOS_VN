using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace IPOS
{
    public partial class Shift_Manager : Form
    {
        private int currentUserId;
        private int shiftId;
        private System.Windows.Forms.FlowLayoutPanel flowProductList;

        public Shift_Manager(int userId)
        {
            InitializeComponent();
            LoadWorkSchedule();
            dgvWorkSchedule.CellClick += dgvWorkSchedule_CellClick;
            currentUserId = userId;

            var userInfo = GetUserInfo(currentUserId);
            if (userInfo == null)
            {
                MessageBox.Show("Không tìm thấy người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            string fullName = userInfo.Item1;
            string email = userInfo.Item2;

            if (!CheckWorkSchedule(currentUserId, out DateTime startTime))
            {
                MessageBox.Show("Không có lịch làm việc hôm nay cho nhân viên này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            string shiftCode = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            LoadShiftInfo(shiftCode, fullName, DateTime.Now);
            SaveShiftToDatabase(shiftCode, DateTime.Now);
            LoadOrdersFromDatabase();
            LoadTodayOrders(true);
            LoadProductsFromDatabase();
        }

        private Tuple<string, string> GetUserInfo(int userId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT FullName, Email FROM Users WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Tuple.Create(reader["FullName"].ToString(), reader["Email"].ToString());
                }
                return null;
            }
            finally { conn.Dispose(); }
        }


        private bool CheckWorkSchedule(int userId, out DateTime scheduledStart)
        {
            scheduledStart = DateTime.MinValue;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT StartTime FROM WorkSchedule WHERE UserId = @UserId AND WorkDate = CAST(GETDATE() AS DATE)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                object result = cmd.ExecuteScalar();
                if (result != null && TimeSpan.TryParse(result.ToString(), out TimeSpan startTime))
                {
                    scheduledStart = DateTime.Today.Add(startTime);
                    return true;
                }
                return false;
            }
            finally { conn.Dispose(); }
        }

        private void dgvWorkSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvWorkSchedule.Columns[e.ColumnIndex].Name == "Edit")
            {
                int scheduleId = Convert.ToInt32(dgvWorkSchedule.Rows[e.RowIndex].Cells["ScheduleId"].Value);
                OpenEditWorkSchedule(scheduleId);
            }
        }


        private void SaveShiftToDatabase(string shiftCode, DateTime openTime)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "INSERT INTO Shifts (UserId, ShiftCode, OpenTime) OUTPUT INSERTED.ShiftId VALUES (@UserId, @ShiftCode, @OpenTime)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", currentUserId);
                cmd.Parameters.AddWithValue("@ShiftCode", shiftCode);
                cmd.Parameters.AddWithValue("@OpenTime", openTime);
                shiftId = (int)cmd.ExecuteScalar();
            }
            finally { conn.Dispose(); }
        }


        private void LoadShiftInfo(string shiftCode, string employee, DateTime startTime)
        {
            lblShiftCode.Text = $"Mã ca: {shiftCode}";
            lblEmployee.Text = $"Nhân viên: {employee}";
            lblOpenTime.Text = $"Giờ mở ca: {startTime:HH:mm:ss}";
            lblStatus.Text = "Trạng thái: Đang mở";
        }

        private void LoadOrdersFromDatabase()
        {
            flowOrders.Controls.Clear();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"
            SELECT o.OrderCode, o.OrderId, 
                   CASE WHEN o.IsTakeAway = 1 THEN N'Mang về' ELSE N'Đơn tại chỗ' END AS OrderType,
                   CONCAT(o.TotalAmount, ' đ') AS Amount,
                   ISNULL(t.nameTable, 'GRABFOOD') AS Channel,
                   FORMAT(o.OrderTime, 'HH:mm') AS Time
            FROM Orders o
            LEFT JOIN Table_Details t ON o.TableId = t.ID
            WHERE o.Status IN ('New', 'Preparing')
            ORDER BY o.OrderTime DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string orderId = reader["OrderId"].ToString();
                            var card = new Panel
                            {
                                Size = new Size(380, 220),
                                Margin = new Padding(12),
                                BorderStyle = BorderStyle.FixedSingle,
                                BackColor = Color.White
                            };

                            var title = new Label
                            {
                                Text = $"📝 {reader["OrderCode"]}   |   HĐ: {orderId}",
                                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                                Dock = DockStyle.Top,
                                Height = 36,
                                Padding = new Padding(12, 6, 0, 0),
                                ForeColor = Color.Black
                            };

                            var typeAndChannel = new Label
                            {
                                Text = $"📦 {reader["OrderType"]}       📍 {reader["Channel"]}",
                                Font = new Font("Segoe UI", 12F),
                                Dock = DockStyle.Top,
                                Height = 32,
                                Padding = new Padding(12, 4, 0, 0),
                                ForeColor = Color.DimGray
                            };

                            var amountAndTime = new Label
                            {
                                Text = $"💰 {reader["Amount"]}       ⏰ {reader["Time"]}",
                                Font = new Font("Segoe UI", 12F),
                                Dock = DockStyle.Top,
                                Height = 32,
                                Padding = new Padding(12, 4, 0, 0),
                                ForeColor = Color.DimGray
                            };

                            var productLabel = new Label
                            {
                                Text = GetOrderItems(orderId),
                                Font = new Font("Segoe UI", 11F),
                                ForeColor = Color.Black,
                                Dock = DockStyle.Fill,
                                Padding = new Padding(12, 0, 0, 0)
                            };

                            var completeButton = new Button
                            {
                                Text = "✅ Hoàn thành",
                                BackColor = Color.LightGreen,
                                ForeColor = Color.Black,
                                Dock = DockStyle.Bottom,
                                Height = 40,
                                Tag = orderId,
                                FlatStyle = FlatStyle.Flat
                            };

                            completeButton.Click += (s, e) =>
                            {
                                using (SqlConnection conn2 = new SqlConnection(connStr))
                                {
                                    conn2.Open();
                                    SqlCommand doneCmd = new SqlCommand("UPDATE Orders SET Status = 'Served' WHERE OrderId = @OrderId", conn2);
                                    doneCmd.Parameters.AddWithValue("@OrderId", orderId);
                                    doneCmd.ExecuteNonQuery();
                                }

                                MessageBox.Show($"Đã hoàn thành đơn {orderId}!");
                                LoadOrdersFromDatabase();
                            };

                            card.Controls.Add(completeButton);
                            card.Controls.Add(productLabel);
                            card.Controls.Add(amountAndTime);
                            card.Controls.Add(typeAndChannel);
                            card.Controls.Add(title);
                            flowOrders.Controls.Add(card);
                        }
                    }
                }
            }
        }


        private string GetOrderItems(string orderId)
        {
            var items = new List<string>();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT P.ProductName, OD.Quantity 
                         FROM OrderDetails OD 
                         JOIN Products P ON OD.ProductId = P.ProductId 
                         WHERE OD.OrderId = @OrderId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add($"- {reader["ProductName"]} x{reader["Quantity"]}");
                        }
                    }
                }
            }

            return string.Join(Environment.NewLine, items);
        }


        private void LoadTodayOrders(bool onlyToday = true)
        {
            dgvTodayOrders.Rows.Clear();
            if (dgvTodayOrders.Columns.Count == 0)
            {
                dgvTodayOrders.Columns.Add("OrderId", "🆔 Mã Đơn");
                dgvTodayOrders.Columns.Add("OrderCode", "🔖 Mã Code");
                dgvTodayOrders.Columns.Add("OrderType", "📦 Loại");
                dgvTodayOrders.Columns.Add("Channel", "📍 bàn");
                dgvTodayOrders.Columns.Add("TotalAmount", "💰 Tổng Tiền");
                dgvTodayOrders.Columns.Add("Time", "⏰ Thời Gian");

                dgvTodayOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTodayOrders.ReadOnly = true;
                dgvTodayOrders.RowHeadersVisible = false;
                dgvTodayOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTodayOrders.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
                dgvTodayOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                dgvTodayOrders.SelectionChanged += (s, e) =>
                {
                    if (dgvTodayOrders.SelectedRows.Count > 0)
                    {
                        string orderId = dgvTodayOrders.SelectedRows[0].Cells["OrderId"].Value.ToString();
                        LoadOrderItemsToList(orderId);
                        splitTodayOrders.Panel2Collapsed = false;
                    }
                };
            }

            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT o.OrderId, o.OrderCode, 
                                CASE WHEN o.IsTakeAway = 1 THEN N'Mang về' ELSE N'Đơn tại chỗ' END AS OrderType, 
                                ISNULL(t.nameTable, 'GRABFOOD') AS Channel, 
                                o.TotalAmount, 
                                FORMAT(o.OrderTime, 'HH:mm') AS Time 
                         FROM Orders o 
                         LEFT JOIN Table_Details t ON o.TableId = t.ID " +
                                 (onlyToday ? "WHERE CAST(o.OrderTime AS DATE) = CAST(GETDATE() AS DATE)" : "") +
                                 " ORDER BY o.OrderTime DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvTodayOrders.Rows.Add(
                                reader["OrderId"],
                                reader["OrderCode"],
                                reader["OrderType"],
                                reader["Channel"],
                                string.Format("{0:N0} đ", reader["TotalAmount"]),
                                reader["Time"]
                            );
                        }
                    }
                }
            }

            splitTodayOrders.Panel2Collapsed = true;
        }


        private void LoadOrderItemsToList(string orderId)
        {
            listTodayOrderItems.Items.Clear();
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = @"SELECT P.ProductName, OD.Quantity 
                         FROM OrderDetails OD 
                         JOIN Products P ON OD.ProductId = P.ProductId 
                         WHERE OD.OrderId = @OrderId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listTodayOrderItems.Items.Add($"- {reader["ProductName"]} x{reader["Quantity"]}");
                        }
                    }
                }
            }
        }


        private void LoadProductsFromDatabase()
        {
            dgvProductList.Columns.Clear();
            dgvProductList.Rows.Clear();

            dgvProductList.Columns.Add("ProductId", "🆔 Mã SP");
            dgvProductList.Columns.Add("ProductName", "📦 Tên sản phẩm");
            dgvProductList.Columns.Add("Price", "💰 Giá (VNĐ)");
            dgvProductList.Columns.Add("Category", "📁 Danh mục");

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "SELECT p.ProductId, p.ProductName, p.Price, c.CategoryName FROM Products p JOIN Category c ON p.CategoryId = c.CategoryId";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dgvProductList.Rows.Add(
                        reader["ProductId"],
                        reader["ProductName"],
                        string.Format("{0:N0}", reader["Price"]),
                        reader["CategoryName"]
                    );
                }
            }
            finally { conn.Dispose(); }
        }


        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm form = new AddProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Đã thêm: " + form.ProductName);
                LoadProducts();
            }
        }
        private void LoadProducts()
        {
            try
            {
                // Giả sử bạn có một DataGridView hoặc FlowLayoutPanel hiển thị danh sách sản phẩm
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT ProductId, ProductName, Price FROM Products ORDER BY ProductName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                           

                            while (reader.Read())
                            {
                                string productName = reader["ProductName"].ToString();
                                string price = string.Format("{0:N0} đ", reader["Price"]);
                                Label label = new Label
                                {
                                    Text = $"{productName} - {price}",
                                    AutoSize = true,
                                    Font = new Font("Segoe UI", 12F)
                                };

                            }
                        }
                    }
                    this.Close();
                    Form_Table tb = new Form_Table();
                    tb.Show();
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }

        private void LoadWorkSchedule()
        {
            dgvWorkSchedule.Columns.Clear();
            dgvWorkSchedule.Rows.Clear();

            // Thêm cột dữ liệu
            dgvWorkSchedule.Columns.Add("UserId", "🆔 Mã NV");
            dgvWorkSchedule.Columns.Add("FullName", "👤 Họ tên");
            dgvWorkSchedule.Columns.Add("WorkDate", "📅 Ngày làm");
            dgvWorkSchedule.Columns.Add("StartTime", "🕒 Bắt đầu");
            dgvWorkSchedule.Columns.Add("ScheduleId", "ID");
            dgvWorkSchedule.Columns["ScheduleId"].Visible = false;

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT w.ScheduleId, u.UserId, u.FullName, w.WorkDate, w.StartTime
                         FROM WorkSchedule w
                         JOIN Users u ON w.UserId = u.UserId
                         ORDER BY w.WorkDate DESC, w.StartTime ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvWorkSchedule.Rows.Add(
                            reader["UserId"],
                            reader["FullName"],
                            Convert.ToDateTime(reader["WorkDate"]).ToString("dd/MM/yyyy"),
                            reader["StartTime"],
                            reader["ScheduleId"]
                        );
                    }
                }
            }

            // Thêm cột nút "✏️ Sửa"
            if (!dgvWorkSchedule.Columns.Contains("Edit"))
            {
                var btnEdit = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "✏️ Sửa",
                    HeaderText = "Thao tác",
                    UseColumnTextForButtonValue = true
                };
                dgvWorkSchedule.Columns.Add(btnEdit);
            }


            // Cài đặt hiển thị đẹp hơn
            dgvWorkSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWorkSchedule.ReadOnly = true;
            dgvWorkSchedule.RowHeadersVisible = false;
            dgvWorkSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWorkSchedule.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvWorkSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        }

        private void OpenAddWorkSchedule()
        {
            var form = new WorkScheduleForm(currentUserId); // thêm mới
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadWorkSchedule(); // reload bảng
            }
        }

        private void OpenEditWorkSchedule(int scheduleId)
        {
            var form = new WorkScheduleForm(currentUserId, scheduleId); // sửa
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadWorkSchedule(); // reload bảng
            }
        }


        private void InsertProductToDatabase(string name, int price, string ImagePath, int categoryId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                string query = "INSERT INTO Products (ProductName, Price, ImagePath, CategoryId) VALUES (@name, @price, @ImagePath, @catId)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
                cmd.Parameters.AddWithValue("@catId", categoryId);
                cmd.ExecuteNonQuery();
            }
            finally { conn.Dispose(); }
        }


        private void btnCloseShift_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Form_Table().Show();
        }
    }
}
