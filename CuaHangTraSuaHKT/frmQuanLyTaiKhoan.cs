using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using static BUS.TaiKhoanBUS;
using BUS;
using DTO;
//using Bus;

namespace CuaHangTraSuaHKT
{
    public partial class frmQuanLyTaiKhoan : Form
    {

        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
            dgvQLYK.AutoGenerateColumns = false;
            cbbTimKiem.SelectedIndex = Constants.NUMBER_DEFAULT_ZERO;


        }
        void reset()
        {
            labMaNV.Text = Constants.ASTERISKTHREE;
            labTenThanhVien.Text = Constants.ASTERISKTHREE;
            txtMatKau.Clear();
            txtTaiKhoan.Clear();
            cbbLoaiTk.SelectedValue = Constants.NUMBER_DEFAULT_ONE;

        }

        void LoadTaiKhoan()
        {
            dgvQLYK.DataSource = TaiKhoanBUS.Instance.LayDSTaiKhoan();
        }
        void LoadLoaiTK()
        {
            cbbLoaiTk.DataSource = LoaiTkBUS.Instance.LayDSLoaiTK();
        }
        public void LoadNhanVien()
        {
            cbbTenThanhVien.DataSource = TaiKhoanBUS.Instance.LayDSNhanVien();
            cbbTenThanhVien.ValueMember = Constants.CODE_STAFF;
            cbbTenThanhVien.DisplayMember = Constants.NAME_STAFF;
        }
        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadTaiKhoan();
            LoadLoaiTK();
        }
        private void dgvQLYK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == Constants.NUMBER_DEFAULT_MINUS_ONE) return;

            labMaNV.Text = dgvQLYK.Rows[e.RowIndex].Cells[Constants.LICK_CODE_STAFF].Value.ToString();
            labTenThanhVien.Text = dgvQLYK.Rows[e.RowIndex].Cells[Constants.LICK_NAME_STAFF].Value.ToString();
            txtTaiKhoan.Text = dgvQLYK.Rows[e.RowIndex].Cells[Constants.LICK_ACCOUNT].Value.ToString();
            txtMatKau.Text = dgvQLYK.Rows[e.RowIndex].Cells[Constants.LICK_PASSWORK].Value.ToString();
            cbbLoaiTk.SelectedValue = dgvQLYK.Rows[e.RowIndex].Cells[Constants.LICK_ACCOUNT_TYPE].Value;

        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show(Constants.ENTER_THE_ACCOUNT);
                return;
            }
            else if (string.IsNullOrEmpty(txtMatKau.Text))
            {
                MessageBox.Show(Constants.ENTER_THE_PASSWORD);
                return;
            }
            bool bcheckPassword = UserBUS.IsVaidPassword(txtMatKau.Text);
            if (bcheckPassword == false)
            {
                MessageBox.Show(Constants.INVALID_PASSWORD);
                return;
            }
            TaiKhoanDTO them = new TaiKhoanDTO
            {
                tentk = txtTaiKhoan.Text,
                matkhau = Utils.GetMD5(txtMatKau.Text),
                manv = Convert.ToInt32(cbbTenThanhVien.SelectedValue),
                trangthai = true,
                maloaitk = Convert.ToInt32(cbbLoaiTk.SelectedValue)
            };

            if (TaiKhoanBUS.Instance.ThemTaiKhoan(them))
            {
                MessageBox.Show(Constants.ADD_SUCCESS);
            }
            else
            {
                MessageBox.Show(Constants.ADD_FAILURE);
            }
            reset();
            LoadNhanVien();
            LoadTaiKhoan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (labMaNV.Text == Constants.SPAKE)
            {
                MessageBox.Show(Constants.SELECT_THE_ACCOUNT_TO_EDIT);
                return;
            }
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show(Constants.ENTER_THE_ACCOUNT);
                return;
            }
            else if (string.IsNullOrEmpty(txtMatKau.Text))
            {
                MessageBox.Show(Constants.ENTER_THE_PASSWORD);
                return;
            }
            bool bcheckPassword = UserBUS.IsVaidPassword(txtMatKau.Text);
            if (bcheckPassword == false)
            {
                MessageBox.Show(Constants.INVALID_PASSWORD);
                return;
            }

            TaiKhoanDTO sua = new TaiKhoanDTO
            {
                id = Convert.ToInt32(labMaNV.Text),
                tentk = txtTaiKhoan.Text,
                matkhau = Utils.GetMD5(txtMatKau.Text),
                maloaitk = Convert.ToInt32(cbbLoaiTk.SelectedValue)
            };
            if (TaiKhoanBUS.Instance.SuaTaiKhoan(sua))
            {
                MessageBox.Show(Constants.EDIT_SUCCESS);
            }
            else
            {
                MessageBox.Show(Constants.EDIT_FAILURE);
            }
            reset();
            LoadNhanVien();
            LoadTaiKhoan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (labMaNV.Text == Constants.SPAKE)
            {
                MessageBox.Show(Constants.SELECT_THE_ACCOUNT_TO_DELETE);
                return;
            }
            string t = Constants.NAME_ACCOUNT;
            string c = cbbLoaiTk.Text;
            if (t == c)
            {
                MessageBox.Show(Constants.THIS_ACCOUNT_CANNOT_BE_DELETE);
                return;
            }

            DialogResult thoat = MessageBox.Show(Constants.CONFIRM_DELETE, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (thoat == DialogResult.Yes)
            {

                TaiKhoanDTO xoa = new TaiKhoanDTO
                {
                    id = Convert.ToInt32(labMaNV.Text),

                };
                if (TaiKhoanBUS.Instance.XoaTaiKhoan(xoa))
                {
                    MessageBox.Show(Constants.DELETE_SUCCESS);
                }
                else
                {
                    MessageBox.Show(Constants.DELETE_FAILURE);
                }
            }
            reset();
            LoadNhanVien();
            LoadTaiKhoan();
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            string tukhoa = txtTimKiem.Text;
            if (cbbTimKiem.SelectedIndex == Constants.NUMBER_DEFAULT_ZERO)
            {
                dgvQLYK.DataSource = TaiKhoanBUS.Instance.TimIDTaiKhoan(tukhoa);
            }
            else if (cbbTimKiem.SelectedIndex == Constants.NUMBER_DEFAULT_ONE)
            {
                dgvQLYK.DataSource = TaiKhoanBUS.Instance.TimTenTaiKhoan(tukhoa);
            }
            else if (cbbTimKiem.SelectedIndex == Constants.NUMBER_DEFAULT_TWO)
            {
                dgvQLYK.DataSource = TaiKhoanBUS.Instance.TimLoaiTaiKhoan(tukhoa);
            }

        }

        private void cbbTenThanhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTenThanhVien.SelectedIndex != Constants.NUMBER_DEFAULT_MINUS_ONE)
            {
                labTenThanhVien.Text = cbbTenThanhVien.Text;
                labMaNV.Text = Constants.SPAKE;
                txtMatKau.Clear();
                txtTaiKhoan.Clear();
                cbbLoaiTk.SelectedValue = Constants.NUMBER_DEFAULT_ONE;

            }
            else
            {
                reset();
            }


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBox.Show(Constants.EXIT_THIS_PAGE, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

