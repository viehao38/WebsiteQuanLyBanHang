using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

using System.Xml.Linq;

namespace BUS
{
    public class TaiKhoanBUS
    {
        private static TaiKhoanBUS instance;
        public static TaiKhoanBUS Instance
        {
            get { 
                if(instance== null)
                    instance = new TaiKhoanBUS();
                 return instance; 
            }
        }
        public List<TaiKhoanDTO> LayDSTaiKhoan()
        {
            return TaiKhoanDAO.Instance.LayDSTaiKhoan();
        }
        public List<NhanVienDTO> LayDSNhanVien()
        {
            return TaiKhoanDAO.Instance.LayDSNhanVien();
        }
        public bool ThemTaiKhoan(TaiKhoanDTO tk)
        {
            return TaiKhoanDAO.Instance.ThemTaiKhoan(tk);
        }
        public bool SuaTaiKhoan(TaiKhoanDTO tk)
        {
            return TaiKhoanDAO.Instance.SuaTaiKhoan(tk);
        }
        public bool XoaTaiKhoan(TaiKhoanDTO tk)
        {
            return TaiKhoanDAO.Instance.XoaTaiKhoan(tk);
        }
        public List<TaiKhoanDTO>TimIDTaiKhoan(string id)
        {
            return TaiKhoanDAO.Instance.TimIDTaiKhoan(id);
        }
        public List<TaiKhoanDTO> TimTenTaiKhoan(string name)
        {
            return TaiKhoanDAO.Instance.TimTenTaiKhoan(name);
        }
        public List<TaiKhoanDTO> TimLoaiTaiKhoan(string loai)
        {
            return TaiKhoanDAO.Instance.TimLoaiTaiKhoan(loai);
        }
        public class UserBUS
        {
            public static bool IsVaidPassword(string password)
            {
                if(password.Length<8||password.Length>=20)
                {
                    return false;
                }
                bool hasUp=false;
                foreach(char c in password)
                {
                    if(char.IsUpper(c))
                    {
                        hasUp = true;
                        break;
                    }
                }
                return hasUp;
            }
        }

        public List<TaiKhoanDTO> LayMaTaiKhoanNhanVienDangNhap(string tendangnhap, string matkhau, int manv)
        {
           return TaiKhoanDAO.Instance.LayMaTaiKhoanNhanVienDangNhap(tendangnhap,matkhau, manv);
        }

        public int LayMaLoaiTKCuaNV(int manv)
        {
            return TaiKhoanDAO.Instance.LayMaLoaiTKCuaNV(manv);
        }

        public bool KiemTraTaiKhoanAdmin(int idloaitk)
        {
            return TaiKhoanDAO.Instance.KiemTraTaiKhoanAdmin(idloaitk);
        }
    }
}
