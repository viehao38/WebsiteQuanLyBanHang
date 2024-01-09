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
    public partial class frmKhuVuc : Form
    {
        frmQuanLyBan frmQLban;
        public frmKhuVuc(frmQuanLyBan frm)
        {
            InitializeComponent();
            gunadgvKhuVuc.AutoGenerateColumns= false;
            gunatxtMaKhuVuc.Enabled = false;
            frmQLban= frm;
        }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmKhuVuc_Load(object sender, EventArgs e)
        {
            LoadKhuVuc();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void reset()
        {
            gunatxtMaKhuVuc.Enabled = true;
            gunatxtMaKhuVuc.Clear();
            gunatxtMaKhuVuc.Enabled = false;
            gunatxtTenKhuVuc.Clear();
        }

        public void LoadKhuVuc()
        {
            gunadgvKhuVuc.DataSource = KhuVucBUS.Instance.LayDSKhuVuc();
        }

        private void gunadgvKhuVuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if(i > Constants.NUMBER_DEFAULT_MINUS_ONE)
            {
                gunatxtMaKhuVuc.Text = gunadgvKhuVuc.Rows[i].Cells["makhuvuc"].Value.ToString();
                gunatxtTenKhuVuc.Text = gunadgvKhuVuc.Rows[i].Cells["tenkhuvuc"].Value.ToString();
            }
        }

        private void gunabtnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(gunatxtTenKhuVuc.Text))
            {
                MessageBox.Show(Constants.PLS_INPUT_NAME_KHUVUC, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (KhuVucBUS.Instance.KiemTraTenTonTai(gunatxtTenKhuVuc.Text))
            {
                MessageBox.Show(Constants.NAME_KHUVUC_EXIST, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            KhuVucDTO kv = new KhuVucDTO
            {
                tenKhuVuc = gunatxtTenKhuVuc.Text,
                trangThai = false,
            };
            
            if(KhuVucBUS.Instance.Add(kv))
            {
                MessageBox.Show(Constants.ADD_KHUVUC_SUCCESSFUL, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show(Constants.ADD_KHUVUC_FAILED, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }


            reset();
            LoadKhuVuc();
         
            frmQLban.LoadKhuVuc();

        }

        private void gunabtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gunatxtTenKhuVuc.Text))
            {
                MessageBox.Show(Constants.PLS_INPUT_NAME_KHUVUC, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (KhuVucBUS.Instance.KiemTraTenTonTai(gunatxtTenKhuVuc.Text))
            {
                MessageBox.Show(Constants.NAME_KHUVUC_EXIST, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            KhuVucDTO kv = new KhuVucDTO
            {
                maKhuVuc = Convert.ToInt32(gunatxtMaKhuVuc.Text),
                tenKhuVuc = gunatxtTenKhuVuc.Text,
                trangThai = false,
            };

            if (KhuVucBUS.Instance.Edit(kv))
            {
                MessageBox.Show(Constants.EIDT_KHUVUC_SUCCESSFUL, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show(Constants.EIDT_KHUVUC_FAILED, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            reset();

            LoadKhuVuc();
          
            frmQLban.LoadKhuVuc();
        }

        private void gunabtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gunatxtMaKhuVuc.Text))
            {
                MessageBox.Show(Constants.PLS_INPUT_CODENAME_KHUVUC, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (KhuVucBUS.Instance.KiemTraTonTaiBanTrongKhuVuc(Convert.ToInt32(gunatxtMaKhuVuc.Text)))
            {
                MessageBox.Show(Constants.BAN_IN_KHUVUC, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            KhuVucDTO kv = new KhuVucDTO
            {
                maKhuVuc = Convert.ToInt32(gunatxtMaKhuVuc.Text),
                tenKhuVuc = gunatxtTenKhuVuc.Text,
                trangThai = true,
            };

            if (KhuVucBUS.Instance.Del(kv))
            {
                MessageBox.Show(Constants.DEL_KHUVUC_SUCCESSFUL, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show(Constants.DEL_KHUVUC_FAILED, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            reset();

            LoadKhuVuc();
            frmQuanLyBan frm = new frmQuanLyBan();
            frmQLban.LoadKhuVuc();

        }
    }
}
