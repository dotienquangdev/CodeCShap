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

    #region XuLybangChinh
    
        private void FormMain_Load(object sender, EventArgs e)
        {
            EnableControlNV(false, false);

            // Khách Hàng
            dtThongTinKhachHang.DataSource = HienThiKhachHang();
            dtThongTinKhachHang.Columns[0].HeaderText = "MKH";
            dtThongTinKhachHang.Columns[1].HeaderText = "Họ Tên";
            dtThongTinKhachHang.Columns[2].HeaderText = "SDT";
            dtThongTinKhachHang.Columns[3].HeaderText = "Địa Chỉ";
            dtThongTinKhachHang.Columns[4].HeaderText = "Email";

            dtThongTinKhachHang.Columns[0].Width = 75;
            dtThongTinKhachHang.Columns[1].Width = 130;
            dtThongTinKhachHang.Columns[2].Width = 120;
            dtThongTinKhachHang.Columns[3].Width = 190;
            dtThongTinKhachHang.Columns[4].Width = 190;

 
            //Nhân Viên
            dtThongTinNhanVien.DataSource = HienThiNhanVien();
            dtThongTinNhanVien.Columns[0].HeaderText = "Ma Nhân Viên";
            dtThongTinNhanVien.Columns[1].HeaderText = "Họ Tên NV";
            dtThongTinNhanVien.Columns[2].HeaderText = "Chức Vụ";
            dtThongTinNhanVien.Columns[3].HeaderText = "SDT";

            dtThongTinNhanVien.Columns[0].Width = 150;
            dtThongTinNhanVien.Columns[1].Width = 190;
            dtThongTinNhanVien.Columns[2].Width = 150;
            dtThongTinNhanVien.Columns[3].Width = 150;
            //Bắt buộc để try catch để kiểm tra lỗi khi sử lý với DataBase
            try
            {
                dtThongTinKhachHang.DataSource = DBConnection.Instance.SelectDB("tblKhachHang").CreateDataView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        #endregion
        //////////////////////////

    #region XuLybangKhachHang

        static DataTable HienThiKhachHang()
        {
            string connectionString = "Data Source=LAPTOP-Q30JB24O\\SQLEXPRESS;Initial Catalog=QuanLyThuTienMang;Integrated Security=True";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM tblKhachHang";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    dataAdapter.Fill(dt);
                    conn.Close();
                }
            }
            return dt;
        }

        //thêm


        private void buttonInsert_Click(object sender, EventArgs e)
        {
            //Bắt buộc để try catch để kiểm tra lỗi khi sử lý với DataBase
            try
            {
                if (textBoxHoTen.Text != "" && textBoxSDT.Text != "" && textBoxSDT.Text != "" && textBoxDiaChi.Text != "")
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
                        //Value = "test",
                        Value = textBoxHoTen.Text
                    },
                    new DBParameter
                    {
                        SqlParameter = new SqlParameter("@sSoDienThoai", SqlDbType.NVarChar, 15, "sSoDienThoai"),
                        //Value = "test"
                        Value = textBoxSDT.Text
                    },
                    new DBParameter
                    {
                        SqlParameter = new SqlParameter("@sDiaChi", SqlDbType.NVarChar, 255, "sDiaChi"),
                        //Value = "test"
                        Value = textBoxDiaChi.Text
                    },
                    new DBParameter
                    {
                        SqlParameter = new SqlParameter("@sEmail", SqlDbType.NVarChar, 100, "sEmail"),
                        //Value = "test"
                        Value = textBoxEmail.Text
                    });
                    ClearTextBox();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ClearTextBox()
        {
            foreach (var item in this.Controls)
            {
                TextBox item1 = item as TextBox;
                if (item1 != null)
                {
                    item1.Clear();
                }
            }
        }

        //sửa
        private void buttonUpdate_Click(object sender, EventArgs e)
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
        private void textBoxTim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dataView = dtThongTinKhachHang.DataSource as DataView;
                dataView.AddRowFilter($"sHoTen LIKE '{textBoxTim.Text}%'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //xóa
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Nên viết thứ tự parameter theo tứ tự trong DataBase
                DBConnection.Instance.UpdateDB("tblKhachHang",
                new DBParameter // đây là điều kiện update
                {
                    SqlParameter = new SqlParameter("@iMaKhachHang", SqlDbType.Int, 0, "iMaKhachHang"),
                    Value = dtThongTinKhachHang.CurrentRow.Cells[0].Value
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
 
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                {
                    this.Close();
                }
            }
        }

    #endregion

        ////////////////////////////////

    #region XuLybangNhanVien
        static DataTable HienThiNhanVien()
        {
            string connectionString = "Data Source=LAPTOP-Q30JB24O\\SQLEXPRESS;Initial Catalog=QuanLyThuTienMang;Integrated Security=True";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM tblNhanVien";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    dataAdapter.Fill(dt);
                    conn.Close();
                }
            }
            return dt;
        }

        //Them
        private void buttonNvInsert_Click(object sender, EventArgs e)
        {
            //Bắt buộc để try catch để kiểm tra lỗi khi sử lý với DataBase
            try
            {
                if (textBoxNvHoTen.Text != "" && textBoxNvDiaChi.Text != "" && textBoxNvSDT.Text != "")
                {


                    //Nên viết thứ tự parameter theo tứ tự trong DataBase
                    DBConnection.Instance.InsertDB("tblNhanVien", "sp_ThemNhanVien",
                    new DBParameter
                    {
                        IsIdentity = true,//Thuộc tính Identity trong DataBase
                    },
                    new DBParameter
                    {
                        SqlParameter = new SqlParameter("@sHoTen", SqlDbType.NVarChar, 100, "sHoTen"),
                        //Value = "test",
                        Value = textBoxNvHoTen.Text
                    },
                    new DBParameter
                    {
                        SqlParameter = new SqlParameter("@sSoDienThoai", SqlDbType.NVarChar, 15, "sSoDienThoai"),
                        //Value = "test"
                        Value = textBoxNvSDT.Text
                    },
                    new DBParameter
                    {
                        SqlParameter = new SqlParameter("@sDiaChi", SqlDbType.NVarChar, 255, "sDiaChi"),
                        //Value = "test"
                        Value = textBoxNvDiaChi.Text
                    } );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sua
        private void buttonNvUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Nên viết thứ tự parameter theo tứ tự trong DataBase
                DBConnection.Instance.UpdateDB("tblNhanVien",
                new DBParameter // đây là điều kiện update
                {
                    SqlParameter = new SqlParameter("@iMaNhanVien", SqlDbType.Int, 0, "iMaNhanVien"),
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
                } );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Xoa
        private void buttonNvDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Nên viết thứ tự parameter theo tứ tự trong DataBase
                DBConnection.Instance.UpdateDB("tblNhanVien",
                new DBParameter // đây là điều kiện update
                {
                    SqlParameter = new SqlParameter("@iMaNhanVien", SqlDbType.Int, 0, "iMaNhanVien"),
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
                } );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Thoat
        private void buttonNVThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                {
                    this.Close();
                }
            }
        }

        private void dtThongTinNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxNvTim_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dataView = dtThongTinNhanVien.DataSource as DataView;
                dataView.AddRowFilter($"sHoTen LIKE '{textBoxTim.Text}%'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void tabPageNhanVien_Click(object sender, EventArgs e)
        {
           
        }
        void EnableControlNV(bool isNableTextBox, bool isNableDataGridView)
        {
            textBoxNvHoTen.Enabled = textBoxNvSDT.Enabled = textBoxNvDiaChi.Enabled = isNableTextBox;
            dtThongTinNhanVien.Enabled = isNableDataGridView;
        }

        private void buttonNvMo_Click(object sender, EventArgs e)
        {
            EnableControlNV(true, true);
        }
        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
