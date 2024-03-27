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
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace Flogin
{
    public partial class FBan : Form
    {
        private SqlConnection connection;
        private string ConnectionString = @"Data Source=DESKTOP-B3E8RSQ\SQLEXPRESS;Initial Catalog=caphe;Integrated Security=True";
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataTable table = new DataTable();

        void loaddata()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM ban", connection))
            {
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dtgBan.DataSource = table;
            }
        }

        public FBan()
        {
            InitializeComponent();
            connection = new SqlConnection(ConnectionString);
            connection.Open();
            loaddata();
            LoadTable();

        }
        #region
        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button button = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                button.Text = item.Name + Environment.NewLine + item.Status;
               
                switch (item.Status)
                {
                    case "Trống":
                        button.BackColor = Color.Aqua;
                        break;
                    default:
                        button.BackColor = Color.Red;
                        break;

                }
                flpTable.Controls.Add(button);
            }
        }

        #endregion

        private void dtgBan_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgBan.CurrentRow.Index;
            txtBan1.Text = dtgBan.Rows[i].Cells[0].Value.ToString();
            txtBan2.Text = dtgBan.Rows[i].Cells[1].Value.ToString();
            cbBan.SelectedItem = dtgBan.Rows[i].Cells[2].Value.ToString();
        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Fmain f = new Fmain();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            txtBan1.ResetText();
            txtBan2.ResetText();
            cbBan.ResetText();
        }

        private void btnTimBan_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM ban WHERE name = @name", connection))
            {
                command.Parameters.AddWithValue("@name", txtBan2.Text);

                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dtgBan.DataSource = table;
            }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand("UPDATE ban SET name = @name,  status = @status WHERE id_ban = @id_ban", connection))
            {
                command.Parameters.AddWithValue("@name", txtBan2.Text);
                command.Parameters.AddWithValue("@status", cbBan.SelectedItem.ToString());
                command.Parameters.AddWithValue("@id_ban", txtBan1.Text);

                command.ExecuteNonQuery();
                loaddata();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Fcustomer c = new Fcustomer();
            this.Hide();
            c.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FHoadon fhd = new FHoadon();
            this.Hide();
            fhd.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FThongke fhd = new FThongke();
            this.Hide();
            fhd.ShowDialog();
            this.Show();
        }
    }
}
