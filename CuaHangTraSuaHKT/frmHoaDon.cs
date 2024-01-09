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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
            dgvhoadon.AutoGenerateColumns = false;
            dgvchitiethoadon.AutoGenerateColumns = false;
            guna2txtthanhtien.Enabled = false;
            guna2txtdongia.Enabled = false;
            guna2txtgiamgia.Enabled = false;
            guna2txtsize.Enabled = false;
            guna2txtsoluong.Enabled = false;
            //guna2btnsuacthd.Enabled = false;
            //guna2Button2.Enabled = false;


        }

        public void reset()
        {
            guna2txtthanhtien.Clear();
            guna2txtdongia.Clear();
            guna2txtgiamgia.Clear();
            guna2txttongtien.Clear();
            guna2txtsize.Clear();
            guna2txtsoluong.Clear();
            guna2txtmahd.Enabled= true;
            guna2txtmahd.Clear();
            guna2txtmahd.Enabled = false;
            guna2txtghichu.Clear();
        }

        private void loaddsban()
        {
            guna2cbbmaban.DataSource = BanBUS.Instance.LoadDSBan();
            guna2cbbmaban.ValueMember = Constants.VAlUEMEMBERBAN;
            guna2cbbmaban.DisplayMember = Constants.DISPLAYMEMBERBAN;

        }
        private void loaddsmanv()
        {
            guna2cbbmanv.DataSource = NhanVienBUS.Instance.loadnhanvien();
            guna2cbbmanv.ValueMember = Constants.VAlUEMEMBERNV;
            guna2cbbmanv.DisplayMember = Constants.DISPLAYMEMBERNV;

        }

        private void loaddschitiethoadon()
        {
            dgvchitiethoadon.DataSource = ChiTietHoaDonBUS.Instance.LayDSCTHD();
            //guna2btnsuacthd.Enabled=false;
        }
        private void loaddsmahd()
        {
            guna2cbbctmahoadon.DataSource = HoaDonBUS.Instance.LayDSHoaDon();
            guna2cbbctmahoadon.ValueMember = Constants.VAlUEMEMBER_HD;
            guna2cbbctmahoadon.DisplayMember = Constants.DISPLAYMEMBER_HD;

        }
        private void loaddsmasp()
        {
            guna2cbbmasanpham.DataSource = SanPhamBUS.Instance.LayDSSanPham();
            guna2cbbmasanpham.ValueMember = Constants.VAlUEMEMBER_SP;
            guna2cbbmasanpham.DisplayMember = Constants.DISPLAYMEMBER_SP;

        }
        private void frmhoadon_Load(object sender, EventArgs e)
        {
            guna2cbbmaban.SelectedItem = Constants.NUMBER_DEFAULT_MINUS_ONE;
            loadds();
            loaddsban();
            loaddsmanv();
            loaddsmahd();
            loaddsmasp();
            loaddschitiethoadon();
        }
        private void loadds()
        {
            dgvhoadon.DataSource = HoaDonBUS.Instance.LayDSHoaDon();
            //guna2Button2.Enabled = false;

        }

        private void dgvhoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index > Constants.NUMBER_DEFAULT_MINUS_ONE )
            {
                guna2txtmahd.Text = dgvhoadon.Rows[index].Cells[Constants.DGV_MAHD].Value.ToString();
                guna2cbbmaban.SelectedValue = Convert.ToInt32(dgvhoadon.Rows[index].Cells[Constants.DGV_MABAN].Value);
                guna2dtpngaylaphoadon.Text = dgvhoadon.Rows[index].Cells[Constants.DGV_NGAYLAPHD].Value.ToString();
                guna2cbbmanv.SelectedValue = Convert.ToInt32(dgvhoadon.Rows[index].Cells[Constants.DGV_MANV].Value);
                guna2txttongtien.Text = dgvhoadon.Rows[index].Cells[Constants.DGV_TONGTIEN].Value.ToString();
                guna2txtghichu.Text = dgvhoadon.Rows[index].Cells[Constants.DGV_GHICHU].Value.ToString();
            }
        }

        private void guna2btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2txtghichu.Text) || string.IsNullOrEmpty(guna2txttongtien.Text))
            {
                MessageBox.Show(Constants.PLS_INPUT_INFO_HOADON, Constants.NOTIFICATION, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            HoaDonDTO hd = new HoaDonDTO()
            {
                ngayLapLapHD = (DateTime)guna2dtpngaylaphoadon.Value,
                TongTien = (float)Convert.ToDouble(guna2txttongtien.Text),
                GhiChu = guna2txtghichu.Text,
                MaNV = Convert.ToInt32(guna2cbbmanv.SelectedValue),
                MaBan = Convert.ToInt32(guna2cbbmaban.SelectedValue),
                TrangThai = false,
            };
            if (HoaDonBUS.Instance.themhd(hd))
            {
                MessageBox.Show(Constants.ADD_SUCCESS, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show(Constants.ADD_FAILURE, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            reset();
            loadds();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            HoaDonDTO hd = new HoaDonDTO()
            {
                MaHD = Convert.ToInt32(guna2txtmahd.Text),
                ngayLapLapHD = (DateTime)guna2dtpngaylaphoadon.Value,
                TongTien = Convert.ToInt32(guna2txttongtien.Text),
                GhiChu = guna2txtghichu.Text,
                MaNV = Convert.ToInt32(guna2cbbmanv.SelectedValue),
                MaBan = Convert.ToInt32(guna2cbbmaban.SelectedValue),
                TrangThai = false,
            };
            if (HoaDonBUS.Instance.suahd(hd))
            {
                MessageBox.Show(Constants.EDIT_SUCCESS, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                MessageBox.Show(Constants.EDIT_FAILURE, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            reset();
            loadds();
        }

    

        private void guna2btnsuacthd_Click(object sender, EventArgs e)
        {
            ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO()
            {
                MaHD = Convert.ToInt32(guna2cbbctmahoadon.SelectedValue),
                MaSP = Convert.ToInt32(guna2cbbmasanpham.SelectedValue),
                ThanhTien = (float)Convert.ToDouble(guna2txtthanhtien.Text),
                GiamGia = Convert.ToInt32(guna2txtgiamgia.Text),
                DonGia = (float)Convert.ToDouble(guna2txtdongia.Text),
                Size = guna2txtsize.Text,
                SoLuong = Convert.ToInt32(guna2txtsoluong.Text)
            };
            if (ChiTietHoaDonBUS.Instance.suachitiethoadon(cthd))
            {
                MessageBox.Show(Constants.EDIT_SUCCESS, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                MessageBox.Show(Constants.EDIT_FAILURE, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            //guna2btnsuacthd.Enabled = false;
            reset();
            loaddschitiethoadon();
        }

        private void dgvchitiethoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > Constants.NUMBER_DEFAULT_MINUS_ONE)
            {
                guna2txtdongia.Text = dgvchitiethoadon.Rows[index].Cells[Constants.DGV_DONGIA].Value.ToString();
                guna2cbbctmahoadon.SelectedValue = Convert.ToInt32(dgvchitiethoadon.Rows[index].Cells[Constants.DGV_MAHOADON].Value);
                guna2txtgiamgia.Text = dgvchitiethoadon.Rows[index].Cells[Constants.DGV_GIAMGIA].Value.ToString();
                guna2txtthanhtien.Text = dgvchitiethoadon.Rows[index].Cells[Constants.DGV_THANHTIEN].Value.ToString();
                guna2cbbmasanpham.SelectedValue = Convert.ToInt32(dgvchitiethoadon.Rows[index].Cells[Constants.DGV_MASP].Value);
                guna2txtsoluong.Text = dgvchitiethoadon.Rows[index].Cells[Constants.DGV_SOLUONG].Value.ToString();
                guna2txtsize.Text = dgvchitiethoadon.Rows[index].Cells[Constants.DGV_SIZE].Value.ToString();
                //guna2btnsuacthd.Enabled = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBox.Show(Constants.EXIT_THIS_PAGE, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txttimhoadon.Text))
            {
                loadds();
            }
            else
            {
                int mahd = Convert.ToInt32(txttimhoadon.Text);
                dgvhoadon.DataSource = HoaDonBUS.Instance.timmahoadon(mahd);
            }    
          
        }

       /* private void guna2txttennv_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2txttennv.Text))
            {
                loadds();
            }
            else
            {
                string ten = guna2txttennv.Text;
                dgvhoadon.DataSource = HoaDonBUS.Instance.timtennv(ten);
            }
        }*/
    }
}
