using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        private int maHD;
        private DateTime ngayLapHD;
        private int maNV;
        private float tongTien;
        private bool trangThai;
        private string ghiChu;
        private int maBan;
        private string tenBan;
        private string tenNV;

        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        public DateTime ngayLapLapHD
        { 
            get { return ngayLapHD;} 
            set { ngayLapHD = value; } 
        }
        public int MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        public float TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
              
        }
        public bool TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }

        public int MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }

        public string TenBan
        {
            get { return tenBan; }
            set { tenBan = value; }
        }

        public string TenNV
        {
            get { return tenNV; }
            set { tenNV = value; }
        }

    }
}
