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
    public partial class Fmain : Form
    {
        public Fmain()
        {
            InitializeComponent();
        }

        private void btnCustormer_Click(object sender, EventArgs e)
        {
            Fcustomer c = new Fcustomer();
            this.Hide();
            c.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Hộp thoại", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (re == DialogResult.OK)
            {
                Login l = new Login();
                this.Hide();
                l.ShowDialog();
                this.Show();
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Fsanpham fsanpham = new Fsanpham();
            this.Hide();
            fsanpham.ShowDialog();
            this.Show();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            FBan fBan = new FBan();
            this.Hide();
            fBan.ShowDialog();
            this.Show();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            FHoadon fhd = new FHoadon();
            this.Hide();
            fhd.ShowDialog();
            this.Show();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            FThongke ftk = new FThongke();
            this.Hide();
            ftk.ShowDialog();
            this.Show();
        }
    }
}
