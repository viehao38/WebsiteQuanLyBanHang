using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangTraSuaHKT
{
    internal class Constants
    {
        #region Hằng chuỗi
        //Chỗ này của hào 

        public static string SELECT_SIZE = "Vui lòng chọn size";

        public static string SELECT_MON = "Vui lòng chọn món";

        public static string ADD_MON = "Bạn có muốn thêm món";

        public static string EDIT_MON = "Bạn có muốn sửa món";

        public static string EDIT_MON_SUCCESSFUL = "Sửa món thành công";

        public static string EDIT_MON_FAILED = "Sửa món thất bại";

        public static string QUESTION_THANHTOAN = "Bạn có muốn thanh toán";

        public static string SELECT_MON_ORDER_TO_EDIT = "Vui lòng chọn món cần sửa";

        public static string DEL_MON = "Bạn có muốn xóa món";

		public static string DEL_NOT_CTHD = "Chưa có món để xóa";

		public static string EDIT_NOT_CTHD = "Chưa có món để sửa";

		public static string BAN_SELECT_NOT_EXIST_HD = "Bàn này chưa có hóa đơn";

        public static string NOT_HD = "Chưa có hóa đơn";

        public static string NOTIFICATION = "Thông báo";

        public static string YOU_WANNA_EXIT = "Bạn có muốn thoát";

        public static string NOT_PASS_IS_CTHD_SAME = "Không thể chuyển khi có thông tin giống nhau";

        //Bàn

        public static string PLS_SELECT_BAN = "Vui lòng chọn bàn";

        public static string YOU_WANNA_SELECT_BAN = "Bạn có muốn chọn ";

        public static string YOU_WANNA_MOVE_BAN = "Bạn có muốn chuyển";

        public static string YOU_NOT_MOVE_BAN_SAME = "Bạn không thể chuyển bàn giống nhau";

        public static string EIDT_BAN_SUCCESSFUL = "Sửa bàn thành công";

        public static string ADD_BAN_SUCCESSFUL = "Thêm bàn thành công";

        public static string EIDT_BAN_FAILED = "Sửa bàn thất bại";

        public static string PLS_INPUT_NAME_BAN = "Vui lòng nhập tên bàn";

        public static string YOU_WANNA_EDIT_BAN = "Bàn có muốn sửa bàn";

        public static string YOU_WANNA_ADD_BAN = "Bàn có muốn thêm bàn";

        public static string ADD_BAN_FAILED = "Không thể thêm bàn cùng tên";

        public static string NAME_BAN_EXIST = "Tên bàn đã có trong hệ thống";

        public static string PLS_INPUT_YEAR = "Vui lòng nhập năm";

        //khu vực
        public static string ADD_KHUVUC_SUCCESSFUL = "Thêm khu vực thành công";

        public static string ADD_KHUVUC_FAILED = "Thêm khu vực thất bại";

        public static string EIDT_KHUVUC_SUCCESSFUL = "Sửa khu vực thành công";

        public static string EIDT_KHUVUC_FAILED = "Sửa khu vực thất bại";

        public static string DEL_KHUVUC_SUCCESSFUL = "Xóa khu vực thành công";

        public static string DEL_KHUVUC_FAILED = "Xóa khu vực thất bại";

        public static string PLS_INPUT_NAME_KHUVUC = "Vui lòng nhập tên khu vực";

        public static string PLS_INPUT_CODENAME_KHUVUC = "Vui lòng nhập mã khu vực";

        public static string NAME_KHUVUC_EXIST = "Tên khu vực đã có trong hệ thống";

        public static string BAN_IN_KHUVUC = "Có bàn trong khu vực không thể xóa";

        //đăng nhập

        public static string LOGIN_TENNV = "Tên nhân viên : ";

        public static string TIME_HH_MM_SS = "hh:mm:ss";

        public static string TIME = "Thời gian: ";

        public static string PASSWORD_OR_USERNAME_WRONG_INPUT_AGAIN= "Mật khẩu hoặc tên đăng nhập sai, vui lòng nhập lại";

        public static string C = "c";

        public static string CULTURE = "vi-VN";

        public static char ASTERISK = '*';

        public static string ALL = "Tất cả";

        public static string NAMEBAN = "Tên bàn";

        public static string EREA = "Khu vực";

        public static string VAlUEMEMBERBAN = "MaBan";

        public static string DISPLAYMEMBERBAN = "TenBan";

        public static string VAlUEMEMBERKHUVUC = "MaKhuVuc";

        public static string DISPLAYMEMBERKHUVUC = "TenKhuVuc";

        public static string MONEY_NOT_ENOUGH = "Tiền khách đưa không dủ để thanh toán";

        public static string REPORT_DT_EmbeddedResource_PHIEUHD = "CuaHangTraSuaHKT.rptPhieuHoaDon.rdlc";
        public static string REPORT_DT_DataSources_PHIEUHD = "DSChiTietHoaDonCuaHoaDon";
        public static string REPORT_DT_Parameters_NGAYLAP = "rptpaNgayLapPhieuHD";
        public static string REPORT_DT_Parameters_NGUOILAP = "rptpaNguoiLapHD";
        public static string REPORT_DT_Parameters_TOTAL_MONEY = "rptpaTongTien";
        public static string REPORT_DT_Parameters_TIENTRAKHACH = "rptpaTienTraKhach";
        public static string REPORT_DT_Parameters_TIENKHACHDUA = "rptpaTienKhachDua";

        //Chỗ này của khánh
        // Không thề xóa tài khoản chủ
        public static string NAME_ACCOUNT = "Admin";
        //Tài Khoản
        public static string EXIT_THIS_PAGE = "Rời khỏi trang này!";
        public static string ENTER_THE_ACCOUNT = "Chưa cung cấp tài khoản!";
        public static string ENTER_THE_PASSWORD = "Chưa cung cấp mật khẩu!";
        public static string INVALID_PASSWORD = "Mật khẩu không hợp lệ!";
        public static string ADD_SUCCESS = "Thêm thành công";
        public static string ADD_FAILURE = "Thêm thất bại!";
        public static string EDIT_SUCCESS = "Sửa thành công";
        public static string EDIT_FAILURE = "Sửa thất bại!";
        public static string DELETE_SUCCESS = "Xóa thành công";
        public static string DELETE_FAILURE = "Xóa thất bại!";
        public static string SELECT_THE_ACCOUNT_TO_EDIT = "Chọn tài khoản cần sửa!";
        public static string SELECT_THE_ACCOUNT_TO_DELETE = "Chọn tài khoản cần xóa!";
        public static string THIS_ACCOUNT_CANNOT_BE_DELETE = "Không thể xóa tài khoản này!";
        public static string CONFIRM_DELETE = "Xác nhận xóa!";
        //Sản phẩm
        public static string ENTER_PRODUCT_NAME = "Chưa cung cấp tên sản phẩm!";
        public static string ENTER_UNIT_PRICE_M = "Chưa cung cấp đơn giá size M!";
        public static string ENTER_UNIT_PRICE_L = "Chưa cung cấp đơn giá size L!";
        public static string INVALID_UNIT_PRICE = "Đơn giá không hợp lệ!";
        public static string ADD_IMAGE = "Chưa cung cấp ảnh cho sản phẩm!";
        public static string PRODUCT_AVAILABLE_ON_SYSTEM = "Sản phẩm đã có trên hệ thống!";
        public static string SELECT_THE_PRODUCT_TO_EDIT = "Chọn sản phẩm cần sửa!";
        public static string SELECT_THE_PRODUCT_TO_DELETE = "Chọn sản phẩm cần xóa!";
        //Loai sản phẩm
        public static string PRODUCT_IN_USING_CANNOT_EDIT = "Loại sản phẩm đang được sử dụng, không thể sửa!";
        public static string ENTER_PRODUCT_TYPE_NAME = "Chưa cung cấp tên loại sản phẩm!";
        public static string SELECT_THE_PRODUCT_TYPE_TO_EDIT = "Chọn loại sản phẩm cần sửa!";
        public static string SELECT_THE_PRODUCT_TYPE_TO_DELETE = "Chọn loại sản phẩm cần xóa!";
        public static string PRODUCT_IN_USING_CANNOT_DELETE = "Loại sản phẩm đang được sử dụng, không thể xóa !";
        public static string PRODUCT_TYPE_AVAILABLE_ON_SYSTEM = "Loại sản phẩm đã có trên hệ thống!";
        //Loai tài khoản
        public static string ACCOUNT_IN_USING_CANNOT_EDIT = "Loại tài khoản đang được sử dụng, không thể sửa !";
        public static string ENTER_ACCOUNT_TYPE_NAME = "Chưa cung cấp tên loại tài khoản!";
        public static string SELECT_THE_ACCOUNT_TYPE_TO_EDIT = "Chọn loại tài khoản cần sửa!";
        public static string SELECT_THE_ACCOUNT_TYPE_TO_DELETE = "Chọn loại tài khoản cần xóa!";
        public static string ACCOUNT_IN_USING_CANNOT_DELETE = "Loại tài khoản đang được sử dụng, không thể xóa !";
        public static string ACCOUNT_TYPE_AVAILABLE_ON_SYSTEM = "Loại tài khoản đã có trên hệ thống!";

        public static int LICK_ZERO = 0;
        public static int LICK_ONE = 1;
        public static int NUMBER_DEFAULT_ONE = 1;
        public static int NUMBER_DEFAULT_TWO = 2;
        public static string ASTERISKTHREE = "***";
        public static string SPAKE = "";
        public static char DOTS = '.';
        public static string IMAGE_FILE = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        public static string CONSITION_IMAGE = "System.Byte[]";
        public static string LICK_ID = "id";
        public static string LICK_CODE_DM = "madm";
        public static string LICK_NAMEPD = "tensp";
        public static string LICK_UNIT = "donvitinh";
        public static string LICK_UNIT_PRICE_M = "dongiam";
        public static string LICK_UNIT_PRICE_L = "dongial";
        public static string LICK_IMAGE = "anh";

        public static string CODE_STAFF = "MaNV";
        public static string NAME_STAFF = "TenNV";

        public static string LICK_CODE_STAFF = "manv";
        public static string LICK_NAME_STAFF = "tenthanhvien";
        public static string LICK_ACCOUNT = "taikhoan";
        public static string LICK_PASSWORK = "matkhau";
        public static string LICK_ACCOUNT_TYPE = "loaitaikhoan";

        //Chỗ này của trường

        //Nhân Viên
        public static string VAlUEMEMBERNV = "MaNV";
        public static string DISPLAYMEMBERNV = "TenNV";

        public static string VAlUEMEMBER_HD = "MaHD";
        public static string DISPLAYMEMBER_HD = "MaHD";

        public static string VAlUEMEMBER_SP = "MaSP";
        public static string DISPLAYMEMBER_SP = "tensanpham";

        public static string VAlUEMEMBER_DM = "madanhmuc";
        public static string DISPLAYMEMBER_DM = "tendanhmuc";

        public static string DGV_MAHD = "mahd";
        public static string DGV_MABAN = "maban";
        public static string DGV_NGAYLAPHD = "ngaylaphd";
        public static string DGV_MANV = "manv";
        public static string DGV_TONGTIEN = "tongtien";
        public static string DGV_GHICHU = "ghichu";

        public static string DGV_DONGIA = "dongia";
        public static string DGV_MAHOADON = "mahoadon";
        public static string DGV_GIAMGIA = "giamgia";
        public static string DGV_THANHTIEN = "thanhtien";
        public static string DGV_MASP = "masp";
        public static string DGV_SOLUONG = "soluong";
        public static string DGV_SIZE = "size";

        public static string VAlUEMEMBER_CHUCVU = "MaChucVu";
        public static string DISPLAYMEMBER_CHUCVU = "TenChucVu";

        public static string DGV_NV_GIOITINH = "gioitinh";
        public static string DGV_NV_NAM = "Nam";
        public static string DGV_NV_NGAYSINH = "ngaysinh";
        public static string DGV_NV_CHUCVU = "chucvu";
        public static string DGV_NV_DIACHI = "diachi";
        public static string DGV_NV_EMAIL = "email";
        public static string DGV_NV_SDT = "sodienthoai";
        public static string DGV_NV_NGAYVAOLAM = "ngayvaolam";
        public static string DGV_NV_TENNV = "Tennv";
        public static string DGV_NV_MANV = "MaNV";


        public static string EDIT_NHANVIEN_FAILED = "Sửa nhân viên thất bại";
        public static string EDIT_NHANVIEN_SUCCESSFU = "Sửa nhân viên thành công";

        public static string ADD_NHANVIEN_FAILED = "Thêm nhân viên thất bại";
        public static string ADD_NHANVIEN_SUCCESSFU = "Thêm nhân viên thành công";

        public static string DEL_ADD_NHANVIEN_FAILED = "Xóa nhân viên thất bại";
        public static string DEL_NHANVIEN_SUCCESSFU = "Xóa nhân viên thành công";

        public static string YOU_WANNA_DEL_NHANVIEN = "Bạn có muốn xóa nhân viên";
        public static string PLS_INPUT_INFO_NHANVIEN = "Vui lòng nhập thông tin nhân viên";
        public static string PLS_INPUT_INFO_HOADON = "Vui lòng nhập thông tin hóa đơn";


        public static string REPORT_DT_EmbeddedResource_MONTH = "CuaHangTraSuaHKT.rptDoanhThuTheoThang.rdlc";
        public static string REPORT_DT_DataSources_MONTH = "DSDoanhThuTheoThang";
        public static string REPORT_DT_Parameters_MOTH = "paThang";
        public static string REPORT_DT_Parameters_YEAR = "paNam";
        public static string REPORT_DT_Parameters_MONEY_MONTH = "paDTTongTienThang";

        public static string REPORT_DT_EmbeddedResource_TO_DAY_FROM_DAY = "CuaHangTraSuaHKT.rptDoanhThuTuNgayDenNgay.rdlc";
        public static string REPORT_DT_DataSources_TO_DAY_FROM_DAY = "DSDoanhThuTuNgayDenNgay";
        public static string REPORT_DT_Parameters_TO_DAY = "paTuNgay";
        public static string REPORT_DT_Parameters_FROM_DAY = "paDenNgay";
        public static string REPORT_DT_Parameters_TOTAL_DT = "paTongDoanhThu";

        public static string REPORT_DT_EmbeddedResource_ALL_SP = "CuaHangTraSuaHKT.rptTatCaSanPham.rdlc";
        public static string REPORT_DT_DataSources_ALL_SP = "DSSanPham";

        public static string REPORT_DT_EmbeddedResource_SP_GROUP = "CuaHangTraSuaHKT.rptNhomSanPham.rdlc";
        public static string REPORT_DT_DataSources_SP_GROUP = "DSLoaiSanPham";

        public static string REPORT_DT_DataSources_SP_SUB = "DSSanPhamSub";
        public static string REPORT_DT_Parameters_MALOAISP = "paMaLoaiSP";
        
        public static string REPORT_DT_EmbeddedResource_LOAISP = "CuaHangTraSuaHKT.rptSanPhamTheoLoai.rdlc";
        public static string REPORT_DT_DataSources_LOAISP = "DSSanPhamTheoLoai";
        public static string REPORT_DT_Parameters_LOAISP = "paLoaiSanPham";

        public static string REPORT_DT_EmbeddedResource_SELL_S = "CuaHangTraSuaHKT.rptSanPhamDuocMuaChart.rdlc";
        public static string REPORT_DT_DataSources_SELL = "DSCTHDSanPham";

        public static string REPORT_DT_EmbeddedResource_CHUCVU = "CuaHangTraSuaHKT.rptNhanVienTheoChucVu.rdlc";
        public static string REPORT_DT_DataSources_CHUCVU = "DSNhanVienTheoChucVu";
        public static string REPORT_DT_Parameters_CHUCVU = "paChucVu";

        public static string DDMMYY = "dd/mm/yyyy";
        #endregion

        #region Hằng số

        public static int ONE = 1;
        public static int TWO = 2;
        public static int THREE = 3;
        public static int FOUR = 4;
        public static int FIVE = 5;
        public static int SIX = 6;
        public static int SEVEN = 7;
        public static int EIGHT = 8;
        public static int NINE = 9;
        public static int SECOND = 10;

        public static int ONE_HUNDRED = 100;


        public static int DEFAULT_COMBOBOX = -1;

        public static int DEFAULT_BAN_CLICK = 0;

        public static int COUNT_OBJECT_IN_LIST = 0;

        public static int NUMBER_DEFAULT_ZERO = 0;

        public static int NUMBER_DEFAULT_MINUS_ONE = -1;

        #endregion


    }
}
