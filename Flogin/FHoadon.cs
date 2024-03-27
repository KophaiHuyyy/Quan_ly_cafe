using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;
using QRCoder;
using System.Windows.Controls;

namespace Flogin
{

    public partial class FHoadon : Form
    {
        private SqlConnection connection;
        private string ConnectionString = @"Data Source=DESKTOP-B3E8RSQ\SQLEXPRESS;Initial Catalog=caphe;Integrated Security=True";
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table = new DataTable();


        public FHoadon()
        {
            InitializeComponent();
            textBoxtongtien.Enabled = false;

        }


        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT hd.ma_hoadon AS 'Mã hóa đơn',
                            kh.ma_khachhang AS 'Mã khách hàng',
                            hd.id_ban AS 'ID bàn',
                            sp.ma_sp AS 'Mã sản phẩm',
                            sp.tensp AS 'Tên sản phẩm',
                            hd.so_luong AS 'Số lượng',
                            hd.tongtien_hoadon AS 'Tổng tiền'
                     FROM hoadon hd
                     JOIN sanpham sp ON hd.id_sanpham = sp.id_sanpham
                     JOIN khachhang kh ON hd.id_khachhang = kh.id_khachhang
                     JOIN ban b ON hd.id_ban = b.id_ban";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        table.Clear();
                        adapter.Fill(table);
                        dataGridView1.DataSource = table;

                        // Tạm dừng việc hiển thị tổng tiền
                        // CalculateAndDisplayTotalPrices();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void CalculateAndDisplayTotalPrices()
        {
            Dictionary<string, decimal> dictTongTienHoaDon = new Dictionary<string, decimal>();

            foreach (DataRow row in table.Rows)
            {
                string maHoaDon = row["Mã hóa đơn"].ToString();
                decimal total = 0;

                foreach (DataRow subRow in table.Rows)
                {
                    string cellValue = subRow["Mã hóa đơn"].ToString();
                    if (cellValue == maHoaDon && decimal.TryParse(subRow["Tổng tiền"].ToString(), out decimal subRowTotal))
                    {
                        total += subRowTotal;
                    }
                }

                if (!dictTongTienHoaDon.ContainsKey(maHoaDon))
                {
                    dictTongTienHoaDon.Add(maHoaDon, total);
                }
            }

            string currentMaHoaDon = textBoxMaHD.Text;
            if (dictTongTienHoaDon.ContainsKey(currentMaHoaDon))
            {
                textBoxtongtien.Text = dictTongTienHoaDon[currentMaHoaDon].ToString();
            }
            else
            {
                textBoxtongtien.Text = "0";
            }
        }


        private void LoadComboBoxData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Load dữ liệu sản phẩm vào ComboBox comboBoxSanPham
                    string productQuery = "SELECT id_sanpham, tensp, ma_sp FROM sanpham";
                    using (SqlCommand productCommand = new SqlCommand(productQuery, connection))
                    {
                        SqlDataReader productReader = productCommand.ExecuteReader();
                        List<KeyValuePair<int, string>> productList = new List<KeyValuePair<int, string>>();
                        while (productReader.Read())
                        {
                            int productId = productReader.GetInt32(productReader.GetOrdinal("id_sanpham"));
                            string productName = productReader.GetString(productReader.GetOrdinal("tensp"));
                            string productCode = productReader.GetString(productReader.GetOrdinal("ma_sp"));
                            productList.Add(new KeyValuePair<int, string>(productId, productName));
                        }
                        productReader.Close();

                        comboBoxSanPham.DataSource = productList;
                        comboBoxSanPham.DisplayMember = "Value";
                        comboBoxSanPham.ValueMember = "Key";
                    }

                    // Load dữ liệu khách hàng vào ComboBox comboBoxKH
                    string customerQuery = "SELECT id_khachhang, ma_khachhang FROM khachhang";
                    using (SqlCommand customerCommand = new SqlCommand(customerQuery, connection))
                    {
                        SqlDataReader customerReader = customerCommand.ExecuteReader();
                        List<KeyValuePair<int, string>> customerList = new List<KeyValuePair<int, string>>();
                        while (customerReader.Read())
                        {
                            int customerId = customerReader.GetInt32(customerReader.GetOrdinal("id_khachhang"));
                            string customerCode = customerReader.GetString(customerReader.GetOrdinal("ma_khachhang"));
                            customerList.Add(new KeyValuePair<int, string>(customerId, customerCode));
                        }
                        customerReader.Close();

                        comboBoxKH.DataSource = customerList;
                        comboBoxKH.DisplayMember = "Value";
                        comboBoxKH.ValueMember = "Key";
                    }

                    // Load dữ liệu bàn vào ComboBox comboBoxban
                    string tableQuery = "SELECT id_ban FROM ban";
                    using (SqlCommand tableCommand = new SqlCommand(tableQuery, connection))
                    {
                        SqlDataReader tableReader = tableCommand.ExecuteReader();
                        List<int> tableList = new List<int>();
                        while (tableReader.Read())
                        {
                            int tableId = tableReader.GetInt32(tableReader.GetOrdinal("id_ban"));
                            tableList.Add(tableId);
                        }
                        tableReader.Close();

                        comboBoxban.DataSource = tableList;
                    }

                    string uniqueMaHDQuery = "SELECT DISTINCT ma_hoadon FROM hoadon";
                    using (SqlCommand command = new SqlCommand(uniqueMaHDQuery, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBoxtk.Items.Add(reader["ma_hoadon"].ToString());
                        }
                        reader.Close();
                    }



                    string productCodeQuery = "SELECT id_sanpham, ma_sp FROM sanpham";
                    using (SqlCommand productCodeCommand = new SqlCommand(productCodeQuery, connection))
                    {
                        SqlDataReader productCodeReader = productCodeCommand.ExecuteReader();
                        List<KeyValuePair<int, string>> productCodeList = new List<KeyValuePair<int, string>>();
                        while (productCodeReader.Read())
                        {
                            int productId = productCodeReader.GetInt32(productCodeReader.GetOrdinal("id_sanpham"));
                            string productCode = productCodeReader.GetString(productCodeReader.GetOrdinal("ma_sp"));
                            productCodeList.Add(new KeyValuePair<int, string>(productId, productCode));
                        }
                        productCodeReader.Close();

                        comboBoxMaH.DataSource = productCodeList;
                        comboBoxMaH.DisplayMember = "Value";
                        comboBoxMaH.ValueMember = "Key";
                    }



                    string query = "SELECT DISTINCT ma_hoadon FROM ban INNER JOIN hoadon ON ban.id_ban = hoadon.id_ban INNER JOIN khachhang ON hoadon.id_khachhang = khachhang.id_khachhang INNER JOIN sanpham ON hoadon.id_sanpham = sanpham.id_sanpham";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["ma_hoadon"].ToString());
                        }
                        reader.Close();
                    }

                    string uniqueMaHDQuer = "SELECT DISTINCT ma_hoadon FROM hoadon";
                    using (SqlCommand command = new SqlCommand(uniqueMaHDQuer, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader["ma_hoadon"].ToString());
                        }
                        reader.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Lấy thông tin từ DataGridView và gán vào các control như ComboBox và TextBox
                textBoxMaHD.Text = selectedRow.Cells["Mã hóa đơn"].Value?.ToString();
                textBoxSl.Text = selectedRow.Cells["Số lượng"].Value?.ToString();
                // Lấy thông tin sản phẩm và khách hàng tương ứng với hóa đơn
                string tenSanPham = selectedRow.Cells["Tên sản phẩm"].Value?.ToString();
                string maSanPham = selectedRow.Cells["Mã sản phẩm"].Value?.ToString();
                // Điền thông tin vào các control tương ứng (comboBox hoặc textBox)
                comboBoxSanPham.Text = tenSanPham;
                comboBoxMaH.Text = maSanPham;
                CalculateAndDisplayTotalPrices(); // Tính toán và hiển thị lại tổng tiền 
                // Hiển thị thông tin của hóa đơn đã chọn để người dùng có thể chỉnh sửa
            }
        }




        private List<int> selectedProducts = new List<int>();
        private object productCodeCommand;

        void addToSelectedProducts(int idSanPham)
        {
            if (!selectedProducts.Contains(idSanPham))
            {
                selectedProducts.Add(idSanPham);
            }
        }

        void addSelectedProductsToHoaDon(int idHoaDon)
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    foreach (int idSanPham in selectedProducts)
                    {
                        string query = @"INSERT INTO chi_tiet_hoa_don (id_hoadon, id_sanpham, so_luong, gia_ban)
                                         VALUES (@idHoaDon, @idSanPham, @soLuong, @giaBan)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idHoaDon", idHoaDon);
                            command.Parameters.AddWithValue("@idSanPham", idSanPham);
                            // Thay đổi giá trị cho @soLuong và @giaBan tùy thuộc vào cách bạn lấy thông tin từ giao diện người dùng
                            command.Parameters.AddWithValue("@soLuong", 1);
                            command.Parameters.AddWithValue("@giaBan", 0);
                            command.ExecuteNonQuery();
                        }
                    }

                    // Xóa danh sách sản phẩm đã chọn
                    selectedProducts.Clear();
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception (nếu có)
                MessageBox.Show("Đã xảy ra lỗi khi thêm sản phẩm vào hóa đơn: " + ex.Message);
            }
        }

       

        private void FHoadon_Load(object sender, EventArgs e)
        {

            LoadData();
            LoadComboBoxData();
            dataGridView1.CellClick += dataGridView1_CellClick;

          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy thông tin từ DataGridView và gán vào các control như ComboBox và TextBox
                textBoxMaHD.Text = selectedRow.Cells["Mã hóa đơn"].Value?.ToString();
                textBoxSl.Text = selectedRow.Cells["Số lượng"].Value?.ToString();

                // Lấy thông tin sản phẩm và khách hàng tương ứng với hóa đơn
                string tenSanPham = selectedRow.Cells["Tên sản phẩm"].Value?.ToString();
                string maSanPham = selectedRow.Cells["Mã sản phẩm"].Value?.ToString();
                string maHoaDon = selectedRow.Cells["Mã hóa đơn"].Value?.ToString();
                string maBan = selectedRow.Cells["ID bàn"].Value?.ToString();
                string maKhachHang = selectedRow.Cells["Mã khách hàng"].Value?.ToString(); 

                textBoxMaHD.Text = maHoaDon;
                comboBoxban.Text = maBan;
                comboBoxSanPham.Text = tenSanPham;
                comboBoxMaH.Text = maSanPham;
                comboBoxKH.Text = maKhachHang; 

                CalculateAndDisplayTotalPrices();
         
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                string maHoaDon = selectedRow.Cells["MaHD"].Value?.ToString();
                string maBan = selectedRow.Cells["IDBan"].Value?.ToString();
                string maSanPham = selectedRow.Cells["MaSP"].Value?.ToString();
                string tenSanPham = selectedRow.Cells["TenSP"].Value?.ToString();
                string soLuong = selectedRow.Cells["SoLuong"].Value?.ToString();

                try
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();

                        string query = @"UPDATE hoadon 
                                 SET id_ban = @maBan,
                                     id_sanpham = @maSanPham,
                                     tensp = @tenSanPham,
                                     so_luong = @soLuong
                                 WHERE ma_hoadon = @maHoaDon";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maHoaDon", maHoaDon);
                            command.Parameters.AddWithValue("@maBan", maBan);
                            command.Parameters.AddWithValue("@maSanPham", maSanPham);
                            command.Parameters.AddWithValue("@tenSanPham", tenSanPham);
                            command.Parameters.AddWithValue("@soLuong", soLuong);

                            command.ExecuteNonQuery();

                            // Cập nhật thành công, không cần reload toàn bộ DataGridView, chỉ cần reload dòng đã được chỉnh sửa
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = selectedRow.Cells[e.ColumnIndex].Value;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin: " + ex.Message);
                }
            }
        }
        private void buttonthoat_Click(object sender, EventArgs e)
        {
            Fmain f = new Fmain();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void buttonthem_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string maHoaDon = textBoxMaHD.Text;
                    DateTime ngayMua = dateTimePicker1.Value;
                    int idBan = ((int)comboBoxban.SelectedItem);
                    int idKhachHang = ((KeyValuePair<int, string>)comboBoxKH.SelectedItem).Key;
                    int idSanPham = ((KeyValuePair<int, string>)comboBoxMaH.SelectedItem).Key;
                    int soLuong = int.Parse(textBoxSl.Text);

                    // Lấy giá sản phẩm từ CSDL
                    decimal giaSanPham = 0;
                    SqlCommand getPriceCommand = new SqlCommand("SELECT gia_sp FROM sanpham WHERE id_sanpham = @idSanPham", connection);
                    getPriceCommand.Parameters.AddWithValue("@idSanPham", idSanPham);
                    object result = getPriceCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        giaSanPham = Convert.ToDecimal(result);
                    }

                    decimal tongTien = giaSanPham * soLuong; // Tính toán tổng tiền dựa trên giá sản phẩm và số lượng

                    // Thêm hóa đơn vào bảng "hoadon"
                    SqlCommand addInvoiceCommand = new SqlCommand("INSERT INTO hoadon (ma_hoadon, id_khachhang, id_ban, id_sanpham, ngaymua, so_luong, tongtien_hoadon) VALUES (@maHoaDon, @idKhachHang, @idBan, @idSanPham, @ngayMua, @soLuong, @tongTien)", connection);
                    addInvoiceCommand.Parameters.AddWithValue("@maHoaDon", maHoaDon);
                    addInvoiceCommand.Parameters.AddWithValue("@idKhachHang", idKhachHang);
                    addInvoiceCommand.Parameters.AddWithValue("@idBan", idBan);
                    addInvoiceCommand.Parameters.AddWithValue("@idSanPham", idSanPham);
                    addInvoiceCommand.Parameters.AddWithValue("@ngayMua", ngayMua);
                    addInvoiceCommand.Parameters.AddWithValue("@soLuong", soLuong);
                    addInvoiceCommand.Parameters.AddWithValue("@tongTien", tongTien);
                    addInvoiceCommand.ExecuteNonQuery();

                    // Tắt liên kết nguồn dữ liệu (DataSource) của comboBoxtk
                    comboBoxtk.DataSource = null;

                    comboBoxtk.Items.Clear(); // Xóa tất cả các item trong comboBoxtk

                    // Thêm mã hóa đơn vào comboBoxtk
                    comboBoxtk.Items.Add(maHoaDon);

                    // Bật lại liên kết nguồn dữ liệu (DataSource) của comboBoxtk với nguồn dữ liệu hợp lệ
                    // Ví dụ: comboBoxtk.DataSource = yourDataSource;

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm hóa đơn: " + ex.Message);
            }
        }
    

        private void buttonsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một dòng để cập nhật thông tin.");
                    return;
                }

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Lấy thông tin từ các control trên giao diện
                string maHoaDon = textBoxMaHD.Text;
                int soLuong;
                bool parseSuccess = int.TryParse(textBoxSl.Text, out soLuong);
                if (!parseSuccess)
                {
                    MessageBox.Show("Giá trị số lượng không hợp lệ.");
                    return;
                }

                int maBan = -1;
                if (comboBoxban.SelectedIndex != -1)
                {
                    maBan = (int)comboBoxban.SelectedValue;
                }
                else
                {
                    MessageBox.Show("Chưa chọn giá trị từ comboBoxban.");
                    return;
                }

                int maKhachHang = -1;
                if (comboBoxKH.SelectedIndex != -1)
                {
                    maKhachHang = (int)comboBoxKH.SelectedValue;
                }
                else
                {
                    MessageBox.Show("Chưa chọn giá trị từ comboBoxKH.");
                    return;
                }

                int maSanPham = -1;
                if (comboBoxMaH.SelectedIndex != -1)
                {
                    maSanPham = (int)comboBoxMaH.SelectedValue;
                }
                else
                {
                    MessageBox.Show("Chưa chọn giá trị từ comboBoxMaH.");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Kiểm tra mã hóa đơn trước khi cập nhật
                    string checkHoaDonQuery = "SELECT COUNT(*) FROM hoadon WHERE ma_hoadon = @maHoaDon";
                    using (SqlCommand checkHoaDonCommand = new SqlCommand(checkHoaDonQuery, connection))
                    {
                        checkHoaDonCommand.Parameters.AddWithValue("@maHoaDon", maHoaDon);
                        int hoaDonCount = (int)checkHoaDonCommand.ExecuteScalar();

                        if (hoaDonCount == 0)
                        {
                            MessageBox.Show("Hóa đơn không tồn tại. Vui lòng chọn một hóa đơn khác.");
                            return;
                        }
                    }

                    // Cập nhật thông tin hóa đơn trong cơ sở dữ liệu
                    string updateHoaDonQuery = @"
                UPDATE hoadon
                SET id_sanpham = @maSanPham, so_luong = @soLuong, id_ban = @maBan, id_khachhang = @maKhachHang
                WHERE ma_hoadon = @maHoaDon";

                    using (SqlCommand updateHoaDonCommand = new SqlCommand(updateHoaDonQuery, connection))
                    {
                        updateHoaDonCommand.Parameters.AddWithValue("@maHoaDon", maHoaDon);
                        updateHoaDonCommand.Parameters.AddWithValue("@maSanPham", maSanPham);
                        updateHoaDonCommand.Parameters.AddWithValue("@soLuong", soLuong);
                        updateHoaDonCommand.Parameters.AddWithValue("@maBan", maBan);
                        updateHoaDonCommand.Parameters.AddWithValue("@maKhachHang", maKhachHang);

                        int rowsAffected = updateHoaDonCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Nếu có hàng bị ảnh hưởng, cập nhật lại dữ liệu trên DataGridView
                            string getUpdatedHoaDonQuery = @"
                        SELECT h.id_sanpham, sp.tensp, h.so_luong
                        FROM hoadon h
                        INNER JOIN sanpham sp ON h.id_sanpham = sp.id_sanpham
                        WHERE h.ma_hoadon = @maHoaDon";

                            using (SqlCommand getUpdatedHoaDonCommand = new SqlCommand(getUpdatedHoaDonQuery, connection))
                            {
                                getUpdatedHoaDonCommand.Parameters.AddWithValue("@maHoaDon", maHoaDon);

                                using (SqlDataReader reader = getUpdatedHoaDonCommand.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        int updatedMaSanPham = reader.GetInt32(0);
                                        string updatedTenSanPham = reader.GetString(1);
                                        int updatedSoLuong = reader.GetInt32(2);

                                        // Cập nhật lại các giá trị của dòng đã được chỉnh sửa
                                        selectedRow.Cells["Mã sản phẩm"].Value = updatedMaSanPham;
                                        selectedRow.Cells["Tên sản phẩm"].Value = updatedTenSanPham;
                                        selectedRow.Cells["Số lượng"].Value = updatedSoLuong;
                                    }
                                }
                            }

                            MessageBox.Show("Đã cập nhật thông tin hóa đơn thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thông tin hóa đơn không thành công.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        private void buttonxoaHD_Click(object sender, EventArgs e)
        {
            string maHoaDon = textBoxMaHD.Text.Trim();

            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn để xóa.");
                return;
            }

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("DELETE FROM hoadon WHERE ma_hoadon = @maHoaDon", connection))
                    {
                        command.Parameters.AddWithValue("@maHoaDon", maHoaDon);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã xóa hóa đơn thành công!");
                if (comboBoxtk.Items.Contains(maHoaDon))
                {
                    comboBoxtk.Items.Remove(maHoaDon);
                }
                

                LoadData(); // Reload DataGridView after deleting data
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xóa hóa đơn: {ex.Message}");
            }
        }
        private void LoadDataToDataGridView(DataTable dataTable)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.DataSource = dataTable;
        }
        private void buttontim_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string maHoaDon = comboBoxtk.SelectedItem?.ToString();

                    if (!string.IsNullOrEmpty(maHoaDon))
                    {
                        string query = @"SELECT * FROM hoadon WHERE ma_hoadon = @maHoaDon";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@maHoaDon", maHoaDon);

                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                // Hiển thị thông tin hóa đơn trong DataGridView
                                LoadDataToDataGridView(dataTable);

                                // Tính toán và hiển thị tổng tiền của hóa đơn đã chọn
                                decimal tongTien = 0;
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    tongTien += Convert.ToDecimal(row["tongtien_hoadon"]);
                                }

                                textBoxtongtien.Text = tongTien.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy hóa đơn với mã hóa đơn đã chọn.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một mã hóa đơn để tìm kiếm.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm hóa đơn: " + ex.Message);
            }
        }

        private void buttonxuaatexcel_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
            DataObject copydata = dataGridView1.GetClipboardContent();
            if (copydata != null) Clipboard.SetDataObject(copydata);
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook xlWbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object miseddata = System.Reflection.Missing.Value;
            xlWbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            xlr.Select();

            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }

        private void buttonin_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString(); // Lấy mục đã chọn trong ComboBox 
            INhd nhd = new INhd(selectedItem);
            this.Hide();
            nhd.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedValue = comboBox2.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedValue))
            {
                CalculateAndDisplayTotalPrices(); // Tính toán và hiển thị tổng giá trị

                decimal price = decimal.Parse(textBoxtongtien.Text); // Lấy giá trị tổng tiền từ TextBox

                string qrText = "Giá: " + price.ToString("F2") + " - Lựa chọn: " + selectedValue;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeBitmap = qrCode.GetGraphic(5);

                pictureBox1.Image = qrCodeBitmap;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục trong ComboBox!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fmain f = new Fmain();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FThongke  fhd = new FThongke();
            this.Hide();
            fhd.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FBan fBan = new FBan();
            this.Hide();
            fBan.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fsanpham fsanpham = new Fsanpham();
            this.Hide();
            fsanpham.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fcustomer c = new Fcustomer();
            this.Hide();
            c.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FThongke c = new FThongke();
            this.Hide();
            c.ShowDialog();
            this.Show();

        }
    }
}
