using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Globalization;
using Microsoft.Reporting.WinForms;

namespace CuaHangTraSuaHKT
{
    public partial class frmThanhToan : Form
    {
        static int banClick = Constants.NUMBER_DEFAULT_ZERO;
        static int maHDTheoBan = Constants.NUMBER_DEFAULT_ZERO;
        CultureInfo culture = new CultureInfo(Constants.CULTURE);
        frmQuanLyCuaHang frmQLCuaHang;
        public frmThanhToan(frmQuanLyCuaHang frm, int maban)
        {
            InitializeComponent();
            banClick = maban;
            maHDTheoBan = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banClick);
            frmQLCuaHang = frm;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            LoadHoaDonTheoBan();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }


        private void LoadHoaDonTheoBan()
        { 
            HoaDonDTO list = HoaDonBUS.Instance.LayDSHoaDonTheoBan(banClick, maHDTheoBan);
            gunatxtTenBan.Text = list.TenBan.ToString();
            gunatxtMaHoaDon.Text = list.MaHD.ToString();
            gunatxtTongTien.Text = list.TongTien.ToString(Constants.C, culture);
            gunadtpNgayLapHoaDon.Text = list.ngayLapLapHD.ToString();

        }


        private void gunabtnTroLai_Click_1(object sender, EventArgs e)
        {
            HoaDonBUS.Instance.CapNhatHoaDonDaThanhToan(maHDTheoBan, true);//Thanh toán

            BanBUS.Instance.CapNhatBanCoNguoiOrKhongCoNguoi(banClick, true);//cập nhật bàn đã thah toán

            ChiTietHoaDonBUS.Instance.XoaALLCTHD(maHDTheoBan, true);// cthd theo mã hd của bàn

            frmQLCuaHang.LoadBan();
            frmQLCuaHang.ShowHoaDon(banClick);

            this.Close();
        }

        private void gunabtnXuatPhieuHoaDon_Click_1(object sender, EventArgs e)
        {
            //frmPhieuHoaDon frm = new frmPhieuHoaDon(maHDTheoBan, (DateTime)gunadtpNgayLapHoaDon.Value);
            //frm.Show();
            //this.Close();
            float tienHD = float.Parse(gunatxtTongTien.Text, NumberStyles.Currency, culture);
            float tienkhachdua = float.Parse(gunatxtTienKhachDua.Text, NumberStyles.Currency, culture);
            if(tienHD > tienkhachdua)
            {
                MessageBox.Show(Constants.MONEY_NOT_ENOUGH, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            frmPhieuThanhToan frm = new frmPhieuThanhToan();
            frm.LoadDSCTHDCuaHoaDon(maHDTheoBan, frmDangNhap.tennv, tienkhachdua);

            frm.Show();
            this.Close();

        }

        private void gunatxtTienKhachDua_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void gunatxtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gunatxtTienKhachDua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
