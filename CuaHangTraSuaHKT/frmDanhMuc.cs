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
namespace CuaHangTraSuaHKT
{
    public partial class frmDanhMuc : Form
    {
        public frmDanhMuc()
        {
            InitializeComponent();
            txtMaSanPham.Enabled= false;
        }
        void resest()
        {
            txtMaSanPham.Text = Constants.SPAKE;
            txtTenSP.Clear();
        }
        void LoadDanhMuc()
        {
            dgvDanhMuc.DataSource = DanhMucBUS.Istance.LayDSDanhMuc();
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show(Constants.ENTER_PRODUCT_TYPE_NAME);
                return;
            }
            if (DanhMucBUS.Istance.KiemTraTonTaiDataView(txtTenSP.Text))
            {
                MessageBox.Show(Constants.PRODUCT_TYPE_AVAILABLE_ON_SYSTEM);
                return;
            }
            DanhMucDTO them = new DanhMucDTO
            {
                tendanhmuc = txtTenSP.Text,
                trangthai = true
            };
            if (DanhMucBUS.Istance.ThemDanhMuc(them))
            {
                MessageBox.Show(Constants.ADD_SUCCESS);
            }
            else
            {
                MessageBox.Show(Constants.ADD_FAILURE);

            }
            LoadDanhMuc();
            resest();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSanPham.Text))
            {
                MessageBox.Show(Constants.SELECT_THE_PRODUCT_TYPE_TO_EDIT);
                return;
            }
            if (string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show(Constants.ENTER_PRODUCT_TYPE_NAME);
                return;
            }
            if (DanhMucBUS.Istance.KiemTraTonTai(Convert.ToInt32(txtMaSanPham.Text)))
            {
                MessageBox.Show(Constants.PRODUCT_IN_USING_CANNOT_EDIT);
                return;
            }
            DanhMucDTO sua = new DanhMucDTO
            {
                madanhmuc = Convert.ToInt32(txtMaSanPham.Text),
                tendanhmuc = txtTenSP.Text
            };
            if (DanhMucBUS.Istance.SuaDanhMuc(sua))
            {
                MessageBox.Show(Constants.EDIT_SUCCESS);
            }
            else
            {
                MessageBox.Show(Constants.EDIT_FAILURE);

            }
            LoadDanhMuc();
            resest();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSanPham.Text))
            {
                MessageBox.Show(Constants.SELECT_THE_PRODUCT_TYPE_TO_DELETE);
                return;
            }
            if (DanhMucBUS.Istance.KiemTraTonTai(Convert.ToInt32(txtMaSanPham.Text)))
            {
                MessageBox.Show(Constants.PRODUCT_IN_USING_CANNOT_DELETE);
                return;
            }
            
                DialogResult cc = MessageBox.Show(Constants.CONFIRM_DELETE, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cc == DialogResult.Yes)
            {
                DanhMucDTO xoa = new DanhMucDTO
                {
                    madanhmuc = Convert.ToInt32(txtMaSanPham.Text),
                };
               
                
                    if (DanhMucBUS.Istance.XoaDanhMuc(xoa))
                    {
                        MessageBox.Show(Constants.DELETE_SUCCESS);
                    }
                    else
                    {
                        MessageBox.Show(Constants.DELETE_FAILURE);

                    }
                
            }
            LoadDanhMuc();
            resest();
        }

        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == Constants.NUMBER_DEFAULT_MINUS_ONE) return;
            txtMaSanPham.Text = dgvDanhMuc.Rows[e.RowIndex].Cells[Constants.LICK_ZERO].Value.ToString();
            txtTenSP.Text = dgvDanhMuc.Rows[e.RowIndex].Cells[Constants.LICK_ONE].Value.ToString();
        }

    }


}

