using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class BanBUS
    {
        private static BanBUS instance;

        public static BanBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BanBUS();
                }
                return instance;
            }
        }

        public List<BanDTO> LoadDSBan()
        {
            return BanDAO.Instance.LoadDSBan();
        }
        public List<BanDTO> LoadDSBanTheoKhuVuc(string makhuvuc)
        {
            return BanDAO.Instance.LoadDSBanTheoKhuVuc(makhuvuc);
        }

        public List<BanDTO> TimKiemBan(string tenban)
        {
            return BanDAO.Instance.TimKiemBan(tenban);
        }

        public bool ThemBan(BanDTO nBan)
        {
            if(BanDAO.Instance.KiemTraTenTonTai(nBan.TenBan))
            {
                return false;
            }    
            return BanDAO.Instance.ThemBan(nBan);
        }

        public bool SuaBan(BanDTO nBan)
        {
           return BanDAO.Instance.SuaBan(nBan);
        }

        public bool CapNhatBanCoNguoi(int maban)
        {
            return BanDAO.Instance.CapNhatBanCoNguoi(maban);
        }
        public bool CapNhatBanCoNguoiOrKhongCoNguoi(int maban, bool check)
        {
            return BanDAO.Instance.CapNhatBanCoNguoiOrKhongCoNguoi(maban,check);
        }

        public bool KiemTraTenTonTai(string tenban)
        {
            return BanDAO.Instance.KiemTraTenTonTai(tenban);
        }
    }
}
