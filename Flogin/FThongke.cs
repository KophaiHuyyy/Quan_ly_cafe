using Microsoft.Office.Interop.Excel;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;

namespace Flogin
{
    public partial class FThongke : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public FThongke()
        {
            InitializeComponent();
        }

        private void FThongke_Load(object sender, EventArgs e)
        {
            
            
        }

        private void buttonthongke_Click(object sender, EventArgs e)
        {
            DateTime ngayChon = dateTimePicker1.Value.Date;

            string connectionString = @"Data Source=DESKTOP-B3E8RSQ\SQLEXPRESS;Initial Catalog=caphe;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT h.ma_hoadon, s.id_sanpham, s.tensp, b.name AS tenban, h.so_luong, h.tongtien_hoadon
            FROM hoadon h
            INNER JOIN sanpham s ON h.id_sanpham = s.id_sanpham
            INNER JOIN ban b ON h.id_ban = b.id_ban
            WHERE CONVERT(date, h.ngaymua) = @NgayChon";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NgayChon", ngayChon);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Hiển thị dữ liệu trong DataGridView
                dataGridView1.DataSource = dataTable;

                // Tính tổng tiền
                decimal tongTien = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["tongtien_hoadon"] != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(row["tongtien_hoadon"]);
                    }
                }

                // Hiển thị tổng tiền trong TextBox
                textBox1.Text = tongTien.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fmain f = new Fmain();
            this.Hide();
            f.ShowDialog();
            this.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            Fcustomer c = new Fcustomer();
            this.Hide();
            c.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fsanpham fsanpham = new Fsanpham();
            this.Hide();
            fsanpham.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FBan fBan = new FBan();
            this.Hide();
            fBan.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FHoadon fhd = new FHoadon();
            this.Hide();
            fhd.ShowDialog();
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Fmain f = new Fmain();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
