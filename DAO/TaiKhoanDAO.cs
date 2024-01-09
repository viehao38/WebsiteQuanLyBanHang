using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using CuaHangTraSuaHKT;
using DTO;
namespace DAO
{
    public class TaiKhoanDAO
    {
         QuanLyCuaHangTraSua_HKTEntities trasua =new  QuanLyCuaHangTraSua_HKTEntities();
        private static TaiKhoanDAO instance;
        public static TaiKhoanDAO Instance {
            get {
                if (instance == null)
                {
                    instance = new TaiKhoanDAO();
                }
                return instance; 
            } 
        }
        public List<TaiKhoanDTO> LayDSTaiKhoan()
        {
            var list=trasua.TaiKhoans.Where(p=>p.TrangThai.Value==true).ToList();
            string k = "";
            return list.Select(p=>new TaiKhoanDTO
            {
               id=p.ID,
               tentk=p.TenTK,
               matkhau =p.MatKhau,
               manv=p.MaNV.Value,
               tennv=p.NhanVien.TenNV,//
               trangthai=p.TrangThai.Value,
               maloaitk=p.MaLoaiTK.Value,
               tenloaitk= k = trasua.LoaiTKs.Find(p.MaLoaiTK).TenLoaiTK
            }).ToList();
        }
        public bool ThemTaiKhoan(TaiKhoanDTO tk)
        {
            try
            {
                TaiKhoan them = new TaiKhoan
                {
                    TenTK=tk.tentk,
                    MatKhau=tk.matkhau,
                    MaNV=tk.manv,
                    TrangThai=tk.trangthai,
                    MaLoaiTK=tk.maloaitk
                };
                trasua.TaiKhoans.Add(them);
                trasua.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            { 
                return false;
            }
        }
        public bool SuaTaiKhoan(TaiKhoanDTO tk)
        {
            try
            {
                TaiKhoan sua =trasua.TaiKhoans.SingleOrDefault(p=>p.ID==tk.id);
                {
                    sua.TenTK = tk.tentk;
                    sua.MatKhau = tk.matkhau;
                    sua.MaLoaiTK = tk.maloaitk;
                };
                if (trasua.SaveChanges() == 0) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaTaiKhoan(TaiKhoanDTO tk)
        {
            try
            {
                TaiKhoan xoa = trasua.TaiKhoans.SingleOrDefault(p => p.ID == tk.id);
                {
                    xoa.TrangThai = false;
                };       
                if (trasua.SaveChanges() == 0) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<NhanVienDTO> LayDSNhanVien()
        {
            string query = string.Format("SELECT*FROM NhanVien WHERE  TrangThai=0 AND MaNV NOT IN(SELECT MaNV FROM TaiKhoan WHERE  TrangThai=1)");
            var list = trasua.NhanViens.SqlQuery(query).ToList();
            return list.Select(v => new NhanVienDTO
            {
                MANV = v.MaNV,
                TENNV = v.TenNV,
                NGAYSINH = v.NgaySinh.Value,
                NGAYVAOLAM = (DateTime)v.NgayVaoLam,
                SODIENTHOAI = v.SoDienThoai,
                CHUCVU = v.ChucVu.Value,
                TRANGTHAI = v.TrangThai.Value,
                DIACHI = v.DiaChi,
                EMAIL = v.Email,
                GIOITINH = (bool)v.GioiTinh
            }).ToList();
        }
        public List<TaiKhoanDTO>TimIDTaiKhoan(string id)
        {
            string query = string.Format("SELECT*FROM TaiKhoan WHERE TrangThai=1 AND ID Like '%{0}%'", id);
            var list=trasua.TaiKhoans.SqlQuery(query).ToList();
            return list.Select(p => new TaiKhoanDTO
            {
                id = p.ID,
                tentk = p.TenTK,
                matkhau = p.MatKhau,
                manv = p.MaNV.Value,
                tennv = p.NhanVien.TenNV,//
                trangthai = p.TrangThai.Value,
                maloaitk = p.MaLoaiTK.Value,
                tenloaitk = p.LoaiTK.TenLoaiTK
            }).ToList();
        }
        public List<TaiKhoanDTO> TimTenTaiKhoan(string name)
        {
            string query = string.Format("SELECT*FROM TaiKhoan WHERE TrangThai=1 AND MaNV IN (SELECT MaNV FROM NhanVien WHERE TenNV Like N'%{0}%')", name);
            var list = trasua.TaiKhoans.SqlQuery(query).ToList();
            return list.Select(p => new TaiKhoanDTO
            {
                id = p.ID,
                tentk = p.TenTK,
                matkhau = p.MatKhau,
                manv = p.MaNV.Value,
                tennv = p.NhanVien.TenNV,//
                trangthai = p.TrangThai.Value,
                maloaitk = p.MaLoaiTK.Value,
                tenloaitk = p.LoaiTK.TenLoaiTK
            }).ToList();
        }
        public List<TaiKhoanDTO> TimLoaiTaiKhoan(string loai)
        {
            string query = string.Format("SELECT*FROM TaiKhoan WHERE TrangThai=1 AND MaLoaiTK IN (SELECT IDLoaiTK FROM LoaiTK WHERE TenLoaiTK Like N'%{0}%')", loai);
            var list = trasua.TaiKhoans.SqlQuery(query).ToList();
            return list.Select(p => new TaiKhoanDTO
            {
                id = p.ID,
                tentk = p.TenTK,
                matkhau = p.MatKhau,
                manv = p.MaNV.Value,
                tennv = p.NhanVien.TenNV,//
                trangthai = p.TrangThai.Value,
                maloaitk = p.MaLoaiTK.Value,
                tenloaitk = p.LoaiTK.TenLoaiTK
            }).ToList();
        }



        public List<TaiKhoanDTO> LayMaTaiKhoanNhanVienDangNhap(string tendangnhap, string matkhau, int manv)
        {
            string md5 = Utils.GetMD5(matkhau.ToString());
            var tk = trasua.TaiKhoans.Where(p => p.TenTK == tendangnhap && p.MatKhau ==md5 && p.MaNV == manv).ToList();
            return tk.Select(p => new TaiKhoanDTO
            {
                id= p.ID,
                tentk = p.TenTK,    
                matkhau= p.MatKhau,
                manv= p.MaNV.Value,
                maloaitk= p.MaLoaiTK.Value,
            }).ToList();
        }

        public int LayMaLoaiTKCuaNV(int manv)
        {
            TaiKhoan tk = trasua.TaiKhoans.SingleOrDefault(p => p.MaNV== manv);
            if (tk == null)
                return -1;
            return Convert.ToInt32(tk.MaLoaiTK);
        }

        public bool KiemTraTaiKhoanAdmin(int idloaitk)
        {
            if(idloaitk != 1) return false;
            LoaiTK loaitk = trasua.LoaiTKs.SingleOrDefault(p => p.IDLoaiTK== idloaitk && p.TenLoaiTK == "Admin");
            if (loaitk == null)
                return false;
            return true;
        }

    }
}
