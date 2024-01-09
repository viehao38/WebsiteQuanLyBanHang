using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace Dao
{
    public class NhanVienDAO
    {
        public static NhanVienDAO instance;
        QuanLyCuaHangTraSua_HKTEntities db = new QuanLyCuaHangTraSua_HKTEntities();
        public static NhanVienDAO Instance
        { get
            {
                if (instance == null)
                    instance = new NhanVienDAO();
                return instance;
            } 
        }

  

        public List<NhanVienDTO>loadnhanvien()
        { 
            var listnv=db.NhanViens.Where(p => p.TrangThai == false).ToList();
            var k = "";
            return listnv.Select(n => new NhanVienDTO
            {
                MANV=n.MaNV,
                TENNV=n.TenNV,
                NGAYSINH = (DateTime)n.NgaySinh.Value,
                NGAYVAOLAM = (DateTime)n.NgayVaoLam.Value,
                EMAIL =n.Email,
                DIACHI=n.DiaChi,
                GIOITINH=n.GioiTinh==null? false :n.GioiTinh.Value,
                SODIENTHOAI=n.SoDienThoai,
                CHUCVU =Convert.ToInt32( n.ChucVu.Value),
                tenchuvu = k = db.ChucVus.Find(n.ChucVu1.MaChucVu).TenChucVu,
                textgioitinh =n.GioiTinh.Value?"Nam":"Nữ",
                TRANGTHAI=n.TrangThai.Value,
            }).ToList();
        }
        public bool xoanhanvien(NhanVienDTO cleanv)
        {
            try
            {
                NhanVien clearnv = db.NhanViens.SingleOrDefault(p => p.MaNV == cleanv.MANV);
                if(clearnv == null)
                {
                    return false;
                }
                clearnv.TrangThai = true;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
        public bool themnv(NhanVienDTO addnv)
        {
            try
            {
                NhanVien nv = new NhanVien
                {
                    TenNV=addnv.TENNV,
                    DiaChi=addnv.DIACHI,
                    Email=addnv.EMAIL,
                    NgaySinh=addnv.NGAYSINH,
                    NgayVaoLam=addnv.NGAYVAOLAM,
                    SoDienThoai=addnv.SODIENTHOAI,
                    GioiTinh = addnv.GIOITINH,
                    ChucVu = addnv.CHUCVU,
                    TrangThai =addnv.TRANGTHAI,
                };
                db.NhanViens.Add(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool suanhanvien(NhanVienDTO editnv)
        {
            try
            {
                NhanVien nv=db.NhanViens.SingleOrDefault(p=>p.MaNV==editnv.MANV);
                nv.MaNV=editnv.MANV;
                nv.TenNV=editnv.TENNV;
                nv.NgaySinh = editnv.NGAYSINH;
                nv.NgayVaoLam=editnv.NGAYVAOLAM;
                nv.DiaChi=editnv.DIACHI;
                nv.Email=editnv.EMAIL;
                nv.GioiTinh=editnv.GIOITINH;
                nv.SoDienThoai=editnv.SODIENTHOAI;
                nv.ChucVu=editnv.CHUCVU;
                //if (db.SaveChanges() == 0)
                //    return false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public List<NhanVienDTO> timtennhanvien(string id)
        {
            string query = string.Format("SELECT*FROM NhanVien WHERE TrangThai=0 AND MaNV IN (SELECT MaNV FROM NhanVien WHERE TenNV Like N'%{0}%')", id);
            var list=db.NhanViens.SqlQuery(query).ToList();
            return list.Select(p=>new NhanVienDTO
            {
                MANV=p.MaNV,
                TENNV=p.TenNV,
                EMAIL=p.Email,
                DIACHI=p.DiaChi,
                SODIENTHOAI=p.SoDienThoai,
                NGAYSINH=p.NgaySinh.Value,
                NGAYVAOLAM=p.NgayVaoLam.Value,
                GIOITINH=p.GioiTinh==null? false : p.GioiTinh.Value,
                CHUCVU=p.ChucVu.Value,
                textgioitinh =p.GioiTinh.Value? "Nam":"Nữ",
                TRANGTHAI=p.TrangThai.Value,
            }).ToList();
        }

        public List<NhanVienDTO> TimNhanVienTheoMaNhanVien(int id)
        {
            var list = db.NhanViens.Where(p => p.MaNV == id).ToList();
            return list.Select(p => new NhanVienDTO
            {
                MANV = p.MaNV,
                TENNV = p.TenNV,
                EMAIL = p.Email,
                DIACHI = p.DiaChi,
                SODIENTHOAI = p.SoDienThoai,
                NGAYSINH = p.NgaySinh.Value,
                NGAYVAOLAM = p.NgayVaoLam.Value,
                GIOITINH = p.GioiTinh == null ? false : p.GioiTinh.Value,
                CHUCVU = p.ChucVu.Value,
                textgioitinh = p.GioiTinh.Value ? "Nam" : "Nữ",
                TRANGTHAI = p.TrangThai.Value,
            }).ToList();
        }

        public List<NhanVienDTO> DSNhanVienTheoChucVu(int machucvu)
        {
            var listnv = db.NhanViens.Where(p => p.TrangThai == false && p.ChucVu == machucvu).ToList();
            var k = "";
            return listnv.Select(n => new NhanVienDTO
            {
                MANV = n.MaNV,
                TENNV = n.TenNV,
                NGAYSINH= n.NgaySinh.Value,
                NGAYVAOLAM = n.NgayVaoLam.Value,
                EMAIL = n.Email,
                DIACHI = n.DiaChi,
                GIOITINH = n.GioiTinh == null ? false : n.GioiTinh.Value,
                SODIENTHOAI = n.SoDienThoai,
                CHUCVU = Convert.ToInt32(n.ChucVu.Value),
                tenchuvu = k = db.ChucVus.Find(n.ChucVu1.MaChucVu).TenChucVu,
                textgioitinh = n.GioiTinh.Value ? "Nam" : "Nữ",
                TRANGTHAI = n.TrangThai.Value,
            }).ToList();
        }

        public bool kTraDinhDangEmail(string email = null)
        {
            int indexEmail = email.LastIndexOf("@");
            if (indexEmail == -1)
            {
                return true;
            }
            if (email.Substring(indexEmail) != "@gmail.com")
                return true;
            else
                return false;
        }

        public bool kTraNgaySinh(DateTime ngaysinh)
        {
            if ((DateTime)ngaysinh > DateTime.Now) return true;
            return false;

        }

    }
} 
