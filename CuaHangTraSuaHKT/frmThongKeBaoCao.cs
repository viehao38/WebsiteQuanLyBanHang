using Bus;
using BUS;
using DTO;
using Microsoft.Reporting.WinForms;
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
    public partial class frmThongKeBaoCao : Form
    {
        public frmThongKeBaoCao()
        {
            InitializeComponent();
            gunacbbThang.SelectedItem = 0;
        }

        private void XemThongKe_Load(object sender, EventArgs e)
        {
            LoadDSLoaiSP();
            LoadChuVu();

        }

        private void gunabtnXemThongKeChiTiet_Click(object sender, EventArgs e)
        {
            if(gunaradThongKeTheoThang.Checked)
            {
                frmXemThongKeBaoCao frm = new frmXemThongKeBaoCao();
                if(string.IsNullOrEmpty(gunatxtNam.Text))
                {
                    MessageBox.Show(Constants.PLS_INPUT_YEAR, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    return;
                }    
                frm.ThongKeDoanhThuTheoThang(Convert.ToInt32(gunacbbThang.SelectedIndex.ToString()), Convert.ToInt32(gunatxtNam.Text));
                frm.Show();
            }

            if (gunaradThongKeTuNgayDenNgay.Checked)
            {
                frmXemThongKeBaoCao frm = new frmXemThongKeBaoCao();
                frm.ThongKeDoanhThuTuNgayDenNgay((DateTime)gunadtpTuNgay.Value, (DateTime)gunadtpDenNgay.Value.AddDays(1));
                frm.Show();
            }

      

        }


        private void gunabtnXemThongKeSanPham_Click(object sender, EventArgs e)
        {
            if (gunaradThongKeTatCaSanPham.Checked)
            {
                frmXemThongKeBaoCao frm = new frmXemThongKeBaoCao();
                frm.ThongKeTatCaSanPham();
                frm.Show();
            }

            if (gunaradThongKeSanPhamTheoNhom.Checked)
            {
                frmXemThongKeBaoCao frm = new frmXemThongKeBaoCao();
                frm.ThongKeSanPhamTheoNhom();
                frm.Show();
            }

            if (gunaradThongKeSanPhamTheoLoai.Checked)
            {
                frmXemThongKeBaoCao frm = new frmXemThongKeBaoCao();
                frm.ThongKeSanPhamTheoLoai(Convert.ToInt32(gunacbbLoaiSP.SelectedValue),gunacbbLoaiSP.Text);
                frm.Show();
            }

            if(gunaradThongKeSanPhamDuocMuaNhieu.Checked)
            {
                frmXemThongKeBaoCao frm = new frmXemThongKeBaoCao();
                frm.ThongKeSanPhamBanChay();
                frm.Show();
            }    
        }

        public void LoadDSLoaiSP()
        {
            gunacbbLoaiSP.DataSource = DanhMucBUS.Istance.LayDSDanhMuc();
            gunacbbLoaiSP.ValueMember = Constants.VAlUEMEMBER_DM;
            gunacbbLoaiSP.DisplayMember = Constants.DISPLAYMEMBER_DM;
        }

        private void gunabtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadChuVu()
        {
            gunacbbChucVu.DataSource = chucvuBUS.Instance.loadds();
            gunacbbChucVu.ValueMember = Constants.VAlUEMEMBER_CHUCVU;
            gunacbbChucVu.DisplayMember = Constants.DISPLAYMEMBER_CHUCVU;
        }

        private void gunabtnXemThongKeNhanVien_Click(object sender, EventArgs e)
        {
            if(gunaradThongKeNhanVien.Checked)
            {
                frmXemThongKeBaoCao frm = new frmXemThongKeBaoCao();
                frm.ThongKeNhanVienTheoChucVu(Convert.ToInt32(gunacbbChucVu.SelectedValue),gunacbbChucVu.Text);
                frm.Show();
            }
        }

    }
}
