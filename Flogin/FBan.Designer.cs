namespace Flogin
{
    partial class FBan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgBan = new System.Windows.Forms.DataGridView();
            this.btnSuaBan = new System.Windows.Forms.Button();
            this.btnTimBan = new System.Windows.Forms.Button();
            this.cbBan = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBan2 = new System.Windows.Forms.TextBox();
            this.txtBan1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHuyBan = new System.Windows.Forms.Button();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dtgBan);
            this.panel1.Location = new System.Drawing.Point(822, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 659);
            this.panel1.TabIndex = 1;
            // 
            // dtgBan
            // 
            this.dtgBan.BackgroundColor = System.Drawing.Color.White;
            this.dtgBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBan.GridColor = System.Drawing.Color.White;
            this.dtgBan.Location = new System.Drawing.Point(0, 221);
            this.dtgBan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgBan.Name = "dtgBan";
            this.dtgBan.RowHeadersWidth = 51;
            this.dtgBan.RowTemplate.Height = 24;
            this.dtgBan.Size = new System.Drawing.Size(939, 374);
            this.dtgBan.TabIndex = 167;
            // 
            // btnSuaBan
            // 
            this.btnSuaBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnSuaBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaBan.Location = new System.Drawing.Point(28, 32);
            this.btnSuaBan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSuaBan.Name = "btnSuaBan";
            this.btnSuaBan.Size = new System.Drawing.Size(115, 42);
            this.btnSuaBan.TabIndex = 165;
            this.btnSuaBan.Text = "Sửa ";
            this.btnSuaBan.UseVisualStyleBackColor = false;
            this.btnSuaBan.Click += new System.EventHandler(this.btnSuaBan_Click);
            // 
            // btnTimBan
            // 
            this.btnTimBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnTimBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimBan.Location = new System.Drawing.Point(28, 140);
            this.btnTimBan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTimBan.Name = "btnTimBan";
            this.btnTimBan.Size = new System.Drawing.Size(115, 40);
            this.btnTimBan.TabIndex = 163;
            this.btnTimBan.Text = "Tìm kiếm";
            this.btnTimBan.UseVisualStyleBackColor = false;
            this.btnTimBan.Click += new System.EventHandler(this.btnTimBan_Click);
            // 
            // cbBan
            // 
            this.cbBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBan.FormattingEnabled = true;
            this.cbBan.Items.AddRange(new object[] {
            "Trống ",
            "Có người"});
            this.cbBan.Location = new System.Drawing.Point(471, 33);
            this.cbBan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbBan.Name = "cbBan";
            this.cbBan.Size = new System.Drawing.Size(190, 35);
            this.cbBan.TabIndex = 162;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(350, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 27);
            this.label7.TabIndex = 161;
            this.label7.Text = "Trạng thái:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 27);
            this.label3.TabIndex = 160;
            this.label3.Text = "Tên bàn:";
            // 
            // txtBan2
            // 
            this.txtBan2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBan2.Location = new System.Drawing.Point(126, 80);
            this.txtBan2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBan2.Name = "txtBan2";
            this.txtBan2.Size = new System.Drawing.Size(201, 35);
            this.txtBan2.TabIndex = 159;
            // 
            // txtBan1
            // 
            this.txtBan1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBan1.Location = new System.Drawing.Point(126, 28);
            this.txtBan1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBan1.Name = "txtBan1";
            this.txtBan1.Size = new System.Drawing.Size(201, 35);
            this.txtBan1.TabIndex = 155;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 27);
            this.label1.TabIndex = 153;
            this.label1.Text = "ID_Bàn:";
            // 
            // btnHuyBan
            // 
            this.btnHuyBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.btnHuyBan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyBan.Location = new System.Drawing.Point(28, 85);
            this.btnHuyBan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuyBan.Name = "btnHuyBan";
            this.btnHuyBan.Size = new System.Drawing.Size(115, 44);
            this.btnHuyBan.TabIndex = 152;
            this.btnHuyBan.Text = "Hủy bỏ";
            this.btnHuyBan.UseVisualStyleBackColor = false;
            this.btnHuyBan.Click += new System.EventHandler(this.btnHuyBan_Click);
            // 
            // flpTable
            // 
            this.flpTable.Location = new System.Drawing.Point(291, 9);
            this.flpTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(525, 679);
            this.flpTable.TabIndex = 2;
            this.flpTable.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBan1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBan2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbBan);
            this.groupBox1.Location = new System.Drawing.Point(34, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 153);
            this.groupBox1.TabIndex = 168;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSuaBan);
            this.groupBox2.Controls.Add(this.btnHuyBan);
            this.groupBox2.Controls.Add(this.btnTimBan);
            this.groupBox2.Location = new System.Drawing.Point(723, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 187);
            this.groupBox2.TabIndex = 169;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Location = new System.Drawing.Point(27, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 682);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.button6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(0, 604);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(238, 78);
            this.button6.TabIndex = 5;
            this.button6.Text = "Thống Kê";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 482);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 78);
            this.button1.TabIndex = 6;
            this.button1.Text = "Hóa Đơn";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 78);
            this.button2.TabIndex = 7;
            this.button2.Text = "Khách Hàng ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lavender;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(0, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 78);
            this.button3.TabIndex = 8;
            this.button3.Text = "Bàn";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(0, 129);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(238, 78);
            this.button4.TabIndex = 9;
            this.button4.Text = "Sản Phẩm";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(86)))), ((int)(((byte)(174)))));
            this.button5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(0, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(238, 78);
            this.button5.TabIndex = 10;
            this.button5.Text = "Trang Chủ";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1786, 701);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpTable);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FBan";
            this.Text = "Bàn";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Button btnHuyBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBan2;
        private System.Windows.Forms.TextBox txtBan1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSuaBan;
        private System.Windows.Forms.Button btnTimBan;
        private System.Windows.Forms.DataGridView dtgBan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
    }
}