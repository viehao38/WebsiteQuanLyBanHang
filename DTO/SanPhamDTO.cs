using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {

        public int masp { get; set; }
        public int madanhmuc { get; set; }
        public string tendanhmuc { get; set; }
        public string tensanpham { get; set; }
        //public string hinhanh { get; set; }
        public byte[] anhsp { get; set; }
        public string mota { get; set; }
        public string donvitinh { get; set; }
        public float donGiaL { get; set; }
        public float donGiaM { get; set; }
        //public string size { get; set; }
        public bool trangthai { get; set; }



    }
}
