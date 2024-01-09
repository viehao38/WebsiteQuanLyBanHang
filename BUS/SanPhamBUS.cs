using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class SanPhamBUS
    {
        private static SanPhamBUS instance;
        public static SanPhamBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanPhamBUS();
                }
                return instance;
            }
        }

        public List<SanPhamDTO> LayDSSanPham()
        {
            return SanPhamDAO.Instance.LayDSSanPham();
        }

        public List<SanPhamDTO> LayDSSanPhamTheoLoai(int maloaisp)
        {

            return SanPhamDAO.Instance.LayDSSanPhamTheoLoai(maloaisp);
        }

        public int LayMaSPTheoTen(string txt)
        {
            return SanPhamDAO.Instance.LayMaSPTheoTen(txt);
        }

        public List<SanPhamDTO> TimTenSanPham(string tensp)
        {
            return SanPhamDAO.Instance.TimTenSanPham(tensp);
        }

        public string layTenTheoMaSP(int masp)
        {
            return SanPhamDAO.Instance.layTenTheoMaSP(masp);
        }

        public bool ThemSanPham(SanPhamDTO newsp)
        {
            return SanPhamDAO.Instance.ThemSanPham(newsp);
        }
        public bool SuaSanPham(SanPhamDTO newsp)
        {
            return SanPhamDAO.Instance.SuaSanPham(newsp);
        }

        public bool SuaSanPhamCoImage(SanPhamDTO newsp)
        {
            return SanPhamDAO.Instance.SuaSanPhamCoImage(newsp);
        }

        public bool XoaSanPham(SanPhamDTO newsp)
        {
            return SanPhamDAO.Instance.XoaSanPham(newsp);
        }
        public List<SanPhamDTO> TimMaSanPham(string masp)
        {
            return SanPhamDAO.Instance.TimMaSanPham(masp);
        }
        public List<SanPhamDTO> TimDanhMucSanPham(string danhmuc)
        {
            return SanPhamDAO.Instance.TimDanhMucSanPham(danhmuc);
        }
        public List<SanPhamDTO> TimDonViTinhSanPham(string donvitinh)
        {
            return SanPhamDAO.Instance.TimDonViTinhSanPham(donvitinh);
        }
  
        public bool KiemTraTonTaiDataview(string tensp)
        {
            return SanPhamDAO.Instance.KiemTraTonTaiDataview(tensp);
        }

        public byte[] ConvertImage(string pathimage)
        {
           return SanPhamDAO.Instance.ConvertImage(pathimage);
        }

    }
}
