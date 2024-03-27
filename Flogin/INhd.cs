using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Flogin
{
    public partial class INhd : Form
    {
       
        public INhd(string selectedItem)
        {
            InitializeComponent(GetINHOADON());
        
            LoadDataToComboBox();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-JDH1GUO;Initial Catalog=caphe;Integrated Security=True");
        private void LoadDataToComboBox()
        {
            string query = "SELECT DISTINCT ma_hoadon FROM hoadon";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            comboBox3.DisplayMember = "ma_hoadon";
            comboBox3.ValueMember = "ma_hoadon";
            comboBox3.DataSource = dt;
        }

        private void INhd_Load(object sender, EventArgs e)
        {

            this.reportViewer9.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedValue.ToString();

            SqlCommand command = new SqlCommand("SELECT ban.id_ban, ban.name, hoadon.ma_hoadon, hoadon.so_luong, hoadon.tongtien_hoadon, khachhang.ma_khachhang, khachhang.ten_khachhang, khachhang.sdt, sanpham.tensp, sanpham.ma_sp FROM ban INNER JOIN hoadon ON ban.id_ban = hoadon.id_ban INNER JOIN khachhang ON hoadon.id_khachhang = khachhang.id_khachhang INNER JOIN sanpham ON hoadon.id_sanpham = sanpham.id_sanpham WHERE hoadon.ma_hoadon = @SelectedValue", connection);
            command.Parameters.AddWithValue("@SelectedValue", selectedValue);

            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer8.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet2", dt);
            reportViewer8.LocalReport.ReportPath = "XUATHOADON.rdlc";
            reportViewer8.LocalReport.DataSources.Add(source);
            reportViewer8.RefreshReport();
        }

        private void INhd_Load_1(object sender, EventArgs e)
        {

            this.reportViewer9.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string selectedValue = comboBox3.SelectedValue.ToString();

            SqlCommand command = new SqlCommand("SELECT ban.id_ban, ban.name, hoadon.ma_hoadon, hoadon.so_luong, hoadon.tongtien_hoadon, khachhang.ma_khachhang, khachhang.ten_khachhang, khachhang.sdt, sanpham.tensp, sanpham.ma_sp FROM ban INNER JOIN hoadon ON ban.id_ban = hoadon.id_ban INNER JOIN khachhang ON hoadon.id_khachhang = khachhang.id_khachhang INNER JOIN sanpham ON hoadon.id_sanpham = sanpham.id_sanpham WHERE hoadon.ma_hoadon = @SelectedValue", connection);
            command.Parameters.AddWithValue("@SelectedValue", selectedValue);

            SqlDataAdapter d = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            d.Fill(dt);

            reportViewer9.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet2", dt);
            reportViewer9.LocalReport.ReportPath = "XUATHOADON.rdlc";
            reportViewer9.LocalReport.DataSources.Add(source);
            reportViewer9.RefreshReport();
        }
    }
}
