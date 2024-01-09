using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class DanhMucDAO
    {


        QuanLyCuaHangTraSua_HKTEntities trasua = new QuanLyCuaHangTraSua_HKTEntities();
        private static DanhMucDAO instance;
        public static DanhMucDAO Istance
        {
            get
            {
                if (instance == null)
                    instance = new DanhMucDAO();
                return instance;
            }
        }
 
        public List<DanhMucDTO> LayDSDanhMuc()
        {
            var list = trasua.DanhMucs.Where(v => v.TrangThai.Value == true).ToList();
            return list.Select(v => new DanhMucDTO
            {
                madanhmuc = v.MaDanhMuc,
                tendanhmuc = v.TenDanhMuc,
                trangthai = v.TrangThai.Value

            }).ToList();
        }
        public bool ThemDanhMuc(DanhMucDTO dm)
        {
            try
            {
                DanhMuc sp = new DanhMuc
                {
                    TenDanhMuc= dm.tendanhmuc,
                    TrangThai = dm.trangthai
                };
                trasua.DanhMucs.Add(sp);
                trasua.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SuaDanhMuc(DanhMucDTO dm)
        {
            try
            {
                DanhMuc sua = trasua.DanhMucs.SingleOrDefault(p => p.MaDanhMuc== dm.madanhmuc);
                sua.TenDanhMuc = dm.tendanhmuc;

                if (trasua.SaveChanges() == 0) return false;
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool XoaDanhMuc(DanhMucDTO dm)
        {
            try
            {
                DanhMuc xoa = trasua.DanhMucs.SingleOrDefault(p => p.MaDanhMuc == dm.madanhmuc);
                xoa.TrangThai = false;
                if (trasua.SaveChanges() == 0) return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool KiemTraTonTai(int id)
        {
            var kt = trasua.DanhMucs.Join(trasua.SanPhams, c => c.MaDanhMuc, ct => ct.MaDanhMuc, (c, ct)
                => new { Danhmuc = c, SanPham = ct })
                .Where(data => data.Danhmuc.TrangThai.Value == true && data.Danhmuc.MaDanhMuc == id)
                .Select(data => data.Danhmuc).ToList();
            if (kt.Count >= 1)
            {
                return true;
            }
            return false;
            

        }

        public bool KiemTraTonTaiDataView(string tendm)
        {
            var kt = trasua.DanhMucs.Where(p => p.TenDanhMuc.Contains(tendm) && p.TrangThai == true).ToList();
            //Contains thay thế cho %
            if (kt.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

