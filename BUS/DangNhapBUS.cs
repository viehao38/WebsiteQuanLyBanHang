using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DangNhapBUS
    {
        private static DangNhapBUS instance;
        public static DangNhapBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new DangNhapBUS();
                return instance;
            }
        }
        public bool KiemTraDangNhap(string tentk, string matkhau)
        {
           return DangNhapDAO.Instance.KiemTraDangNhap(tentk,matkhau);
        }

        public int LayMaNhanVien(string tentk, string matkhau)
        {
            return DangNhapDAO.Instance.LayMaNhanVien(tentk, matkhau);
        }

        public string LayTenNhanVien(int manv)
        {
            return DangNhapDAO.Instance.LayTenNhanVien(manv);
        }

    }
}
