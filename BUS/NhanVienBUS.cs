using Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class NhanVienBUS
    {
        private static NhanVienBUS instance;
        public static NhanVienBUS Instance
        {
            get 
            {
                if (instance == null)
                    instance = new NhanVienBUS();
                return instance;
            } 
        }
        public List<NhanVienDTO>loadnhanvien()
        {
            return NhanVienDAO.Instance.loadnhanvien();
        }
        public bool themnhanvien(NhanVienDTO addnv)
        {
            if(NhanVienDAO.Instance.kTraDinhDangEmail(addnv.EMAIL))
            {
                return false;
            }
            if (NhanVienDAO.Instance.kTraNgaySinh(addnv.NGAYSINH))
            {
                return false;
            }
            if (NhanVienDAO.Instance.kTraNgaySinh(addnv.NGAYVAOLAM))
            {
                return false;
            }
            return NhanVienDAO.Instance.themnv(addnv);
        }
        public bool xoanhanvien(NhanVienDTO clearnv)
        {
            return NhanVienDAO.Instance.xoanhanvien(clearnv);
        }
        public bool suanhanvien(NhanVienDTO editnv)
        {
            if (NhanVienDAO.Instance.kTraDinhDangEmail(editnv.EMAIL))
            {
                return false;
            }
            if (NhanVienDAO.Instance.kTraNgaySinh(editnv.NGAYSINH))
            {
                return false;
            }
            if (NhanVienDAO.Instance.kTraNgaySinh(editnv.NGAYVAOLAM))
            {
                return false;
            }
            return NhanVienDAO.Instance.suanhanvien(editnv);
        }
        public List<NhanVienDTO> timtennhanvien(string name)
        {
            return NhanVienDAO.Instance.timtennhanvien(name);
        }

        public List<NhanVienDTO> DSNhanVienTheoChucVu(int machucvu)
        {
            return NhanVienDAO.Instance.DSNhanVienTheoChucVu(machucvu);
        }
        public List<NhanVienDTO> TimNhanVienTheoMaNhanVien(int id)
        {
            return NhanVienDAO.Instance.TimNhanVienTheoMaNhanVien(id);
        }

    }
}
