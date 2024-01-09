using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using DAO;
using DTO;
namespace BUS
{
    public class HoaDonBUS
    {
        private static HoaDonBUS instance;
        public static HoaDonBUS Instance
        {
            get
            {
                if(instance == null)
                    instance = new HoaDonBUS();
                return instance;
            }
        }

        public List<HoaDonDTO> LayDSHoaDon()
        {
            return HoaDonDAO.Instance.LayDSHoaDon();
        }
        public HoaDonDTO LayDSHoaDonTheoBan(int maban, int mahd)
        {
            return HoaDonDAO.Instance.LayDSHoaDonTheoBan(maban, mahd);
        }
        public int LayMaHoaDonCuaBan(int maban)
        {
            return HoaDonDAO.Instance.LayMaHoaDonCuaBan(maban);
        }

        public int LayHoaDonMax()
        {
            return HoaDonDAO.Instance.LayHoaDonMax();
        }

        public double LayTongTienCuaHoaDon(int mahd)
        {
            return HoaDonDAO.Instance.LayTongTienCuaHoaDon(mahd);
        }

        public bool capNhatTongTien(int mahd, float thanhtienCTHD = 0)
        {
            return HoaDonDAO.Instance.capNhatTongTien(mahd, thanhtienCTHD);
        }

        public bool ThemHoaDon(HoaDonDTO newhd)
        {
            return HoaDonDAO.Instance.ThemHoaDon(newhd);
        }

        public bool CapNhatHoaDonDaThanhToan(int mahd, bool check)
        {
            return HoaDonDAO.Instance.CapNhatHoaDonDaThanhToan(mahd, check);
        }

        public bool SuaHoaDonKhiChuyenban(int mahd, int maban)
        {
            return HoaDonDAO.Instance.SuaHoaDonKhiChuyenban(mahd,maban);
        }

        public bool XoaHoaDonKhiChuyenban(int mahd)
        {
            return HoaDonDAO.Instance.XoaHoaDonKhiChuyenban(mahd);
        }


        public float ThongKeDoanhThu(DateTime tungay, DateTime denngay)
        {
            return HoaDonDAO.Instance.ThongKeDoanhThu(tungay, denngay);
        }

        public List<HoaDonDTO> DSHoaDonTheoDoanhThuTuNgayDenNgay(DateTime tungay, DateTime denngay)
        {
            return HoaDonDAO.Instance.DSHoaDonTheoDoanhThuTuNgayDenNgay(tungay,denngay);
        }

        public List<HoaDonDTO> DSHoaDonTheoDoanhThuTheoThang(int thang, int nam)
        {
            return HoaDonDAO.Instance.DSHoaDonTheoDoanhThuTheoThang(thang,nam);
        }

        public float ThongKeDoanhThuTheoThang(int thang, int nam)
        {
           return HoaDonDAO.Instance.ThongKeDoanhThuTheoThang(thang,nam);
        }
        //hoa don
     
        public bool themhd(HoaDonDTO addhd)
        {
            return HoaDonDAO.Instance.themhoadon(addhd);
        }
        public bool suahd(HoaDonDTO edithd)
        {
            return HoaDonDAO.Instance.suahoadon(edithd);
        }
        public List<HoaDonDTO> timmahoadon(int mahd)
        {
            return HoaDonDAO.Instance.timmahoadon(mahd);
        }
        //public List<HoaDonDTO> timtennv(string ten)
        //{
        //    return HoaDonDAO.Instance.timtheotennv(ten);
        //}
    }
}
