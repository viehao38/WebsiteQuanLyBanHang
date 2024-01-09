using Guna.UI2.WinForms;
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
    public partial class frmTrangChu : Form
    {
        bool flagAdmin = frmDangNhap.flagAdmin;//Lấy giá trị đã kiểm tra là admin hoặc ko 
        public frmTrangChu()
        {
            InitializeComponent();
           
            IsMdiContainer = true;
            gunapnlQuanLy.Visible = false;
            gunapnlHeThong.Visible = false;
            if (flagAdmin)
            {
                checkAdmin(flagAdmin);
                //guna2gtbtnQuanLy.Enabled = flagAdmin;
            }
            else
            {
                guna2gtbtnQuanLy.Enabled = false;
                gunagtThongKe.Enabled = false;
                //guna2gtbtnQuanLy.Enabled = flagAdmin;
            }
            sttTenNhanVien.Text = Constants.LOGIN_TENNV + frmDangNhap.tennv;
            timer1.Start();
            //this.frmtk = frmtk;
        }

        public void checkAdmin(bool b)
        {
            guna2gtbtnQuanLy.Enabled = b;
        }

        private void hidenSubMenu()
        {
            if(gunapnlQuanLy.Visible == true)
            {
                gunapnlQuanLy.Visible = false;
            }
            if (gunapnlHeThong.Visible == true)
            {
                gunapnlHeThong.Visible = false;
            }
        }

        private void ShowSubMenu(Guna2Panel subMenu)
        {
            if(subMenu.Visible == true)
            {
                hidenSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = true;

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmQuanLyCuaHang frm = new frmQuanLyCuaHang();
            frm.Show();
        }



        private void ShowFrm(Form frm)//cho frm con hiên vào panel trang chủ
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            gunapnlBody.Controls.Add(frm);
            gunapnlBody.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }
   



        private void gunabtnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.YOU_WANNA_EXIT, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            hidenSubMenu();

        }
        private void guna2gtbtnQuanLy_Click(object sender, EventArgs e)
        {
            ShowSubMenu(gunapnlQuanLy);
        }

        private void gunagtbtnHeThong_Click(object sender, EventArgs e)
        {
            ShowSubMenu(gunapnlHeThong);

        }

        private void gunabtnQuanLySanPham_Click(object sender, EventArgs e)
        {
            frmQuanLySanPham frm = new frmQuanLySanPham();
            ShowFrm(frm);
            hidenSubMenu();

        }

        private void gunabtnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            ShowFrm(frm);
            hidenSubMenu();

        }

        private void gunaQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan frm = new frmQuanLyTaiKhoan();
            frm.LoadNhanVien();
            ShowFrm(frm);
            hidenSubMenu();
        }

        private void gunabtnQuanLyDanhMuc_Click(object sender, EventArgs e)
        {
            frmDanhMuc frm = new frmDanhMuc();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.Dock = DockStyle.None;
            gunapnlBody.Controls.Add(frm);
            gunapnlBody.Tag = frm;
            frm.BringToFront();
            frm.Show();
            //ShowFrm(frm);
            hidenSubMenu();
        }

        private void gunabtnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frm = new frmQuanLyNhanVien();
            ShowFrm(frm);
            hidenSubMenu();
        }

        private void gunabtnQuanLyBan_Click(object sender, EventArgs e)
        {
            frmQuanLyBan frm = new frmQuanLyBan();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.Dock = DockStyle.None;
            gunapnlBody.Controls.Add(frm);
            gunapnlBody.Tag = frm;
            frm.BringToFront();
            frm.Show();

            hidenSubMenu();
        }

        private void gunabtnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan frm = new frmThongTinCaNhan();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.Dock = DockStyle.None;
            gunapnlBody.Controls.Add(frm);
            gunapnlBody.Tag = frm;
            frm.BringToFront();
            frm.Show();

            frmThongTinCaNhan frmTK = new frmThongTinCaNhan();
            frmTK.LoadTaiKhoan();
            hidenSubMenu();
        }

        private void gunaptbDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.YOU_WANNA_EXIT, Constants.NOTIFICATION, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void gunagtThongKe_Click(object sender, EventArgs e)
        {
            frmThongKeBaoCao frm = new frmThongKeBaoCao();
            ShowFrm(frm);
            hidenSubMenu();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sttThoiGian.Text = Constants.TIME + DateTime.Now.ToString(Constants.TIME_HH_MM_SS);
        }



        private void frmTrangChu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Modifiers == Keys.Control && e.KeyCode== Keys.F1)
            {
                gunagtbtnGoiMon_Click(sender,e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F2)
            {
                guna2gtbtnQuanLy_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F3)
            {
                gunabtnQuanLyNhanVien_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F4)
            {
                gunabtnQuanLySanPham_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F5)
            {
                gunabtnQuanLyHoaDon_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F6)
            {
                gunaQuanLyTaiKhoan_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F7)
            {
                gunabtnQuanLyBan_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F8)
            {
                gunabtnQuanLyDanhMuc_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F9)
            {
                gunabtnLoaiTK_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F10)
            {
                gunagtThongKe_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F11)
            {
                gunagtbtnHeThong_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F12)
            {
                gunabtnThongTinCaNhan_Click(sender, e);
            }
        }

        private void gunagtbtnGoiMon_Click(object sender, EventArgs e)
        {
            frmQuanLyCuaHang frm = new frmQuanLyCuaHang();
            ShowFrm(frm);
            hidenSubMenu();
        }

        private void gunabtnLoaiTK_Click(object sender, EventArgs e)
        {
            frmLoaiTK frm = new frmLoaiTK();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.Dock = DockStyle.None;
            gunapnlBody.Controls.Add(frm);
            gunapnlBody.Tag = frm;
            frm.BringToFront();
            frm.Show();
            //ShowFrm(frm);
            hidenSubMenu();
        }
    }
}
