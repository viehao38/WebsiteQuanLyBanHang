using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace CuaHangTraSuaHKT
{
    public partial class frmQuanLyBan : Form
    {
        public frmQuanLyBan()
        {
            InitializeComponent();
            guna2txtMaBan.Enabled = false;
        }

        private void frmQuanLyBan_Load(object sender, EventArgs e)
        {
            LoadDSBan();
            LoadKhuVuc();
            this.FormBorderStyle= FormBorderStyle.FixedSingle;
        }

        private void LamMoi()
        {
            guna2txtMaBan.Clear();
            guna2txtTenBan.Clear();
        }

        public void LoadKhuVuc()
        {
            List<KhuVucDTO> list = KhuVucBUS.Instance.LayDSKhuVuc();
            gunacbbKhuVuc.DataSource= list;
            gunacbbKhuVuc.DisplayMember= Constants.DISPLAYMEMBERKHUVUC;
            gunacbbKhuVuc.ValueMember= Constants.VAlUEMEMBERKHUVUC;
        }

        private void LoadDSBan()
        {
            flpDSBan.Controls.Clear();
            List<BanDTO> list;
            if (string.IsNullOrEmpty(gunatxtTimKiem.Text))
            {
                list = BanBUS.Instance.LoadDSBan();
            }    
            else
            {
                list = BanBUS.Instance.TimKiemBan(gunatxtTimKiem.Text);
            }    
           
            uscBan[] myUS = new uscBan[list.Count];

            int i = Constants.COUNT_OBJECT_IN_LIST;
            foreach (BanDTO item in list)
            {
                myUS[i] = new uscBan();
                myUS[i].TenBan = item.TenBan;
                myUS[i].MaBan = item.MaBan;
                myUS[i].MaKhuVuc = item.MaKhuVuc;
                myUS[i].TrangThai = item.TrangThai;
                if (myUS[i].TrangThai)
                {
                    myUS[i].BackColor = Color.PowderBlue;
                }
                else
                {
                    myUS[i].BackColor = Color.Transparent;
                }

                flpDSBan.Controls.Add(myUS[i]);

                myUS[i].Click += new System.EventHandler(this.uscBan_Click);
                i++;
            }
        }
        private void uscBan_Click(object sender, System.EventArgs e)
        {
            uscBan uscBan = (uscBan)sender;
            guna2txtMaBan.Text = uscBan.MaBan.ToString();
            guna2txtTenBan.Text = uscBan.TenBan.ToString();
            gunacbbKhuVuc.SelectedValue = uscBan.MaKhuVuc;
            gunardbHoatDong.Checked = uscBan.TrangThai ? true : false;
            gunardbKhongHoatDong.Checked = uscBan.TrangThai == false ? true : false;
        }


        private void gunatxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDSBan();
        }

        private void gunabtnSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.YOU_WANNA_EDIT_BAN,Constants.NOTIFICATION,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if(string.IsNullOrEmpty(guna2txtTenBan.Text))
                {
                    MessageBox.Show(Constants.PLS_INPUT_NAME_BAN, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                if (BanBUS.Instance.KiemTraTenTonTai(guna2txtTenBan.Text))
                {
                    MessageBox.Show(Constants.NAME_BAN_EXIST, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                BanDTO ban = new BanDTO
                {
                    MaBan = Convert.ToInt32(guna2txtMaBan.Text),
                    TenBan = guna2txtTenBan.Text,
                    MaKhuVuc = Convert.ToInt32(gunacbbKhuVuc.SelectedValue),
                    TrangThai = false
                };

                if(BanBUS.Instance.SuaBan(ban))
                {
                    MessageBox.Show(Constants.EIDT_BAN_SUCCESSFUL);
                }
                else
                {
                    MessageBox.Show(Constants.EIDT_BAN_FAILED);
                }
                LoadDSBan();
            }    
        }

        private void gunabtnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.YOU_WANNA_ADD_BAN,Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(guna2txtTenBan.Text))
                {
                    MessageBox.Show(Constants.PLS_INPUT_NAME_BAN, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                if(BanBUS.Instance.KiemTraTenTonTai(guna2txtTenBan.Text))
                {
                    MessageBox.Show(Constants.NAME_BAN_EXIST, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }    

                BanDTO ban = new BanDTO
                {
                    TenBan = guna2txtTenBan.Text,
                    MaKhuVuc = Convert.ToInt32(gunacbbKhuVuc.SelectedValue),
                    TrangThai = false
                };

                if (BanBUS.Instance.ThemBan(ban))
                {
                    MessageBox.Show(Constants.ADD_BAN_SUCCESSFUL);
                }
                else
                {
                    MessageBox.Show(Constants.ADD_BAN_FAILED);
                }
                LoadDSBan();
            }
        }

        private void gunaQLKhuVuc_Click(object sender, EventArgs e)
        {
            frmKhuVuc frm =new frmKhuVuc(this);
            frm.Show();
        }

    }
}
