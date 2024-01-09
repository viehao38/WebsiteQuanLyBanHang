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
using BUS;
using DTO;
using Microsoft.Reporting.WinForms;

namespace CuaHangTraSuaHKT
{
    public partial class frmPhieuThanhToan : Form
    {
        CultureInfo culture = new CultureInfo(Constants.CULTURE);
        public frmPhieuThanhToan()
        {
            InitializeComponent();
        }

        private void frmTToan_Load(object sender, EventArgs e)
        {

        }

        public void LoadDSCTHDCuaHoaDon(int mahd, string tennv, float tienkhachdua)
        {
            List<ChiTietHoaDonDTO> list = ChiTietHoaDonBUS.Instance.LayDSCTHDTheoMaHD(mahd, false);

            this.rpvThanhToan.LocalReport.ReportEmbeddedResource = Constants.REPORT_DT_EmbeddedResource_PHIEUHD;

            this.rpvThanhToan.LocalReport.DataSources.Add(new ReportDataSource(Constants.REPORT_DT_DataSources_PHIEUHD, list));

            this.rpvThanhToan.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_NGAYLAP, DateTime.Now.ToString()));

            this.rpvThanhToan.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_NGUOILAP, tennv));

            string tongtien = HoaDonBUS.Instance.LayTongTienCuaHoaDon(mahd).ToString(Constants.C, culture);

            string tienkhach = tienkhachdua.ToString(Constants.C, culture);

            float tientrakhach = tienkhachdua - (float)HoaDonBUS.Instance.LayTongTienCuaHoaDon(mahd);

            string tientra = tientrakhach.ToString(Constants.C, culture);

            this.rpvThanhToan.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_TOTAL_MONEY, tongtien.ToString()));

            this.rpvThanhToan.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_TIENTRAKHACH, tientra.ToString()));

            this.rpvThanhToan.LocalReport.SetParameters(new ReportParameter(Constants.REPORT_DT_Parameters_TIENKHACHDUA, tienkhach.ToString()));

            this.rpvThanhToan.RefreshReport();

        }
    }
}
