using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            txbDNMatKhau.PasswordChar = '*';

           
        }

        private void btnDNThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                {
                    this.Close();
                }
            }
        }

        private void checkBoxHienMK_CheckedChanged(object sender, EventArgs e)
        { 
           // checkBoxHienMK.CheckedChanged += (sender,e) =>
           // {
                if (checkBoxHienMK.Checked)
                {
                    txbDNMatKhau.PasswordChar = '\0';
                }
                else
                {
                    txbDNMatKhau.PasswordChar = '*';
                }
          //  }
        }
    


        

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDNDangKy_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
            this.Hide();
        }

        private void btnDNDangNhap_Click(object sender, EventArgs e)
        {
            FormMain fm = new FormMain();
            fm.Show();
            this.Hide();
        }
    }
}
