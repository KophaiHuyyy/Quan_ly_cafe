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

namespace Flogin
{
    public partial class Fcustomer : Form
    {
        //Kết nối csdl
        string strCon = @"Data Source=DESKTOP-B3E8RSQ\SQLEXPRESS;Initial Catalog=caphe;Integrated Security=True";
        SqlConnection sqlCon = null;
        SqlDataAdapter adapter = null;
        DataSet ds = null;
        public Fcustomer()
        {
            InitializeComponent();
        }

        private void Fcustomer_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void HienThi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }

            //Kiểm tra trạng thái(state) kết nối
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }

            //truy vấn
            string query = "SELECT * FROM khachhang";

            //Bạn cung cấp một chuỗi kết nối (SqlConnection) và một truy vấn SQL để lấy dữ liệu.
            adapter = new SqlDataAdapter(query, sqlCon);
            SqlCommandBuilder buider = new SqlCommandBuilder(adapter);

            ds = new DataSet();

            adapter.Fill(ds, "tblCustomers");

            dtgvCustomer.DataSource = ds.Tables["tblCustomers"];
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            DataRow dataRow = ds.Tables["tblCustomers"].NewRow();
            //row["customer_id"] = txtCustomerID.Text.Trim();

            dataRow["ma_khachhang"] = txtID.Text;
            dataRow["ten_khachhang"] = txtName.Text.Trim();
            dataRow["sdt"] = txtPhone.Text.Trim();
            dataRow["email"] = txtEmail.Text.Trim();
            dataRow["diachi"] = txtAdress.Text.Trim();

            ds.Tables["tblCustomers"].Rows.Add(dataRow);

            int kq = adapter.Update(ds.Tables["tblCustomers"]);
            if (kq > 0)
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        int vt = -1;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Vị trí vẫn giữ nguyên giá trị mặc định
            if (vt == -1)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng!");
                return;
            }

            DataRow dataRow = ds.Tables["tblCustomers"].Rows[vt];
            dataRow.BeginEdit();

            dataRow["ma_khachhang"] = txtID.Text;
            dataRow["ten_khachhang"] = txtName.Text.Trim();
            dataRow["sdt"] = txtPhone.Text.Trim();
            dataRow["email"] = txtEmail.Text.Trim();
            dataRow["diachi"] = txtAdress.Text.Trim();

            dataRow.EndEdit();

            int re = adapter.Update(ds.Tables["tblCustomers"]);
            if (re > 0)
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void dtgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt == -1)
            {
                return;
            }
            DataRow dataRow = ds.Tables["tblCustomers"].Rows[vt];
            txtID.Text = dataRow["ma_khachhang"].ToString();
            txtName.Text = dataRow["ten_khachhang"].ToString();
            txtPhone.Text = dataRow["sdt"].ToString();
            txtEmail.Text = dataRow["email"].ToString();
            txtAdress.Text = dataRow["diachi"].ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn xóa không?", "Hộp thoại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.Yes)
            {
                XoaKhachHang();
            }
        }

        private void XoaKhachHang()
        {
            if (vt == -1)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu!");
            }

            DataRow dataRow = ds.Tables["tblCustomers"].Rows[vt];
            dataRow.Delete();

            try
            {
                int kq = adapter.Update(ds.Tables["tblCustomers"]);
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                TimKiemKhachHangTheoID(txtSearch.Text.Trim());
            }
        }

        private void TimKiemKhachHangTheoID(string customerId)
        {
            DataRow[] resultRows = ds.Tables["tblCustomers"].Select($"ma_khachhang = '{customerId}'"); //Dấu nháy đơn xung quanh '{customerId}' là biểu thức điều kiện dưới dạng chuỗi.
                                                                                                       //Trong trường hợp này 'resultRows' chứa tất các các dòng trong bảng "tblCustormers" mà cột "ma_khachhang" có giá trị bằng với giá trị của biến 'customerId'.

            if (resultRows.Length > 0) // Điều kiện này kiểm tra xem có ít nhất 1 dòng nào thỏa mãn điều kiện tìm kiếm hay ko?
            {
                //Nếu có dòng nào 
                DataRow dataRow = resultRows[0];


                txtID.Text = dataRow["ma_khachhang"].ToString();
                txtName.Text = dataRow["ten_khachhang"].ToString();
                txtPhone.Text = dataRow["sdt"].ToString();
                txtEmail.Text = dataRow["email"].ToString();
                txtAdress.Text = dataRow["diachi"].ToString();

                MessageBox.Show("Đã tìm thấy khách hàng!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng với ID đã nhập.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.ResetText();
            txtName.ResetText();
            txtPhone.ResetText();
            txtEmail.ResetText();
            txtAdress.ResetText();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Fmain f = new Fmain();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FThongke fThongke = new FThongke();
            this.Hide();
            fThongke.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fmain f = new Fmain();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fsanpham fsanpham = new Fsanpham();
            this.Hide();
            fsanpham.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FBan fBan = new FBan();
            this.Hide();
            fBan.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FHoadon fBan = new FHoadon();
            this.Hide();
            fBan.ShowDialog();
            this.Show();
        }
    }
}
