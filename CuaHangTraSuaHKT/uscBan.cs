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
    public partial class uscBan : UserControl
    {
        private bool checkBorder = false;
        public uscBan()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }


        string tenBan;
        int maBan;
        int maKhuVuc;
        bool trangThai;

        public string TenBan
        {
            get { return tenBan; }
            set { tenBan = value; lblTenBan.Text = value; lblTenBan.Text = value;}
        }

        public int MaKhuVuc
        {
            get { return maKhuVuc;}
            set { maKhuVuc = value;}
        }

        public int MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }

        public bool TrangThai
        {
            get { return trangThai; }
            set{trangThai = value;}
        }

        private void uscBan_MouseEnter(object sender, EventArgs e)
        {
            checkBorder = true;
            this.Invalidate();
        }

        private void uscBan_MouseLeave(object sender, EventArgs e)
        {
    
            checkBorder = false;
            this.Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (checkBorder)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
            }
        }

        private void lblTenBan_Click(object sender, EventArgs e)
        {
        }
    }
}
