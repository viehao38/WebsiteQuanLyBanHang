using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DanhMucBUS
    {

        private static DanhMucBUS instance;
        public static DanhMucBUS Istance
        {
            get
            {
                if (instance == null)
                    instance = new DanhMucBUS();
                return instance;
            }
        }
        public List<DanhMucDTO> LayDSDanhMuc()
        {
            return DanhMucDAO.Istance.LayDSDanhMuc();

        }
        public bool ThemDanhMuc(DanhMucDTO dm)
        {
            return DanhMucDAO.Istance.ThemDanhMuc(dm);
        }
        public bool SuaDanhMuc(DanhMucDTO dm)
        {
            return DanhMucDAO.Istance.SuaDanhMuc(dm);
        }
        public bool XoaDanhMuc(DanhMucDTO dm)
        {
            return DanhMucDAO.Istance.XoaDanhMuc(dm);
        }
        public bool KiemTraTonTai(int id)
        {
            return DanhMucDAO.Istance.KiemTraTonTai(id);
        }
        public bool KiemTraTonTaiDataView(string tendm)
        {
            return DanhMucDAO.Istance.KiemTraTonTaiDataView(tendm);
        }
    }
}
