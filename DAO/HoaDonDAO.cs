using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class HoaDonDAO
    {
        QuanLyCuaHangTraSua_HKTEntities db =new QuanLyCuaHangTraSua_HKTEntities();
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get
            {
                if(instance == null)
                    instance = new HoaDonDAO();
                return instance;
            }
        }
        // bên cửa hàng


        public List<HoaDonDTO> LayDSHoaDon()
        {
            var list = db.HoaDons.Where(p => p.TrangThai == true).ToList();
            string ban = "";
            string tenvn = "";
            return list.Select(p => new HoaDonDTO
            {
                MaHD= p.MaHD,
                MaBan= (int)p.MaBan,
                MaNV = p.MaNV,
                TongTien = (float)p.TongTien,
                ngayLapLapHD = (DateTime)p.NgayLapHD,
                TrangThai = (bool)p.TrangThai,
                GhiChu = p.GhiChu,
                TenBan = ban = db.Bans.Find(p.MaBan).TenBan,
                TenNV = tenvn = db.NhanViens.Find(p.MaNV).TenNV

            }).ToList();
        }

        public HoaDonDTO LayDSHoaDonTheoBan(int maban, int mahd)//thanh toan
        {
            HoaDon hd = db.HoaDons.SingleOrDefault(p => p.TrangThai == true && p.MaBan == maban && p.MaHD == mahd);
            var tenb = "";
            HoaDonDTO hdn = new HoaDonDTO
            {
                MaBan = hd.MaHD,
                TenBan = tenb = db.Bans.Find(maban).TenBan,
                MaNV = hd.MaNV,
                MaHD= hd.MaHD,
                ngayLapLapHD= (DateTime)hd.NgayLapHD,
                TongTien= (float)hd.TongTien,
                TrangThai= (bool)hd.TrangThai
            };
            return hdn;
        }

        public int LayMaHoaDonCuaBan(int maban)
        {
            try
            {
                HoaDon hd = db.HoaDons.SingleOrDefault(p => p.MaBan == maban && p.TrangThai == true);
                if (hd == null)
                {
                    return -1;
                }
                return hd.MaHD;
            }
            catch(Exception e)
            {
                return -1;
            }
        }
        public int LayHoaDonMax()
        {
            try
            {
                var hd = db.HoaDons.Max(p => p.MaHD);
                if (hd == 0)
                {
                    return -1;
                }
                return hd;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public double LayTongTienCuaHoaDon(int mahd)
        {
            try
            {
                HoaDon hd = db.HoaDons.SingleOrDefault(p => p.MaHD == mahd);
                if(hd == null)
                {
                    return -1;
                }    
                return (double)hd.TongTien;
            }
            catch(Exception e)
            {
                return -1;
            }
        }

        public bool capNhatTongTien(int mahd, float thanhtienCTHD = 0)
        {
            try
            {
                HoaDon hd = db.HoaDons.SingleOrDefault(p => p.MaHD == mahd);

                if (hd == null)
                    return false;

                var tongtien = db.ChiTietHoaDons.Where(p => p.MaHD == mahd && p.TrangThai == true).Sum(p => p.ThanhTien);

                hd.TongTien = tongtien;

                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool ThemHoaDon(HoaDonDTO newhd)
        {
            try
            {
                HoaDon hd = new HoaDon
                {
                    NgayLapHD = (DateTime)newhd.ngayLapLapHD,
                    MaNV = newhd.MaNV,
                    TongTien = newhd.TongTien,
                    TrangThai = newhd.TrangThai,
                    GhiChu = newhd.GhiChu,
                    MaBan = newhd.MaBan,
                };
                db.HoaDons.Add(hd);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatHoaDonDaThanhToan(int mahd, bool check)
        {
            try
            {
                HoaDon hd = db.HoaDons.SingleOrDefault(p => p.MaHD == mahd);
                if (hd == null) return false;
                hd.TrangThai = check;
                db.SaveChanges();
                return true;
               
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool SuaHoaDonKhiChuyenban(int mahd, int maban)
        {
            try
            {
                HoaDon hd = db.HoaDons.SingleOrDefault(p => p.MaHD == mahd);
                if (hd == null) return false;
                hd.MaBan = maban;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex )
            {
                return false;
            }
        }

        public bool XoaHoaDonKhiChuyenban(int mahd)
        {
            try
            {
                HoaDon hd = db.HoaDons.SingleOrDefault(p => p.MaHD == mahd);
                if (hd == null) return false;
                hd.TrangThai = false;
                db.HoaDons.Remove(hd);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
     
        }

     

        public float ThongKeDoanhThu(DateTime tungay, DateTime denngay)
        {
            string sql = string.Format("SELECT * FROM HoaDon WHERE NgayLapHD BETWEEN '{0}' AND '{1}' ", tungay, denngay);
            var hd = db.HoaDons.SqlQuery(sql).ToList();
            float tong = 0;
            foreach( var h in hd )
            {
                tong = tong + (float)h.TongTien;
            }
            if(hd == null) return 0;

            return tong;
        }

        public List<HoaDonDTO> DSHoaDonTheoDoanhThuTuNgayDenNgay(DateTime tungay, DateTime denngay)
        {
            string sql = string.Format("SELECT * FROM HoaDon WHERE NgayLapHD BETWEEN '{0}' AND '{1}' and TrangThai = 0 ", tungay, denngay);
            var list = db.HoaDons.SqlQuery(sql ).ToList();
            string ban = "";
            string tenvn = "";
            return list.Select(p => new HoaDonDTO
            {
                MaHD = p.MaHD,
                MaNV = p.MaNV,
                ngayLapLapHD = (DateTime)p.NgayLapHD,
                TongTien = (float)p.TongTien,
                MaBan = (int)p.MaBan,
                TrangThai = (bool)p.TrangThai,
                TenBan = ban = db.Bans.Find(p.MaBan).TenBan,
                TenNV = tenvn = db.NhanViens.Find(p.MaNV).TenNV
            }).ToList();
        }

        public List<HoaDonDTO> DSHoaDonTheoDoanhThuTheoThang(int thang, int nam)
        {
            string sql = string.Format("SELECT * FROM HoaDon WHERE MONTH(NgayLapHD) = {0} and YEAR(NgayLapHD) = {1} and TrangThai = 0 ", thang, nam);
            var list = db.HoaDons.SqlQuery(sql).ToList();
            string ban = "";
            string tenvn = "";
            return list.Select(p => new HoaDonDTO
            {
                MaHD = p.MaHD,
                MaNV = p.MaNV,
                ngayLapLapHD = (DateTime)p.NgayLapHD,
                TongTien = (float)p.TongTien,
                MaBan = (int)p.MaBan,
                TrangThai = (bool)p.TrangThai,
                TenBan = ban = db.Bans.Find(p.MaBan).TenBan,
                TenNV = tenvn = db.NhanViens.Find(p.MaNV).TenNV
            }).ToList();
        }

        public float ThongKeDoanhThuTheoThang(int thang, int nam)
        {
            string sql = string.Format("SELECT * FROM HoaDon WHERE MONTH(NgayLapHD) = {0} and YEAR(NgayLapHD) = {1} ", thang, nam);
            var hd = db.HoaDons.SqlQuery(sql).ToList();
            float tong = 0;
            foreach (var h in hd)
            {
                tong = tong + (float)h.TongTien;
            }
            if (hd == null) return 0;

            return tong;
        }


        //public List<hoadonDTO> loadds()
        //{
        //    var list = db.HoaDons.Where(p => p.TrangThai.Value == false).ToList();
        //    return list.Select(p => new hoadonDTO
        //    {
        //        mahd = p.MaHD,
        //        ngaylaphd = p.NgayLapHD.Value,
        //        maban = p.Ban.MaBan,
        //        manv = p.NhanVien.MaNV,
        //        tongtien = (float)p.TongTien,
        //        tranthai = p.TrangThai.Value,
        //        ghichu = p.GhiChu,

        //    }).ToList();
        //}

        public bool themhoadon(HoaDonDTO addhd)
        {
            try
            {
                HoaDon hd = new HoaDon()
                {
                    NgayLapHD = (DateTime)addhd.ngayLapLapHD,
                    MaNV = addhd.MaNV,
                    TongTien = Convert.ToInt32(addhd.TongTien),
                    TrangThai = addhd.TrangThai,
                    GhiChu = addhd.GhiChu,
                    MaBan = addhd.MaBan,
                };
                db.HoaDons.Add(hd);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suahoadon(HoaDonDTO edithd)
        {
            try
            {
                HoaDon hd = db.HoaDons.SingleOrDefault(p => p.MaHD == edithd.MaHD);
                hd.MaNV = edithd.MaNV;
                hd.TongTien =edithd.TongTien;
                hd.GhiChu = edithd.GhiChu;
                hd.MaBan= edithd.MaBan;
                hd.NgayLapHD = edithd.ngayLapLapHD;

                if (db.SaveChanges() == 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<HoaDonDTO> timmahoadon(int mahd)
        {
            //string query = string.Format("SELECT*FROM HoaDon WHERE TrangThai=1 AND MaHD = {0}'", mahd);
            //var list = db.HoaDons.SqlQuery(query).ToList();
            var list = db.HoaDons.Where(p => p.MaHD == mahd && p.TrangThai == true).ToList();
            return list.Select(p => new HoaDonDTO
            {
                MaHD = p.MaHD,
                ngayLapLapHD = p.NgayLapHD.Value,
                MaBan = p.Ban.MaBan,
                MaNV = p.NhanVien.MaNV,
                TongTien = (float)p.TongTien,
                GhiChu = p.GhiChu,
            }).ToList();
        }
      /*  public List<HoaDonDTO> timtheotennv(string ten)
        {
            string query=string.Format("SELECT*FROM HoaDon WHERE TrangThai=0 AND MaHD IN (SELECT MaHD FROM HoaDon WHERE MaNV Like N'%{0}%')", ten);
            var list=db.HoaDons.SqlQuery(query).ToList();
            var ban = "";
            var tenvn = "";
            return list.Select(p => new HoaDonDTO
            {
                MaHD = p.MaHD,
                MaBan = (int)p.MaBan,
                MaNV = p.MaNV,
                TongTien = (float)p.TongTien,
                ngayLapLapHD = (DateTime)p.NgayLapHD,
                TrangThai = (bool)p.TrangThai,
                GhiChu = p.GhiChu,
                TenBan = ban = db.Bans.Find(p.MaBan).TenBan,
                TenNV = tenvn = db.NhanViens.Find(p.MaNV).TenNV
            }).ToList();
        }*/

    }
}
