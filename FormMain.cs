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
            //Bắt buộc để try catch để kiểm tra lỗi khi sử lý với DataBase
            try
            {
                dataGridView1.DataSource = DBConnection.Instance.SelectDB("tblKhachHang").CreateDataView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //thêm
        private void button1_Click(object sender, EventArgs e)
        {
            //Bắt buộc để try catch để kiểm tra lỗi khi sử lý với DataBase
            try
            {
                //Nên viết thứ tự parameter theo tứ tự trong DataBase
                DBConnection.Instance.InsertDB("tblKhachHang", "sp_ThemKhachHang",
                new DBParameter
                {
                    IsIdentity = true,//Thuộc tính Identity trong DataBase
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

        //sửa
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Nên viết thứ tự parameter theo tứ tự trong DataBase
                DBConnection.Instance.UpdateDB("tblKhachHang", 
                new DBParameter // đây là điều kiện update
                {
                    SqlParameter = new SqlParameter("@iMaKhachHang", SqlDbType.Int, 0, "iMaKhachHang"),
                    Value = 1
                },
                new DBParameter // dưới cái này là các dữ liệu cần update
                {
                    SqlParameter = new SqlParameter("@sHoTen", SqlDbType.Bit, 0, "sHoTen"),
                    Value = "test434"
                },
                new DBParameter
                {
                    SqlParameter = new SqlParameter("@sSoDienThoai", SqlDbType.NVarChar, 15, "sSoDienThoai"),
                    Value = "test2"
                },
                new DBParameter
                {
                    SqlParameter = new SqlParameter("@sDiaChi", SqlDbType.NVarChar, 255, "sDiaChi"),
                    Value = "test2"
                },
                new DBParameter
                {
                    SqlParameter = new SqlParameter("@sEmail", SqlDbType.NVarChar, 100, "sEmail"),
                    Value = "test3"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //tìm
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dataView = dataGridView1.DataSource as DataView;
                dataView.AddRowFilter($"sHoTen LIKE '{textBox1.Text}%'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //xóa
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Nên viết thứ tự parameter theo tứ tự trong DataBase
                DBConnection.Instance.UpdateDB("tblKhachHang",
                new DBParameter // đây là điều kiện update
                {
                    SqlParameter = new SqlParameter("@iMaKhachHang", SqlDbType.Int, 0, "iMaKhachHang"),
                    Value = dataGridView1.CurrentRow.Cells[0].Value
                },
                new DBParameter // dưới cái này là các dữ liệu cần update
                {
                    SqlParameter = new SqlParameter("@bDeleted", SqlDbType.Bit, 0, "bDeleted"),
                    Value = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
