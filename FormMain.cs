using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = DBConnection.Instance.SelectDB("tblKhachHang");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection.Instance.InsertDB("tblKhachHang", "sp_ThemKhachHang",
                new DBParameter
                {
                    IsIdentity = true,
                },
                new DBParameter
                {
                    SqlParameter = new SqlParameter("@sHoTen", SqlDbType.NVarChar, 100, "sHoTen"),
                    Value = "test"
                },
                new DBParameter
                {
                    SqlParameter = new SqlParameter("@sSoDienThoai", SqlDbType.NVarChar, 15, "sSoDienThoai"),
                    Value = "test"
                },
                new DBParameter
                {
                    SqlParameter = new SqlParameter("@sDiaChi", SqlDbType.NVarChar, 255, "sDiaChi"),
                    Value = "test"
                },
                new DBParameter
                {
                    SqlParameter = new SqlParameter("@sEmail", SqlDbType.NVarChar, 100, "sEmail"),
                    Value = "test"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
