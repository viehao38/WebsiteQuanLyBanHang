using System;
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
using Bus;
using DTO;

namespace CuaHangTraSuaHKT
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            dgvnhanvien.AutoGenerateColumns = false;
            guna2rbtnam.Checked = true;
        }

        private void guna2txtsodienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void loadChucVu()
        {
            guna2cbochucvu.DataSource = chucvuBUS.Instance.loadds();
            guna2cbochucvu.DisplayMember = Constants.DISPLAYMEMBER_CHUCVU;
            guna2cbochucvu.ValueMember = Constants.VAlUEMEMBER_CHUCVU;
        }

        private void frmquanlynhanvien_Load(object sender, EventArgs e)
        {
            loadChucVu();
            loadnhanvien();
        }
        private void loadnhanvien()
        {
            dgvnhanvien.DataSource = NhanVienBUS.Instance.loadnhanvien();
        }



        private void guna2btnsua_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO()
            {
                MANV=Convert.ToInt32(guna2txtmanv.Text),
                TENNV = guna2txtten.Text,
                EMAIL = guna2txtemail.Text,
                DIACHI = guna2txtdiachi.Text,
                NGAYSINH = gunadtpNgaySinh.Value,
                NGAYVAOLAM = (DateTime)guna2dtpngayvaolam.Value,
                SODIENTHOAI = guna2txtsodienthoai.Text,
                CHUCVU = Convert.ToInt32(guna2cbochucvu.SelectedValue),
                GIOITINH= guna2rbtnam.Checked?true:false,
                TRANGTHAI = false,
            };
            if (NhanVienBUS.Instance.suanhanvien(nv))
            {
                MessageBox.Show(Constants.EDIT_NHANVIEN_SUCCESSFU, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show(Constants.EDIT_NHANVIEN_FAILED, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            reset();
            loadnhanvien();

        }

        private void guna2btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.YOU_WANNA_DEL_NHANVIEN, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                NhanVienDTO nv = new NhanVienDTO()
                {
                    MANV = Convert.ToInt32(guna2txtmanv.Text),
                    TENNV = guna2txtten.Text,
                    EMAIL = guna2txtemail.Text,
                    DIACHI = guna2txtdiachi.Text,
                    NGAYSINH = (DateTime)gunadtpNgaySinh.Value,
                    NGAYVAOLAM = (DateTime)guna2dtpngayvaolam.Value,
                    SODIENTHOAI = guna2txtsodienthoai.Text,
                    CHUCVU = Convert.ToInt32(guna2cbochucvu.SelectedValue),
                    GIOITINH = guna2rbtnam.Checked ? true : false,
                };
                if (NhanVienBUS.Instance.xoanhanvien(nv))
                {
                    MessageBox.Show(Constants.DEL_NHANVIEN_SUCCESSFU, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

                }
                else
                {
                    MessageBox.Show(Constants.DEL_ADD_NHANVIEN_FAILED, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

                }

            }
            reset();
            loadnhanvien();
        }

        private void guna2btnthem_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(guna2txtten.Text) || string.IsNullOrEmpty(guna2txtsodienthoai.Text) || string.IsNullOrEmpty(guna2txtemail.Text))
            {
                MessageBox.Show(Constants.PLS_INPUT_INFO_NHANVIEN, Constants.NOTIFICATION, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            NhanVienDTO nv = new NhanVienDTO()
            {
                TENNV = guna2txtten.Text,
                EMAIL = guna2txtemail.Text,
                DIACHI = guna2txtdiachi.Text,
                NGAYSINH = (DateTime)gunadtpNgaySinh.Value,
                NGAYVAOLAM = (DateTime)guna2dtpngayvaolam.Value,
                SODIENTHOAI = guna2txtsodienthoai.Text,
                CHUCVU = Convert.ToInt32(guna2cbochucvu.SelectedValue),
                GIOITINH = guna2rbtnam.Checked ? true : false,
                TRANGTHAI = false,
            };
            if (NhanVienBUS.Instance.themnhanvien(nv))
            {
                MessageBox.Show(Constants.ADD_NHANVIEN_SUCCESSFU, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
            {
                MessageBox.Show(Constants.ADD_NHANVIEN_FAILED, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            reset();
            loadnhanvien();

        }
        private void guna2txttimkiem_TextChanged(object sender, EventArgs e)
        {
            string tukhoa = guna2txttimkiem.Text;
            dgvnhanvien.DataSource = NhanVienBUS.Instance.timtennhanvien(tukhoa);
        }

        private void guna2btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult thoat = MessageBox.Show(Constants.EXIT_THIS_PAGE, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thoat == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public void reset()
        {
            guna2txtmanv.Clear();
            guna2txtten.Clear();
            guna2txtsodienthoai.Clear();
            guna2txtemail.Clear();
            guna2txtdiachi.Clear();
            guna2cbochucvu.SelectedItem = Constants.NUMBER_DEFAULT_MINUS_ONE;
        }

        private void dgvnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index > Constants.NUMBER_DEFAULT_MINUS_ONE)
            {
                guna2txtmanv.Text = dgvnhanvien.Rows[index].Cells[Constants.DGV_NV_MANV].Value.ToString();
                guna2txtten.Text = dgvnhanvien.Rows[index].Cells[Constants.DGV_NV_TENNV].Value.ToString();
                guna2dtpngayvaolam.Text = dgvnhanvien.Rows[index].Cells[Constants.DGV_NV_NGAYVAOLAM].Value.ToString();
                guna2txtsodienthoai.Text = dgvnhanvien.Rows[index].Cells[Constants.DGV_NV_SDT].Value.ToString();
                guna2txtemail.Text = dgvnhanvien.Rows[index].Cells[Constants.DGV_NV_EMAIL].Value.ToString();
                guna2txtdiachi.Text = dgvnhanvien.Rows[index].Cells[Constants.DGV_NV_DIACHI].Value.ToString();
                guna2cbochucvu.SelectedValue = Convert.ToInt32(dgvnhanvien.Rows[index].Cells[Constants.DGV_NV_CHUCVU].Value);
                gunadtpNgaySinh.Text = dgvnhanvien.Rows[index].Cells[Constants.DGV_NV_NGAYSINH].Value.ToString();
                if (dgvnhanvien.Rows[index].Cells[Constants.DGV_NV_GIOITINH].Value.ToString() == Constants.DGV_NV_NAM)
                {
                    guna2rbtnam.Checked = true;
                }
                else
                {
                    guna2rbtnu.Checked = true;
                }
            }
        }

        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2txtsodienthoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}


