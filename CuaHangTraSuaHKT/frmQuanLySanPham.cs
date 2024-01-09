using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using BUS;
using DTO;
namespace CuaHangTraSuaHKT
{
    public partial class frmQuanLySanPham : Form
    {
        string path = string.Empty;
        CultureInfo culture = new CultureInfo(Constants.CULTURE);
        public frmQuanLySanPham()
        {
            InitializeComponent();
            dgvSanPham.AutoGenerateColumns = false;
            txtImage.Enabled = false;
            cbbTimKiem.SelectedIndex = Constants.NUMBER_DEFAULT_ZERO;
            cbbDonViTinh.SelectedIndex = Constants.NUMBER_DEFAULT_ZERO;

        }
        void reset()
        {
            labMaSP.Text = Constants.ASTERISKTHREE;
            txtImage.Text = Constants.SPAKE;
            txtTenSP.Clear();
            cbbDonViTinh.SelectedIndex = Constants.NUMBER_DEFAULT_ZERO;
            txtDonGiaM.Clear();
            cbbMaDanhMuc.SelectedIndex = Constants.NUMBER_DEFAULT_ZERO;
            txtDonGiaL.Clear();
            ptbAnh.Image = null;
        }
        private void LoadSanPham()
        {
            dgvSanPham.DataSource = SanPhamBUS.Instance.LayDSSanPham();
        }
        private void LoadDanhMuc()
        {
            cbbMaDanhMuc.DataSource = DanhMucBUS.Istance.LayDSDanhMuc();

        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            LoadDanhMuc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show(Constants.ENTER_PRODUCT_NAME);
                return;
            }
            else if (string.IsNullOrEmpty(txtDonGiaM.Text))
            {
                MessageBox.Show(Constants.ENTER_UNIT_PRICE_M);
                return;
            }
            else if (string.IsNullOrEmpty(txtDonGiaL.Text))
            {
                MessageBox.Show(Constants.ENTER_UNIT_PRICE_L);
                return;
            }
            float dongiaM = float.Parse(txtDonGiaM.Text, NumberStyles.Currency, culture);//chuyen thành kiểu f
            float dongiaL = float.Parse(txtDonGiaL.Text, NumberStyles.Currency, culture);//chuyen thành kiểu f
            if (string.IsNullOrEmpty(txtImage.Text))
            {
                MessageBox.Show(Constants.ADD_IMAGE);
                return;
            }

            if (SanPhamBUS.Instance.KiemTraTonTaiDataview(txtTenSP.Text))
            {
                MessageBox.Show(Constants.PRODUCT_AVAILABLE_ON_SYSTEM);
                return;
            }
            SanPhamDTO them = new SanPhamDTO
            {
                madanhmuc = Convert.ToInt32(cbbMaDanhMuc.SelectedValue),
                tensanpham = txtTenSP.Text,
                //hinhanh = txtImage.Text,
                anhsp = SanPhamBUS.Instance.ConvertImage(txtImage.Text),
                donvitinh = cbbDonViTinh.Text,
                donGiaM = dongiaM,
                donGiaL = dongiaL,
                trangthai = true
            };
            if (SanPhamBUS.Instance.ThemSanPham(them))
            {
                MessageBox.Show(Constants.ADD_SUCCESS);
            }
            else
            {
                MessageBox.Show(Constants.ADD_FAILURE);
            }
            reset();
            LoadSanPham();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (labMaSP.Text == Constants.ASTERISKTHREE)
            {
                MessageBox.Show(Constants.SELECT_THE_PRODUCT_TO_EDIT);
                return;
            }
            if (string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show(Constants.ENTER_PRODUCT_NAME);
                return;
            }
            else if (string.IsNullOrEmpty(txtDonGiaM.Text))
            {
                MessageBox.Show(Constants.ENTER_UNIT_PRICE_M);
                return;
            }
            else if (string.IsNullOrEmpty(txtDonGiaL.Text))
            {
                MessageBox.Show(Constants.ENTER_UNIT_PRICE_L);
                return;
            }
            float dongiaM = float.Parse(txtDonGiaM.Text, NumberStyles.Currency, culture);//chuyen thành kiểu f
            float dongiaL = float.Parse(txtDonGiaL.Text, NumberStyles.Currency, culture);//chuyen thành kiểu f

            if (string.IsNullOrEmpty(txtImage.Text))
            {
                MessageBox.Show(Constants.ADD_IMAGE);
                return;
            }

            if (txtImage.Text == Constants.CONSITION_IMAGE)
            {
                SanPhamDTO sua = new SanPhamDTO
                {
                    masp = Convert.ToInt32(labMaSP.Text),
                    madanhmuc = Convert.ToInt32(cbbMaDanhMuc.SelectedValue),
                    tensanpham = txtTenSP.Text,
                    donvitinh = cbbDonViTinh.Text,
                    donGiaM = dongiaM,
                    donGiaL = dongiaL,

                };
                if (SanPhamBUS.Instance.SuaSanPhamCoImage(sua))
                {
                    MessageBox.Show(Constants.EDIT_SUCCESS);
                }
                else
                {
                    MessageBox.Show(Constants.EDIT_FAILURE);
                }
            }
            else
            {
                SanPhamDTO sua = new SanPhamDTO
                {
                    masp = Convert.ToInt32(labMaSP.Text),
                    madanhmuc = Convert.ToInt32(cbbMaDanhMuc.SelectedValue),
                    tensanpham = txtTenSP.Text,
                    anhsp = SanPhamBUS.Instance.ConvertImage(txtImage.Text),
                    donvitinh = cbbDonViTinh.Text,
                    donGiaM = dongiaM,
                    donGiaL = dongiaL,

                };
                if (SanPhamBUS.Instance.SuaSanPham(sua))
                {
                    MessageBox.Show(Constants.EDIT_SUCCESS);
                }
                else
                {
                    MessageBox.Show(Constants.EDIT_FAILURE);
                }
            }

            reset();
            LoadSanPham();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (labMaSP.Text == Constants.ASTERISKTHREE)
            {
                MessageBox.Show(Constants.SELECT_THE_PRODUCT_TO_DELETE);
                return;
            }
            DialogResult xoaC = MessageBox.Show(Constants.CONFIRM_DELETE, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (xoaC == DialogResult.Yes)
            {
                SanPhamDTO xoa = new SanPhamDTO
                {
                    masp = Convert.ToInt32(labMaSP.Text),
                };

                if (SanPhamBUS.Instance.XoaSanPham(xoa))
                {
                    MessageBox.Show(Constants.DELETE_SUCCESS);
                }
                else
                {
                    MessageBox.Show(Constants.DELETE_FAILURE);
                }
            }
            reset();
            LoadSanPham();
        }


        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == Constants.NUMBER_DEFAULT_MINUS_ONE) return;
            labMaSP.Text = dgvSanPham.Rows[e.RowIndex].Cells[Constants.LICK_ID].Value.ToString();
            cbbMaDanhMuc.SelectedValue = dgvSanPham.Rows[e.RowIndex].Cells[Constants.LICK_CODE_DM].Value;
            txtTenSP.Text = dgvSanPham.Rows[e.RowIndex].Cells[Constants.LICK_NAMEPD].Value.ToString();
            cbbDonViTinh.Text = dgvSanPham.Rows[e.RowIndex].Cells[Constants.LICK_UNIT].Value.ToString();
            txtDonGiaM.Text = float.Parse(dgvSanPham.Rows[e.RowIndex].Cells[Constants.LICK_UNIT_PRICE_M].Value.ToString()).ToString(Constants.C, culture);
            txtDonGiaL.Text = float.Parse(dgvSanPham.Rows[e.RowIndex].Cells[Constants.LICK_UNIT_PRICE_L].Value.ToString()).ToString(Constants.C, culture);

            MemoryStream mmr = new MemoryStream((byte[])dgvSanPham.Rows[e.RowIndex].Cells[Constants.LICK_IMAGE].Value);
            if (mmr == null)
                return;
            System.Drawing.Image img = System.Drawing.Image.FromStream(mmr);
            ptbAnh.Image = img;
            txtImage.Text = dgvSanPham.Rows[e.RowIndex].Cells[Constants.LICK_IMAGE].Value.ToString();

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text;
            if (cbbTimKiem.SelectedIndex == Constants.NUMBER_DEFAULT_ZERO)
            {

                dgvSanPham.DataSource = SanPhamBUS.Instance.TimMaSanPham(tuKhoa);
            }
            else if (cbbTimKiem.SelectedIndex == Constants.ONE)
            {
                dgvSanPham.DataSource = SanPhamBUS.Instance.TimDanhMucSanPham(tuKhoa);
            }
            else if (cbbTimKiem.SelectedIndex == Constants.TWO)
            {
                dgvSanPham.DataSource = SanPhamBUS.Instance.TimTenSanPham(tuKhoa);
            }
            else if (cbbTimKiem.SelectedIndex == Constants.THREE)
            {
                dgvSanPham.DataSource = SanPhamBUS.Instance.TimDonViTinhSanPham(tuKhoa);
            }


        }

        private void btnLoaImage_Click_1(object sender, EventArgs e)
        {

            ofdImage.Filter = Constants.IMAGE_FILE;
            ofdImage.FilterIndex = Constants.TWO;
            ofdImage.RestoreDirectory = true;
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                ptbAnh.Image = System.Drawing.Image.FromFile(ofdImage.FileName);
                txtImage.Text = ofdImage.FileName;
            }
        }


        private void txtDonGiaM_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != Constants.DOTS))
            {
                e.Handled = true;
            }
        }

        private void txtDonGiaL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != Constants.DOTS))
            {
                e.Handled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult cc = MessageBox.Show(Constants.EXIT_THIS_PAGE, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cc == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
