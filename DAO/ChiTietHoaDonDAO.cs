using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ChiTietHoaDonDAO
    {
        
        QuanLyCuaHangTraSua_HKTEntities db = new QuanLyCuaHangTraSua_HKTEntities();
        private static ChiTietHoaDonDAO instance;
        public static ChiTietHoaDonDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietHoaDonDAO();
                return instance;
            }
        }

        // bên cửa hàng

        public List<ChiTietHoaDonDTO> LayDSCTHDTheoMaHD(int mahd, bool check = true)
        {
            var list = db.ChiTietHoaDons.Where(p => p.MaHD == mahd && p.TrangThai == check).ToList();
            var k = "";
            return list.Select(v => new ChiTietHoaDonDTO
            {
                MaHD = v.MaHD,
                MaSP = v.MaSP,
                SoLuong = (int)v.SoLuong,
                DonGia = (float)v.DonGia,
                ThanhTien = (float)v.ThanhTien,
                GiamGia = (int)v.GiamGia,
                Size = v.Size,//
                TenSP = k = db.SanPhams.Find(v.MaSP).TenSP,
                TrangThai = (bool)v.TrangThai
            }).ToList();
        }

        public bool ThemCTHD(ChiTietHoaDonDTO cthdnew)
        {
            try
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon
                {
                    MaHD = cthdnew.MaHD,
                    MaSP = cthdnew.MaSP,
                    SoLuong = cthdnew.SoLuong,
                    ThanhTien = cthdnew.ThanhTien,
                    DonGia = cthdnew.DonGia,
                    Size = cthdnew.Size,
                    TrangThai = cthdnew.TrangThai,
                    GiamGia = cthdnew.GiamGia,
                };
               
                db.ChiTietHoaDons.Add(cthd);
                db.SaveChanges();

                //HoaDonDAO.Instance.capNhatTongTien(cthd.MaHD);
                //db.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool XoaCTHD(int mahd, int masp, string size)
        {
            ChiTietHoaDon cthd = db.ChiTietHoaDons.SingleOrDefault(p => p.MaHD == mahd && p.MaSP == masp && p.Size == size);  
            if(cthd == null) return false;
            cthd.TrangThai = false;
            db.ChiTietHoaDons.Remove(cthd);
            db.SaveChanges();
            return true;
        }

        public bool checkCTHDGiong(ChiTietHoaDonDTO cthd)
        {
            try
            {
                ChiTietHoaDon checkcthd = db.ChiTietHoaDons.SingleOrDefault(p => p.MaHD == cthd.MaHD && p.MaSP == cthd.MaSP && p.Size == cthd.Size);
                if(checkcthd == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SuaCTHD(ChiTietHoaDonDTO cthd)
        {
            try
            {
                ChiTietHoaDon suaCTHD = db.ChiTietHoaDons.SingleOrDefault(p => p.MaHD == cthd.MaHD && p.MaSP == cthd.MaSP && p.Size == cthd.Size);
                if(suaCTHD ==null) return false;
                int soluong = Convert.ToInt32(suaCTHD.SoLuong + cthd.SoLuong);
                suaCTHD.SoLuong = soluong;
                float thanhtien = (float)suaCTHD.ThanhTien + cthd.ThanhTien;
               
                suaCTHD.ThanhTien = thanhtien;

                suaCTHD.MaSP = cthd.MaSP;
                suaCTHD.MaHD= cthd.MaHD;
                suaCTHD.Size = cthd.Size;
                suaCTHD.DonGia = cthd.DonGia;
                suaCTHD.GiamGia = cthd.GiamGia;
                suaCTHD.TrangThai = cthd.TrangThai;

                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool SuaCTHDKhiDaThem(ChiTietHoaDonDTO cthd)
        {
            try
            {
                ChiTietHoaDon suaCTHD = db.ChiTietHoaDons.SingleOrDefault(p => p.MaHD == cthd.MaHD && p.MaSP == cthd.MaSP && p.Size == cthd.Size);
                if (suaCTHD == null) return false;
               
                suaCTHD.SoLuong = cthd.SoLuong;
                suaCTHD.ThanhTien = cthd.ThanhTien;
                suaCTHD.MaSP = cthd.MaSP;
                suaCTHD.MaHD = cthd.MaHD;
                suaCTHD.Size = cthd.Size;
                suaCTHD.DonGia = cthd.DonGia;
                suaCTHD.GiamGia = cthd.GiamGia;
                suaCTHD.TrangThai = cthd.TrangThai;

                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool XoaALLCTHD(int mahd, bool check)
        {
            try
            {
                var hd = db.HoaDons.Find(mahd);//Tim hd

                var cthd = hd.ChiTietHoaDons.ToList();//theo hóa đơn

                foreach (var item in cthd)
                {
                    item.TrangThai = check;
                }

                db.SaveChanges(); return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool KTSuaALLCTHDCuaBanChuyen(int mahdHienTai, int mahdChuyenBan)
        {
            try
            {
                string query = string.Format("UPDATE ChiTietHoaDon SET MaHD = {0} WHERE MaHD = {1}",mahdChuyenBan,mahdHienTai);
                db.ChiTietHoaDons.SqlQuery(query).ToList();
               /* db.SaveChanges();*/ return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool KTSuaALLCTHDCuaBanChuyen1(List<ChiTietHoaDonDTO> mahdHienTai, List<ChiTietHoaDonDTO> mahdChuyenBan)
        {
            try
            {
               foreach(var item in mahdHienTai)
                {
                    foreach(var item2 in mahdChuyenBan)
                    {
                        if(item.MaSP == item2.MaSP && item.Size == item2.Size)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool SuaALLCTHDCuaBanChuyen(int mahdHienTai, int mahdChuyenBan)
        {
            try
            {
                string query = string.Format("UPDATE ChiTietHoaDon SET MaHD = {0} WHERE MaHD = {1} AND TrangThai = 1", mahdChuyenBan, mahdHienTai);
                db.ChiTietHoaDons.SqlQuery(query).ToList();
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool KiemTraBanChuyenCoHoaDonGiong(int mahdChuyen, int masp, string size)
        {
            ChiTietHoaDon ct = db.ChiTietHoaDons.SingleOrDefault(p => p.MaHD == mahdChuyen && p.MaSP == masp && p.Size == size);
            if (ct == null) return false;
            return true;
        }

        public bool KiemTraHoaDonCoCTHDKhong(int mahd)
        {
            try
            {
                var hd = db.HoaDons.Find(mahd);//
                var cthd = hd.ChiTietHoaDons.ToList();//theo hóa đơn
                if(cthd.Count == 0)
                {
                    return false;
                }    
                 return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //cthd

        public List<ChiTietHoaDonDTO> LayDSCTHD()
        {
            var list = db.ChiTietHoaDons.Where(p => p.TrangThai == true).ToList();
            var k = "";
            return list.Select(v => new ChiTietHoaDonDTO
            {
                MaHD = v.HoaDon.MaHD,
                MaSP = v.SanPham.MaSP,
                SoLuong = (int)v.SoLuong,
                DonGia = (float)v.DonGia,
                ThanhTien = (float)v.ThanhTien,
                GiamGia = (int)v.GiamGia,
                Size = v.Size,//
                TenSP = k = db.SanPhams.Find(v.MaSP).TenSP,
                TrangThai = (bool)v.TrangThai,
                
            }).ToList();
        }

        public List<ChiTietHoaDonDTO> LayDSCTHDThanhToan()
        {
            var list = db.ChiTietHoaDons.Where(p => p.TrangThai == false).ToList();
            var k = "";
            return list.Select(v => new ChiTietHoaDonDTO
            {
                MaHD = v.HoaDon.MaHD,
                MaSP = v.SanPham.MaSP,
                SoLuong = (int)v.SoLuong,
                DonGia = (float)v.DonGia,
                ThanhTien = (float)v.ThanhTien,
                GiamGia = (int)v.GiamGia,
                Size = v.Size,//
                TenSP = k = db.SanPhams.Find(v.MaSP).TenSP,
                TrangThai = (bool)v.TrangThai,

            }).ToList();
        }

        public bool suachitiethoadon(ChiTietHoaDonDTO edithoadon)
        {
            try
            {
                ChiTietHoaDon cthd = db.ChiTietHoaDons.SingleOrDefault(p => p.MaHD == edithoadon.MaHD);
                cthd.MaSP = edithoadon.MaSP;
                cthd.SoLuong = edithoadon.SoLuong;
                cthd.DonGia = edithoadon.DonGia;
                cthd.MaSP = edithoadon.MaSP;
                cthd.GiamGia = edithoadon.GiamGia;
                cthd.Size = edithoadon.Size;
                cthd.ThanhTien = edithoadon.ThanhTien;
                if (db.SaveChanges() == 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
