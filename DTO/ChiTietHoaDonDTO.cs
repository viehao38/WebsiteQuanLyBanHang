using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        private int maHD;
        private int maSP;
        private string tenSP;
        private int soLuong;
        private float donGia;
        private int giamGia;
        private float thanhTien;
        private string size;
        private bool trangThai;
        //private int tongTien;

        //public int TongTien
        //{
        //    get { return tongTien; }
        //    set { tongTien = value; }
        //}
        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        public int MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }
        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; }
        }
        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        public bool TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
    
        public int GiamGia
        {
            get { return giamGia; }
            set { giamGia = value; }
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        public float ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        public float DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
    }
}
