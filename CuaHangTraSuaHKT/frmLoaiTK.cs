using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace CuaHangTraSuaHKT
{
    public partial class frmLoaiTK : Form
    {
        public frmLoaiTK()
        {
            InitializeComponent();
            txtMaLoaiTK.Enabled = false;
        }
        void resest()
        {
            txtMaLoaiTK.Text = Constants.SPAKE;
            txtTenTK.Clear();
        }
        void LoadLoaiTK()
        {
            dgvLoaiTaiKhoan.DataSource = LoaiTkBUS.Instance.LayDSLoaiTK();
        }
        private void frmLoaiTK_Load(object sender, EventArgs e)
        {
            LoadLoaiTK();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show(Constants.ENTER_ACCOUNT_TYPE_NAME);
                return;
            }
            if (LoaiTkBUS.Instance.KiemTraTonTaiDataView(txtTenTK.Text))
            {
                MessageBox.Show(Constants.ACCOUNT_TYPE_AVAILABLE_ON_SYSTEM);
                return;
            }
            LoaiTKDTO them = new LoaiTKDTO
            {
                tenloaitk = txtTenTK.Text,
            };
            if (LoaiTkBUS.Instance.ThemLoaiTk(them))
            {
                MessageBox.Show(Constants.ADD_SUCCESS);
            }
            else
            {
                MessageBox.Show(Constants.ADD_FAILURE);
            }
            LoadLoaiTK();
            resest();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLoaiTK.Text))
            {
                MessageBox.Show(Constants.SELECT_THE_ACCOUNT_TYPE_TO_EDIT);
                return;
            }

            if (string.IsNullOrEmpty(txtTenTK.Text))
            {
                MessageBox.Show(Constants.ENTER_ACCOUNT_TYPE_NAME);
                return;

            }
            if (LoaiTkBUS.Instance.KiemTraTonTai(Convert.ToInt32(txtMaLoaiTK.Text)))
            {
                MessageBox.Show(Constants.ACCOUNT_IN_USING_CANNOT_EDIT);
                return;
            }
            LoaiTKDTO sua = new LoaiTKDTO
            {
                idloaitk = Convert.ToInt32(txtMaLoaiTK.Text),
                tenloaitk = txtTenTK.Text,
            };
            if (LoaiTkBUS.Instance.SuaLoaiTk(sua))
            {
                MessageBox.Show(Constants.EDIT_SUCCESS);
            }
            else
            {
                MessageBox.Show(Constants.EDIT_FAILURE);
            }
            LoadLoaiTK();
            resest();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLoaiTK.Text))
            {
                MessageBox.Show(Constants.SELECT_THE_ACCOUNT_TYPE_TO_DELETE);
                return;
            }
            string t = Constants.NAME_ACCOUNT;
            string c = txtTenTK.Text;
            if (t == c)
            {
                MessageBox.Show(Constants.THIS_ACCOUNT_CANNOT_BE_DELETE);
                return;
            }
            DialogResult thoat = MessageBox.Show(Constants.CONFIRM_DELETE, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (thoat == DialogResult.Yes)
            {
                LoaiTKDTO xoa = new LoaiTKDTO
                {
                    idloaitk = Convert.ToInt32(txtMaLoaiTK.Text),
                };
                if (LoaiTkBUS.Instance.KiemTraTonTai(Convert.ToInt32(txtMaLoaiTK.Text)))
                {
                    MessageBox.Show(Constants.ACCOUNT_IN_USING_CANNOT_DELETE);
                    return;
                }
                else
                {
                    if (LoaiTkBUS.Instance.XoaLoaiTk(xoa))
                    {
                        MessageBox.Show(Constants.DELETE_SUCCESS);
                    }
                    else
                    {
                        MessageBox.Show(Constants.DELETE_FAILURE);
                    }
                }
            }
            LoadLoaiTK();
            resest();
        }

        private void dgvLoaiTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == Constants.NUMBER_DEFAULT_MINUS_ONE) return;
            txtMaLoaiTK.Text = dgvLoaiTaiKhoan.Rows[e.RowIndex].Cells[Constants.LICK_ZERO].Value.ToString();
            txtTenTK.Text = dgvLoaiTaiKhoan.Rows[e.RowIndex].Cells[Constants.LICK_ONE].Value.ToString();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
