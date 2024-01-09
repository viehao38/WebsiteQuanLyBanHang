using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BanDTO
    {

        private int maBan;
        private string tenBan;
        private int maKhuVuc;
        private bool trangThai;

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

        public int MaKhuVuc
        {
            get { return maKhuVuc; }
            set { maKhuVuc = value; }
        }

        public bool TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
        
        public BanDTO() { }
        public BanDTO(int maban, string tenban, int makhuvuc, bool trangthai)
        {
            this.maBan = maban;
            this.tenBan = tenban;
            this.maKhuVuc = makhuvuc;
            this.trangThai = trangthai;
        }

        //public BanDTO(DataRow dr)
        //{
        //    this.maBan = (int)dr["Maban"];
        //    this.tenBan = dr["TenBan"].ToString();
        //    this.maKhuVuc = (int)dr["MaKhuVuc"];
        //    this.trangThai = (bool)dr["TrangThai"];
        //}
    }
}
