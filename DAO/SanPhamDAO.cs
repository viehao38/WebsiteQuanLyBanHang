using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DTO;
using static System.Net.Mime.MediaTypeNames;

namespace DAO
{
    public class SanPhamDAO
    {
        QuanLyCuaHangTraSua_HKTEntities db = new QuanLyCuaHangTraSua_HKTEntities();
        private static SanPhamDAO instance;
        public static SanPhamDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanPhamDAO();
                }
                return instance;
            }
        }

        public string layTenTheoMaSP(int masp)
        {
            try
            {
                SanPham sp = db.SanPhams.SingleOrDefault(p => p.MaSP == masp);
                if (sp == null)
                {
                    return null;
                }
                return sp.TenSP;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int LayMaSPTheoTen(string txt)
        {
            try
            {
                SanPham sp = db.SanPhams.SingleOrDefault(p => p.TenSP == txt);
                if(sp == null)
                {
                    return -1;
                }
                return sp.MaSP;

            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public List<SanPhamDTO> LayDSSanPham()
        {

            var list = db.SanPhams.Where(v => v.TrangThai.Value == true).ToList();
            string k = "";
            return list.Select(v => new SanPhamDTO
            {
                masp = v.MaSP,
                madanhmuc = v.MaDanhMuc.Value,
                tendanhmuc = k = db.DanhMucs.Find(v.MaDanhMuc).TenDanhMuc,//lay ten danh muc tim theo ma
                tensanpham = v.TenSP,
                anhsp = v.AnhSP,
                mota = v.MoTa,
                donvitinh = v.DonViTinh,
                donGiaL = (float)v.DonGiaL,
                donGiaM = (float)v.DonGiaM,
                trangthai = v.TrangThai.Value

            }).ToList();
        }

        public List<SanPhamDTO> LayDSSanPhamTheoLoai(int maloaisp)
        {

            var list = db.SanPhams.Where(v => v.TrangThai.Value == true && v.MaDanhMuc == maloaisp).ToList();
            string k = "";
            return list.Select(v => new SanPhamDTO
            {
                masp = v.MaSP,
                madanhmuc = v.MaDanhMuc.Value,
                tendanhmuc = k = db.DanhMucs.Find(v.MaDanhMuc).TenDanhMuc,
                tensanpham = v.TenSP,
                anhsp = v.AnhSP,
                mota = v.MoTa,
                donvitinh = v.DonViTinh,
                donGiaL = (float)v.DonGiaL,
                donGiaM = (float)v.DonGiaM,
                trangthai = v.TrangThai.Value

            }).ToList();
        }

        public bool ThemSanPham(SanPhamDTO newsp)
        {
            try
            {
                SanPham sp = new SanPham
                {
                    MaDanhMuc = newsp.madanhmuc,
                    TenSP = newsp.tensanpham,
                    //HinhAnh = newsp.hinhanh,//
                    AnhSP = newsp.anhsp,
                    //MoTa=newsp.mota,
                    DonViTinh = newsp.donvitinh,
                    DonGiaL = (float)newsp.donGiaL,
                    DonGiaM = (float)newsp.donGiaM,
                    //Size = newsp.size,
                    TrangThai = newsp.trangthai
                };
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SuaSanPham(SanPhamDTO newsp)
        {
            try
            {
                SanPham sua = db.SanPhams.SingleOrDefault(p => p.MaSP == newsp.masp);
                sua.MaDanhMuc = newsp.madanhmuc;
                sua.TenSP = newsp.tensanpham;
                //sua.HinhAnh = newsp.hinhanh;//
                sua.AnhSP = newsp.anhsp;
                sua.DonViTinh = newsp.donvitinh;
                sua.DonGiaL = newsp.donGiaL;
                sua.DonGiaM = newsp.donGiaM;
                //sua.Size = newsp.size;

                if (db.SaveChanges() == 0) return false;
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SuaSanPhamCoImage(SanPhamDTO newsp)
        {
            try
            {
                SanPham sua = db.SanPhams.SingleOrDefault(p => p.MaSP == newsp.masp);
                sua.MaDanhMuc = newsp.madanhmuc;
                sua.TenSP = newsp.tensanpham;
                sua.DonViTinh = newsp.donvitinh;
                sua.DonGiaL = newsp.donGiaL;
                sua.DonGiaM = newsp.donGiaM;
                if(sua == null) return false;
                db.SaveChanges();
               
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaSanPham(SanPhamDTO newsp)
        {
            try
            {
                SanPham xoa = db.SanPhams.SingleOrDefault(p => p.MaSP == newsp.masp);
                xoa.TrangThai = false;
                if (db.SaveChanges() == 0) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<SanPhamDTO> TimMaSanPham(string masp)
        {
            string query = string.Format("SELECT * FROM SanPham WHERE TrangThai=1 AND  MaSP LIKE N'%{0}%'", masp);
            var list = db.SanPhams.SqlQuery(query).ToList();

            return list.Select(v => new SanPhamDTO
            {
                masp = v.MaSP,
                madanhmuc = v.MaDanhMuc.Value,
                tendanhmuc = v.DanhMuc.TenDanhMuc,
                tensanpham = v.TenSP,
                //hinhanh = v.HinhAnh,//
                anhsp = v.AnhSP,
                mota = v.MoTa,
                donvitinh = v.DonViTinh,
                donGiaL = (float)v.DonGiaL,
                donGiaM = (float)v.DonGiaM,
                //size = v.Size,
                trangthai = v.TrangThai.Value

            }).ToList();
        }
        public List<SanPhamDTO> TimDanhMucSanPham(string danhmuc)
        {
            string query = string.Format("SELECT * FROM SanPham WHERE TrangThai=1 AND MaDanhMuc IN\r\n(SELECT MaDanhMuc FROM DanhMuc WHERE TrangThai=1 AND TenDanhMuc LIKE N'%{0}%')", danhmuc);
            var list = db.SanPhams.SqlQuery(query).ToList();
            return list.Select(v => new SanPhamDTO
            {
                masp = v.MaSP,
                madanhmuc = v.MaDanhMuc.Value,
                tendanhmuc = v.DanhMuc.TenDanhMuc,
                tensanpham = v.TenSP,
                //hinhanh = v.HinhAnh,//
                anhsp = v.AnhSP,
                mota = v.MoTa,
                donvitinh = v.DonViTinh,
                donGiaL = (float)v.DonGiaL,
                donGiaM = (float)v.DonGiaM,
                //size = v.Size,
                trangthai = v.TrangThai.Value

            }).ToList();
        }
        public List<SanPhamDTO> TimTenSanPham(string tensp)
        {
            string query = string.Format("SELECT * FROM SanPham WHERE TrangThai=1 AND TenSP LIKE N'%{0}%'", tensp);
            var list = db.SanPhams.SqlQuery(query).ToList();
            return list.Select(v => new SanPhamDTO
            {
                masp = v.MaSP,
                madanhmuc = v.MaDanhMuc.Value,
                tendanhmuc = v.DanhMuc.TenDanhMuc,
                tensanpham = v.TenSP,
                //hinhanh = v.HinhAnh,//
                anhsp = v.AnhSP,

                mota = v.MoTa,
                donvitinh = v.DonViTinh,
                donGiaL = (float)v.DonGiaL,
                donGiaM = (float)v.DonGiaM,
                //size = v.Size,
                trangthai = v.TrangThai.Value

            }).ToList();
        }
        public List<SanPhamDTO> TimDonViTinhSanPham(string donvitinh)
        {
            string query = string.Format("SELECT * FROM SanPham WHERE TrangThai=1 AND DonViTinh LIKE N'%{0}%'", donvitinh);
            var list = db.SanPhams.SqlQuery(query).ToList();
            return list.Select(v => new SanPhamDTO
            {
                masp = v.MaSP,
                madanhmuc = v.MaDanhMuc.Value,
                tendanhmuc = v.DanhMuc.TenDanhMuc,
                tensanpham = v.TenSP,
                ////hinhanh = v.HinhAnh,//
                anhsp = v.AnhSP,

                mota = v.MoTa,
                donvitinh = v.DonViTinh,
                donGiaL = (float)v.DonGiaL,
                donGiaM = (float)v.DonGiaM,
                //size = v.Size,
                trangthai = v.TrangThai.Value

            }).ToList();
        }


        public bool KiemTraTonTaiDataview(string tensp)
        {
            var kt = db.SanPhams.Where(p => p.TenSP.Contains(tensp) && p.TrangThai == true).ToList();
            //Contains thay thế cho %
            if (kt.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte[] ConvertImage(string pathimage)
        {
            FileStream fs;
            using (MemoryStream memory = new MemoryStream())
            {
                using (fs = new FileStream(pathimage, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fs.Length];

                    fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
                    fs.Close();
                    return bytes;
                }
            }
        }
    }
}
