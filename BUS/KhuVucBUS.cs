using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhuVucBUS
    {
        private static KhuVucBUS instance;
        public static KhuVucBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhuVucBUS();
                }
                return instance;
            }
        }
        public List<KhuVucDTO> LayDSKhuVuc()
        {
            return KhuVucDAO.Instance.LayDSKhuVuc();
        }
        public bool Add(KhuVucDTO khuVuc)
        {
            return KhuVucDAO.Instance.Add(khuVuc);
        }

        public bool Edit(KhuVucDTO khuVuc)
        {
            return KhuVucDAO.Instance.Edit(khuVuc);
        }
        public bool Del(KhuVucDTO khuVuc)
        {
            return KhuVucDAO.Instance.Del(khuVuc);
        }
        public bool KiemTraTenTonTai(string tenkhuvuc)
        {
            return KhuVucDAO.Instance.KiemTraTenTonTai(tenkhuvuc);
        }
        public bool KiemTraTonTaiBanTrongKhuVuc(int makv)
        {
            return KhuVucDAO.Instance.KiemTraTonTaiBanTrongKhuVuc(makv);
        }
    }
}
