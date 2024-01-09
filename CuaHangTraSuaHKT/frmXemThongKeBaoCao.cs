using Bus;
using BUS;
using DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangTraSuaHKT
{
    public partial class frmXemThongKeBaoCao : Form
    {
        CultureInfo culture = new CultureInfo(Constants.CULTURE);
        public frmXemThongKeBaoCao()
        {
            InitializeComponent();
        }

        private void frmXemThongKeBaoCao_Load(object sender, EventArgs e)
        {

          
        }

        public void ThongKeDoanhThuTheoThang(int thang, int nam)
        {
            List<HoaDonDTO> list = HoaDonBUS.Instance.DSHoaDonTheoDoanhThuTheoThang(thang,nam);
            this.rpvThongKeBaoCao.LocalReport.ReportEmbeddedResource = Constants.REPORT_DT_EmbeddedResource_MONTH;
            this.rpvThongKeBaoCao.LocalReport.DataSources.Add(new ReportDataSource(Constants.REPORT_DT_DataSources_MONTH, list));
            this.rpvThongKeBaoCao.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_MOTH, thang.ToString()));
            this.rpvThongKeBaoCao.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_YEAR, nam.ToString()));

            float tongtien = HoaDonBUS.Instance.ThongKeDoanhThuTheoThang(thang,nam);

            this.rpvThongKeBaoCao.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_MONEY_MONTH, tongtien.ToString(Constants.C, culture)));

            this.rpvThongKeBaoCao.RefreshReport();
        }

        public void ThongKeDoanhThuTuNgayDenNgay(DateTime tungay, DateTime denngay)
        {
            List<HoaDonDTO> list = HoaDonBUS.Instance.DSHoaDonTheoDoanhThuTuNgayDenNgay(tungay,denngay.AddDays(1));
            this.rpvThongKeBaoCao.LocalReport.ReportEmbeddedResource = Constants.REPORT_DT_EmbeddedResource_TO_DAY_FROM_DAY;
            this.rpvThongKeBaoCao.LocalReport.DataSources.Add(new ReportDataSource(Constants.REPORT_DT_DataSources_TO_DAY_FROM_DAY, list));
            this.rpvThongKeBaoCao.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_TO_DAY, tungay.ToString(Constants.DDMMYY)));
            this.rpvThongKeBaoCao.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_FROM_DAY, denngay.ToString(Constants.DDMMYY)));
            float tongtien = HoaDonBUS.Instance.ThongKeDoanhThu(tungay, denngay.AddDays(1));
            this.rpvThongKeBaoCao.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_TOTAL_DT, tongtien.ToString(Constants.C, culture)));

            this.rpvThongKeBaoCao.RefreshReport();
        }

        public void ThongKeTatCaSanPham()
        {
            List<SanPhamDTO> list = SanPhamBUS.Instance.LayDSSanPham();
            this.rpvThongKeBaoCao.LocalReport.ReportEmbeddedResource = Constants.REPORT_DT_EmbeddedResource_ALL_SP;
            this.rpvThongKeBaoCao.LocalReport.DataSources.Add(new ReportDataSource(Constants.REPORT_DT_DataSources_ALL_SP, list));
            this.rpvThongKeBaoCao.RefreshReport();
        }

        public void ThongKeSanPhamTheoNhom()
        {
            List<DanhMucDTO> listLoaiSP = DanhMucBUS.Istance.LayDSDanhMuc();
            this.rpvThongKeBaoCao.LocalReport.ReportEmbeddedResource = Constants.REPORT_DT_EmbeddedResource_SP_GROUP;

            this.rpvThongKeBaoCao.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;//tab

            this.rpvThongKeBaoCao.LocalReport.DataSources.Add(new ReportDataSource(Constants.REPORT_DT_DataSources_SP_GROUP, listLoaiSP));

            this.rpvThongKeBaoCao.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            //Lấy mã loại
            int maloai = int.Parse(e.Parameters[Constants.REPORT_DT_Parameters_MALOAISP].Values[0]);
            //đổ dữ liệu
            e.DataSources.Add(new ReportDataSource(Constants.REPORT_DT_DataSources_SP_SUB, SanPhamBUS.Instance.LayDSSanPhamTheoLoai(maloai)));
        }

        public void ThongKeSanPhamTheoLoai(int maloai, string tenloai)
        {
            List<SanPhamDTO> list = SanPhamBUS.Instance.LayDSSanPhamTheoLoai(maloai);
            this.rpvThongKeBaoCao.LocalReport.ReportEmbeddedResource = Constants.REPORT_DT_EmbeddedResource_LOAISP;
            this.rpvThongKeBaoCao.LocalReport.DataSources.Add(new ReportDataSource(Constants.REPORT_DT_DataSources_LOAISP, list));
            this.rpvThongKeBaoCao.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_LOAISP, tenloai));

            this.rpvThongKeBaoCao.RefreshReport();
        }

        public void ThongKeSanPhamBanChay()
        {
            List<ChiTietHoaDonDTO> list = ChiTietHoaDonBUS.Instance.LayDSCTHDThanhToan();
            this.rpvThongKeBaoCao.LocalReport.ReportEmbeddedResource = Constants.REPORT_DT_EmbeddedResource_SELL_S;
            this.rpvThongKeBaoCao.LocalReport.DataSources.Add(new ReportDataSource(Constants.REPORT_DT_DataSources_SELL, list));

            this.rpvThongKeBaoCao.RefreshReport();
        }

        public void ThongKeNhanVienTheoChucVu(int machuvu, string tenchucvu)
        {
            List<NhanVienDTO> list = NhanVienBUS.Instance.DSNhanVienTheoChucVu(machuvu);
            this.rpvThongKeBaoCao.LocalReport.ReportEmbeddedResource = Constants.REPORT_DT_EmbeddedResource_CHUCVU;
            this.rpvThongKeBaoCao.LocalReport.DataSources.Add(new ReportDataSource(Constants.REPORT_DT_DataSources_CHUCVU, list));
            this.rpvThongKeBaoCao.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_CHUCVU, tenchucvu));

            this.rpvThongKeBaoCao.RefreshReport();
        }
    }
}
