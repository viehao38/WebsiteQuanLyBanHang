using Bus;
using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangTraSuaHKT
{
    public partial class frmThongTinCaNhan : Form
    {
        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadTaiKhoan();
        }

        public void LoadNhanVien()
        {
            
            var list = NhanVienBUS.Instance.TimNhanVienTheoMaNhanVien(frmDangNhap.manv);
            foreach(var item in list)
            {
                gunatxtTenNhanVien.Text = item.TENNV;
                gunatxtDienThoai.Text = item.SODIENTHOAI;
                gunadtpNgaySinh.Text = item.NGAYSINH.ToString();
                gunatxtEmail.Text = item.EMAIL;
            }
        }
        int maloai = -1;
        public void LoadTaiKhoan()
        {

            var list = TaiKhoanBUS.Instance.LayMaTaiKhoanNhanVienDangNhap(frmDangNhap.tentaikhoan,frmDangNhap.matkhau,frmDangNhap.manv);
            foreach (var item in list)
            {
               gunatxtTenTaiKhoan.Text = item.tentk;
                gunatxtMatKhau.Text = item.matkhau;
                maloai = item.maloaitk;
            }
        }

        private void gunaCapNhatTaiKhoan_Click(object sender, EventArgs e)
        {
            TaiKhoanDTO sua = new TaiKhoanDTO
            {
                id = frmDangNhap.manv,
                tentk = gunatxtTenTaiKhoan.Text,
                matkhau = Utils.GetMD5(gunatxtMatKhau.Text),
                maloaitk = maloai
            };
            if (TaiKhoanBUS.Instance.SuaTaiKhoan(sua))
            {
                MessageBox.Show(Constants.EDIT_SUCCESS);
            }
            else
            {
                MessageBox.Show(Constants.EDIT_FAILURE);
            }
            LoadTaiKhoan();
        }
    }
}
