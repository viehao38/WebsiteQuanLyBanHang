using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class KhuVucDAO
    {
        QuanLyCuaHangTraSua_HKTEntities db = new QuanLyCuaHangTraSua_HKTEntities();
        private static KhuVucDAO instance;
        public static KhuVucDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KhuVucDAO();
                }
                return instance;
            }
        }

     
        public List<KhuVucDTO> LayDSKhuVuc()
        {
            var list = db.KhuVucs.Where(p => p.TrangThai == false).ToList();
            return list.Select(p => new KhuVucDTO
            {
                maKhuVuc = (int)p.MaKhuVuc,
                tenKhuVuc = p.TenKhuVuc,
                trangThai = (bool)p.TrangThai
            }).ToList();
        }

        public bool Add(KhuVucDTO khuVuc)
        {
            try
            {
                KhuVuc kv = new KhuVuc
                {
                    MaKhuVuc = khuVuc.maKhuVuc,
                    TenKhuVuc = khuVuc.tenKhuVuc,
                    TrangThai = khuVuc.trangThai
                };
                db.KhuVucs.Add(kv);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Edit(KhuVucDTO khuVuc)
        {
            try
            {
                KhuVuc kv = db.KhuVucs.SingleOrDefault(p => p.MaKhuVuc == khuVuc.maKhuVuc);
                kv.TenKhuVuc = khuVuc.tenKhuVuc;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Del(KhuVucDTO khuVuc)
        {
            try
            {
                KhuVuc kv = db.KhuVucs.SingleOrDefault(p => p.MaKhuVuc == khuVuc.maKhuVuc);
                kv.TrangThai = khuVuc.trangThai;
                if(kv == null)return false;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool KiemTraTenTonTai(string tenkhuvuc)
        {
            var list = db.KhuVucs.SingleOrDefault(p => p.TenKhuVuc == tenkhuvuc && p.TrangThai == false);
            if (list == null) return false;
            return true;
        }

        public bool KiemTraTonTaiBanTrongKhuVuc(int makv)
        {
            var list = db.Bans.Where(p => p.TrangThai == false).ToList();
            foreach(var kv in list)
            {
                if(kv.MaKhuVuc == makv) return true;
            }    
            return false;
        }
    }
}
