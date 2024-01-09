using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangTraSuaHKT
{
    public partial class uscThongTinMon : UserControl
    {
        public uscThongTinMon()
        {
            InitializeComponent();
        }

        private void uscMon_Load(object sender, EventArgs e)
        {

        }

        private int maSP;
        private string tenSP;
        private int maDanhMuc;
        private Image anhsp;
        private string moTa;
        private string donViTinh;
        private string donGiaL;
        private string donGiaM;
        private string siZe;
        private bool trangThai;

        public Image Anhsp
        {
            get { return anhsp; }
            set { anhsp = value; gunaptbAnhMonAn.Image = value; }
        }


        public int MaSP
        {
            get { return maSP; }
            set { maSP = value;}
        }

        public int MaDanhMuc
        {
            get { return maDanhMuc; }
            set { maDanhMuc = value; }
        }

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; lblTenMon.Text = value; }
        }

        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        public string DonViTinh
        {
            get { return donViTinh;}
            set { donViTinh = value;}
        }

        public string DonGiaL
        {
            get { return donGiaL; }  
            set { donGiaL = value; lblDonGia.Text = value;}
        }

        public string DonGiaM
        {
            get { return donGiaM; }
            set { donGiaM = value; lblDonGia.Text = value; }
        }

        public string SiZe
        {
            get { return siZe; }
            set { siZe = value; }
        }

        public bool TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

   
        private void uscThongTinMon_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.PaleTurquoise;

        }

        private void uscThongTinMon_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.GhostWhite;
        }

   
    }
}
