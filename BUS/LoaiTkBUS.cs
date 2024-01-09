using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class LoaiTkBUS
    {
        private static LoaiTkBUS instance;
        public static LoaiTkBUS Instance
        {
            get
            {
                if(instance==null)
                    instance = new LoaiTkBUS();
                return instance;
            }
        }
        public List<LoaiTKDTO>LayDSLoaiTK()
        {
            return LoaiTKDAO.Instance.LayDSLoaiTK();
        }
        public bool ThemLoaiTk(LoaiTKDTO ltk)
        {
            return LoaiTKDAO.Instance.ThemLoaiTk(ltk);
        }
        public bool SuaLoaiTk(LoaiTKDTO ltk)
        {
            return LoaiTKDAO.Instance.SuaLoaiTk(ltk);
        }
        public bool XoaLoaiTk(LoaiTKDTO ltk)
        {
            return LoaiTKDAO.Instance.XoaLoaiTk(ltk);
        }
        public bool KiemTraTonTai(int id)
        {
            return LoaiTKDAO.Instance.KiemTraTonTai(id);
        }
        public bool KiemTraTonTaiDataView(string tenltk)
        {
            return LoaiTKDAO.Instance.KiemTraTonTaiDataView(tenltk);
        }
    }
}
