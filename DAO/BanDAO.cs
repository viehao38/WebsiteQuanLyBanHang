using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class BanDAO
    {
        QuanLyCuaHangTraSua_HKTEntities db = new QuanLyCuaHangTraSua_HKTEntities();
        private static BanDAO instance;

        public static BanDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BanDAO();
                }
                return instance;
            }
        }

        public List<BanDTO> LoadDSBanTheoKhuVuc(string tenkkhuVuc)
        {
            var list = db.Bans.Where(p => p.KhuVuc.TenKhuVuc == tenkkhuVuc);
            return list.Select(p => new BanDTO
            {
                MaBan = p.MaBan,
                TenBan = p.TenBan,
                MaKhuVuc = (int)p.MaKhuVuc,
                TrangThai = (bool)p.TrangThai
            }).ToList();
        }

        public List<BanDTO> TimKiemBan(string tenban)
        {
            string query = string.Format("SELECT * FROM Ban WHERE TenBan LIKE N'%{0}%' ORDER BY TenBan", tenban);
            var list = db.Bans.SqlQuery(query).ToList();

            return list.Select(p => new BanDTO
            {
                MaBan = p.MaBan,
                TenBan = p.TenBan,
                MaKhuVuc = (int)p.MaKhuVuc,
                TrangThai = (bool)p.TrangThai
            }).ToList();

        }

        public List<BanDTO> LoadDSBan()
        {
            var list = db.Bans.ToList();

            return list.Select(p => new BanDTO
            {
                MaBan= p.MaBan,
                TenBan= p.TenBan,
                MaKhuVuc= (int)p.MaKhuVuc,
                TrangThai= (bool)p.TrangThai
            }).ToList();
        }
        public bool ThemBan(BanDTO nBan)
        {
            try
            {
                Ban ban = new Ban
                {
                    TenBan = nBan.TenBan,
                    MaKhuVuc= nBan.MaKhuVuc,
                    TrangThai= nBan.TrangThai
                };
                db.Bans.Add(ban);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool KiemtratenBanTonTai(string tenban)
        {
            try
            {
                var ban = db.Bans.SingleOrDefault(p => p.TenBan == tenban);
                if (ban == null) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int LayMaBanLonNhat()
        {
            try
            {
                var mabanMax = db.Bans.Max(p => p.MaBan);

                if(mabanMax == 0)
                {
                    return -1;
                }    
                return mabanMax;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public bool SuaBan(BanDTO nBan)
        {
            try
            {
                Ban list = db.Bans.SingleOrDefault(p => p.MaBan== nBan.MaBan);
                if(list == null)
                    return false;
                list.TenBan = nBan.TenBan;
                list.MaKhuVuc = nBan.MaKhuVuc;
                list.TrangThai = nBan.TrangThai;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool CapNhatBanCoNguoiOrKhongCoNguoi(int maban, bool check)
        {
            try
            {
                Ban ban = db.Bans.SingleOrDefault(p => p.MaBan == maban);
                if (ban == null) return false;
                ban.TrangThai = check;
                db.SaveChanges(); return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool KiemTraTenTonTai(string tenban)
        {
            var list = db.Bans.SingleOrDefault(p => p.TenBan == tenban && p.TrangThai == false);
            if(list == null) return false;
            return true;
        }

        public bool CapNhatBanCoNguoi(int maban)
        {
            try
            {
                Ban ban = db.Bans.SingleOrDefault(p => p.MaBan== maban);
                if(ban == null) return false;
                ban.TrangThai = true;
                db.SaveChanges(); return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
