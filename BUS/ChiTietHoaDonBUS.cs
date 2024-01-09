using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using static System.Net.WebRequestMethods;

namespace BUS
{
    public class ChiTietHoaDonBUS
    {
        private static ChiTietHoaDonBUS instance;
        public static ChiTietHoaDonBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ChiTietHoaDonBUS();
                return instance;
            }
        }

        //public List<ChiTietHoaDonDTO> LayDSCTHDTheoMaHD1(int mahd, DateTime dtp, bool check = true)
        //{
        //    return ChiTietHoaDonDAO.Instance.LayDSCTHDTheoMaHD1(mahd, dtp, check);
        //}

        public List<ChiTietHoaDonDTO> LayDSCTHDTheoMaHD(int mahd, bool check = true)
        {
            return ChiTietHoaDonDAO.Instance.LayDSCTHDTheoMaHD(mahd,check);
        }

        public bool checkCTHDGiong(ChiTietHoaDonDTO cthd)
        {
            return ChiTietHoaDonDAO.Instance.checkCTHDGiong(cthd);
        }

        public bool ThemCTHD(ChiTietHoaDonDTO cthdnew)
        {
            return ChiTietHoaDonDAO.Instance.ThemCTHD(cthdnew);
        
        }

        public bool XoaCTHD(int mahd, int masp, string size)
        {
            return ChiTietHoaDonDAO.Instance.XoaCTHD(mahd, masp, size);
        }

        public bool SuaCTHD(ChiTietHoaDonDTO cthd)
        {
            return ChiTietHoaDonDAO.Instance.SuaCTHD(cthd);
        }

        public bool SuaCTHDKhiDaThem(ChiTietHoaDonDTO cthd)
        {
            return ChiTietHoaDonDAO.Instance.SuaCTHDKhiDaThem(cthd);
        }

        public bool XoaALLCTHD(int mahd, bool check)
        {
            return ChiTietHoaDonDAO.Instance.XoaALLCTHD(mahd, check);
        }

        public bool SuaALLCTHDCuaBanChuyen(int mahdHienTai, int mahdChuyenBan)
        {
            return ChiTietHoaDonDAO.Instance.SuaALLCTHDCuaBanChuyen(mahdHienTai,mahdChuyenBan);
        }

        public bool KTSuaALLCTHDCuaBanChuyen(int mahdHienTai, int mahdChuyenBan)
        {
            return ChiTietHoaDonDAO.Instance.KTSuaALLCTHDCuaBanChuyen(mahdHienTai,mahdChuyenBan);
        }

        public bool KTSuaALLCTHDCuaBanChuyen1(List<ChiTietHoaDonDTO> mahdHienTai, List<ChiTietHoaDonDTO> mahdChuyenBan)
        {
           return ChiTietHoaDonDAO.Instance.KTSuaALLCTHDCuaBanChuyen1(mahdHienTai, mahdChuyenBan);
        }

        public bool KiemTraBanChuyenCoHoaDonGiong(int mahdChuyen, int masp, string size)
        {
            return ChiTietHoaDonDAO.Instance.KiemTraBanChuyenCoHoaDonGiong(mahdChuyen, masp, size);
        }

        public bool KiemTraHoaDonCoCTHDKhong(int mahd)
        {
            return ChiTietHoaDonDAO.Instance.KiemTraHoaDonCoCTHDKhong(mahd);
        }

        //cthd
        public List<ChiTietHoaDonDTO> LayDSCTHD()
        {
            return ChiTietHoaDonDAO.Instance.LayDSCTHD();
        }

        public List<ChiTietHoaDonDTO> LayDSCTHDThanhToan()
        {
            return ChiTietHoaDonDAO.Instance.LayDSCTHDThanhToan();
        }

        public bool suachitiethoadon(ChiTietHoaDonDTO editcthd)
        {
            return ChiTietHoaDonDAO.Instance.suachitiethoadon(editcthd);
        }

    }
}
