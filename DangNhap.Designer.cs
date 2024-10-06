
namespace BTL
{
    partial class DangNhap
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
            this.txbDNTaiKhoan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDNDangNhap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDNMatKhau = new System.Windows.Forms.TextBox();
            this.btnDNThoat = new System.Windows.Forms.Button();
            this.checkBoxHienMK = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDNDangKy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbDNTaiKhoan
            // 
            this.txbDNTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbDNTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDNTaiKhoan.Location = new System.Drawing.Point(368, 106);
            this.txbDNTaiKhoan.Multiline = true;
            this.txbDNTaiKhoan.Name = "txbDNTaiKhoan";
            this.txbDNTaiKhoan.Size = new System.Drawing.Size(208, 38);
            this.txbDNTaiKhoan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tài Khoản:";
            // 
            // btnDNDangNhap
            // 
            this.btnDNDangNhap.BackColor = System.Drawing.Color.DarkGray;
            this.btnDNDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDNDangNhap.Location = new System.Drawing.Point(251, 303);
            this.btnDNDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btnDNDangNhap.Name = "btnDNDangNhap";
            this.btnDNDangNhap.Size = new System.Drawing.Size(136, 35);
            this.btnDNDangNhap.TabIndex = 13;
            this.btnDNDangNhap.Text = "Đăng Nhập";
            this.btnDNDangNhap.UseVisualStyleBackColor = false;
            this.btnDNDangNhap.Click += new System.EventHandler(this.btnDNDangNhap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(219, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mật Khẩu:";
            // 
            // txbDNMatKhau
            // 
            this.txbDNMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbDNMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDNMatKhau.Location = new System.Drawing.Point(368, 199);
            this.txbDNMatKhau.Multiline = true;
            this.txbDNMatKhau.Name = "txbDNMatKhau";
            this.txbDNMatKhau.Size = new System.Drawing.Size(208, 38);
            this.txbDNMatKhau.TabIndex = 15;
            // 
            // btnDNThoat
            // 
            this.btnDNThoat.BackColor = System.Drawing.Color.DarkGray;
            this.btnDNThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDNThoat.Location = new System.Drawing.Point(460, 303);
            this.btnDNThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnDNThoat.Name = "btnDNThoat";
            this.btnDNThoat.Size = new System.Drawing.Size(136, 35);
            this.btnDNThoat.TabIndex = 16;
            this.btnDNThoat.Text = "Thoát";
            this.btnDNThoat.UseVisualStyleBackColor = false;
            this.btnDNThoat.Click += new System.EventHandler(this.btnDNThoat_Click);
            // 
            // checkBoxHienMK
            // 
            this.checkBoxHienMK.AutoSize = true;
            this.checkBoxHienMK.Location = new System.Drawing.Point(489, 264);
            this.checkBoxHienMK.Name = "checkBoxHienMK";
            this.checkBoxHienMK.Size = new System.Drawing.Size(121, 21);
            this.checkBoxHienMK.TabIndex = 17;
            this.checkBoxHienMK.Text = "Hiện mật khẩu";
            this.checkBoxHienMK.UseVisualStyleBackColor = true;
            this.checkBoxHienMK.CheckedChanged += new System.EventHandler(this.checkBoxHienMK_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(457, 398);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Bạn chưa có tài khoản?";
            // 
            // btnDNDangKy
            // 
            this.btnDNDangKy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDNDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDNDangKy.Location = new System.Drawing.Point(633, 388);
            this.btnDNDangKy.Margin = new System.Windows.Forms.Padding(4);
            this.btnDNDangKy.Name = "btnDNDangKy";
            this.btnDNDangKy.Size = new System.Drawing.Size(120, 35);
            this.btnDNDangKy.TabIndex = 19;
            this.btnDNDangKy.Text = "Đăng Ký";
            this.btnDNDangKy.UseVisualStyleBackColor = false;
            this.btnDNDangKy.Click += new System.EventHandler(this.btnDNDangKy_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDNDangKy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxHienMK);
            this.Controls.Add(this.btnDNThoat);
            this.Controls.Add(this.txbDNMatKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDNDangNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbDNTaiKhoan);
            this.Name = "DangNhap";
            this.Text = "DangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbDNTaiKhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDNDangNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDNMatKhau;
        private System.Windows.Forms.Button btnDNThoat;
        private System.Windows.Forms.CheckBox checkBoxHienMK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDNDangKy;
    }
}