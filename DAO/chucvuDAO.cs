using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class chucvuDAO
    {
        public static chucvuDAO instance;
        QuanLyCuaHangTraSua_HKTEntities db = new QuanLyCuaHangTraSua_HKTEntities();
        public static chucvuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new chucvuDAO();
                return instance;
            }
        }
        public List<chucvuDTO> loadds()
        {
            var list=db.ChucVus.Where(p=>p.TrangThai.Value==false).ToList();
            return list.Select(p=>new chucvuDTO
            {
                machucvu=p.MaChucVu,
                tenchucvu=p.TenChucVu,
                trangthai=(bool)p.TrangThai
                
            }).ToList();
        }
    }
}
