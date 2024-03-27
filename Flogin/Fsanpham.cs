using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using System.Drawing;

namespace Flogin
{
    public partial class Fsanpham : Form
    {
        private SqlConnection connection;
        private string ConnectionString = @"Data Source=DESKTOP-B3E8RSQ\SQLEXPRESS;Initial Catalog=caphe;Integrated Security=True";
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table = new DataTable();

        void loaddata()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM sanpham", connection))
            {
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dtgSP.DataSource = table;
            }
        }     

        public Fsanpham()
        {
            InitializeComponent();
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            loaddata();

        }

        private void dtgSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgSP.CurrentRow.Index;
            txtSP1.Text = dtgSP.Rows[i].Cells[0].Value.ToString();
            txtSP2.Text = dtgSP.Rows[i].Cells[1].Value.ToString();
            txtSP3.Text = dtgSP.Rows[i].Cells[2].Value.ToString();
            txtSP4.Text = dtgSP.Rows[i].Cells[3].Value.ToString();
            txtSP5.Text = dtgSP.Rows[i].Cells[4].Value.ToString();
            txtSP6.Text = dtgSP.Rows[i].Cells[5].Value.ToString();
            cbSP.SelectedItem = dtgSP.Rows[i].Cells[6].Value.ToString();

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO sanpham (ma_sp, id_nguoidung, tensp, sl_sp, gia_sp, phanloai) VALUES (@ma_sp, @id_nguoidung, @tensp, @sl_sp, @gia_sp, @phanloai)", connection))
            {
                command.Parameters.AddWithValue("@ma_sp", txtSP2.Text);
                command.Parameters.AddWithValue("@id_nguoidung", txtSP3.Text);
                command.Parameters.AddWithValue("@tensp", txtSP4.Text);
                command.Parameters.AddWithValue("@sl_sp", txtSP5.Text);
                command.Parameters.AddWithValue("@gia_sp", txtSP6.Text);
                command.Parameters.AddWithValue("@phanloai", cbSP.SelectedItem.ToString());

                command.ExecuteNonQuery();
                loaddata();
            }

        }

       

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("DELETE FROM sanpham WHERE ma_sp= @ma_sp", connection))
            {
                command.Parameters.AddWithValue("@ma_sp", txtSP2.Text);

                command.ExecuteNonQuery();
                loaddata();
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM sanpham WHERE ma_sp = @ma_sp", connection))
            {
                command.Parameters.AddWithValue("@ma_sp", txtSP2.Text);

                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dtgSP.DataSource = table;
            }

        }
        private void btnHuySP_Click(object sender, EventArgs e)
        {
            txtSP1.ResetText();
            txtSP2.ResetText();
            txtSP3.ResetText();
            txtSP4.ResetText(); ;
            txtSP5.ResetText();
            txtSP6.ResetText();
            cbSP.ResetText();

        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("UPDATE sanpham SET ma_sp = @ma_sp, id_nguoidung = @id_nguoidung, tensp = @tensp, sl_sp = @sl_sp, gia_sp = @gia_sp, phanloai = @phanloai WHERE id_sanpham = @id_sanpham", connection))
            {
                command.Parameters.AddWithValue("@ma_sp", txtSP2.Text);
                command.Parameters.AddWithValue("@id_nguoidung", txtSP3.Text);
                command.Parameters.AddWithValue("@tensp", txtSP4.Text);
                command.Parameters.AddWithValue("@sl_sp", txtSP5.Text);
                command.Parameters.AddWithValue("@gia_sp",txtSP6.Text);
                command.Parameters.AddWithValue("@phanloai", cbSP.SelectedItem.ToString());
                command.Parameters.AddWithValue("@id_sanpham", txtSP1.Text);

                command.ExecuteNonQuery();
                loaddata();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fmain f = new Fmain();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Fmain f = new Fmain();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FBan fBan = new FBan();
            this.Hide();
            fBan.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fcustomer c = new Fcustomer();
            this.Hide();
            c.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FHoadon fhd = new FHoadon();
            this.Hide();
            fhd.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FThongke fhd = new FThongke();
            this.Hide();
            fhd.ShowDialog();
            this.Show();
        }
    }
}

       

        
