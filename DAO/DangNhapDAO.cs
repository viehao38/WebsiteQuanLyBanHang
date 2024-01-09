using CuaHangTraSuaHKT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class DangNhapDAO
    {
        QuanLyCuaHangTraSua_HKTEntities db = new QuanLyCuaHangTraSua_HKTEntities();
        private static DangNhapDAO instance;
        public static DangNhapDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new DangNhapDAO();
                return instance;
            }
        }

        public bool KiemTraDangNhap(string tentk, string matkhau)
        {
            string md5 = Utils.GetMD5(matkhau.ToString());
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(p => p.TenTK == tentk && p.MatKhau == md5 && p.TrangThai == true);
            if(tk == null)
            {
                return false;
            }
            return true;
        }

        public int LayMaNhanVien(string tentk, string matkhau)
        {
            string md5 = Utils.GetMD5(matkhau.ToString());
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(p => p.TenTK == tentk && p.MatKhau == md5);
            if (tk == null)
            {
                return -1;
            }
            int manv = Convert.ToInt32(tk.MaNV);
            return manv;
        }

        public string LayTenNhanVien(int manv)
        {
            NhanVien nv = db.NhanViens.SingleOrDefault(p => p.MaNV == manv);
            if (nv == null)
            {
                return null;
            }
            return nv.TenNV;
        }

    }
}
