using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
//9
namespace CuaHangTraSuaHKT
{
    public partial class frmDangNhap : Form
    {
        static public string tennv = "";
        static public bool flagAdmin = false;
        static public int manv = Constants.NUMBER_DEFAULT_MINUS_ONE;
        static public string tentaikhoan = "";
        static public string matkhau = "";

        public frmDangNhap()
        {
            InitializeComponent();
            gunatxtMatKhau.PasswordChar = Constants.ASTERISK;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void gunabtnDangNhap_Click(object sender, EventArgs e)
        {
            manv = DangNhapBUS.Instance.LayMaNhanVien(gunatxtTenDangNhap.Text.Trim(), gunatxtMatKhau.Text.Trim());

            tennv = DangNhapBUS.Instance.LayTenNhanVien(manv);
            flagAdmin = false;

            if (TaiKhoanBUS.Instance.KiemTraTaiKhoanAdmin(TaiKhoanBUS.Instance.LayMaLoaiTKCuaNV(manv)))//check admin
                flagAdmin = true;

            if (DangNhapBUS.Instance.KiemTraDangNhap(gunatxtTenDangNhap.Text.Trim(), gunatxtMatKhau.Text.Trim()))
            {
                frmTrangChu frm = new frmTrangChu();
                frm.Show();
                frmDangNhap frme = new frmDangNhap();
                frme.Close();
            }
            else
            {
                MessageBox.Show(Constants.PASSWORD_OR_USERNAME_WRONG_INPUT_AGAIN, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                gunatxtMatKhau.Clear();
            }

            tentaikhoan = gunatxtTenDangNhap.Text.Trim();
            matkhau = gunatxtMatKhau.Text.Trim();
        }

        private void gunabtnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.YOU_WANNA_EXIT, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void gunaptbAnMatKhau_Click(object sender, EventArgs e)
        {

            if(gunatxtMatKhau.PasswordChar == Constants.ASTERISK)
            {
                gunatxtMatKhau.PasswordChar = '\0';
                gunaptbHienMatKhau.Visible = true;
                gunaptbAnMatKhau.Visible = false;
            }

        }

        private void gunaptbHienMatKhau_Click(object sender, EventArgs e)
        {
            if (gunatxtMatKhau.PasswordChar == '\0')
            {
                gunatxtMatKhau.PasswordChar = Constants.ASTERISK;
                gunaptbHienMatKhau.Visible = false;
                gunaptbAnMatKhau.Visible = true;
            }

        }
    }
}
