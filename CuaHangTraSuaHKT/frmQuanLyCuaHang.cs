using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
////using static System.Net.Mime.MediaTypeNames;
using DTO;
using BUS;
using System.Globalization;
using System.Threading;
using System.IO;

namespace CuaHangTraSuaHKT
{
    public partial class frmQuanLyCuaHang : Form
    {
        CultureInfo culture = new CultureInfo(Constants.CULTURE);

        public frmQuanLyCuaHang()
        {
            InitializeComponent();
            gunadgvDSMonDuocGoi.AutoGenerateColumns = false;
            //gunatxtDonGia.Enabled= false;
            //gunatxtTongTien.Enabled= false;
            gunacbbSize.Enabled= false;
            gunabtnChuyenBan.Enabled = false;

        }

        private void frmQuanLyCuaHang_Load(object sender, EventArgs e)
        {
            LoadBan();
            LoadKhuVuc();
            LoadDSMon();
        }

        private void LoadKhuVuc()
        {
            gunacbbKhuVuc.Items.Add(Constants.ALL);
            gunacbbKhuVuc.Items.Add(Constants.EREA);
            gunacbbKhuVuc.Items.Add(Constants.NAMEBAN);
            gunacbbKhuVuc.SelectedIndex = Constants.NUMBER_DEFAULT_ZERO;

        }

        public void LoadBan()
        {
            flpTatCaBan.Controls.Clear();

            List<BanDTO> list = BanBUS.Instance.LoadDSBan();

            gunacbbChuyenBan.DataSource = list;
            gunacbbChuyenBan.DisplayMember= Constants.DISPLAYMEMBERBAN;
            gunacbbChuyenBan.ValueMember= Constants.VAlUEMEMBERBAN;
            gunacbbChuyenBan.SelectedIndex= Constants.DEFAULT_COMBOBOX;

            uscBan[] myUS = new uscBan[list.Count];
            int i = Constants.NUMBER_DEFAULT_ZERO;
            foreach (BanDTO item in list)
            {
                myUS[i] = new uscBan();
                myUS[i].MaBan = item.MaBan;
                myUS[i].TenBan = item.TenBan;
                myUS[i].MaKhuVuc = item.MaKhuVuc;
                myUS[i].TrangThai = item.TrangThai;
                if (myUS[i].TrangThai)
                {
                    myUS[i].BackColor = Color.PowderBlue;
                }
                else
                {
                    myUS[i].BackColor = Color.Transparent;
                }
                flpTatCaBan.Controls.Add(myUS[i]);
                myUS[i].Click += new System.EventHandler(this.uscBan_Click);
                i++;
            }
        }

        int banclick = Constants.DEFAULT_BAN_CLICK;
        private void uscBan_Click(object sender, EventArgs e)
        {
          
            uscBan uscBan = (uscBan)sender;
            string mess = string.Format(Constants.YOU_WANNA_SELECT_BAN + " {0}", uscBan.TenBan);
            DialogResult result = MessageBox.Show(mess, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                guna2txtMaBan.Text = uscBan.MaBan.ToString();
                guna2txtTenBan.Text = uscBan.TenBan.ToString();

                banclick = uscBan.MaBan;

                lblTenBan.Text = uscBan.TenBan.ToString();

                //gunaXoa.Enabled = false;
                //gunaSua.Enabled = false;

                gunabtnChuyenBan.Enabled = true;

                int mahd = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick);
                if(mahd == Constants.NUMBER_DEFAULT_MINUS_ONE)
                {
                    lblMaHoaDon.Text = Constants.NOT_HD;
                }  
                else
                {
                    lblMaHoaDon.Text = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick).ToString();
                }

                ShowHoaDon(Convert.ToInt32(guna2txtMaBan.Text));
                LamMoi();
            }
        }

        public void ShowHoaDon(int maBan)
        {
            int mahd = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick);
            if (mahd == Constants.NUMBER_DEFAULT_MINUS_ONE)
            {
                lblMaHoaDon.Text = Constants.NOT_HD;
            }
            else
            {
                lblMaHoaDon.Text = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick).ToString();
            }
            int hd = HoaDonBUS.Instance.LayMaHoaDonCuaBan(maBan);

            gunadgvDSMonDuocGoi.DataSource = ChiTietHoaDonBUS.Instance.LayDSCTHDTheoMaHD(hd);
            ////Thread.CurrentThread.CurrentCulture = culture;
            if(HoaDonBUS.Instance.LayTongTienCuaHoaDon(hd) == Constants.NUMBER_DEFAULT_MINUS_ONE)
            {
                gunatxtTongTien.Text = Constants.NUMBER_DEFAULT_ZERO.ToString(Constants.C,culture);
                return;
            }
            gunatxtTongTien.Text = HoaDonBUS.Instance.LayTongTienCuaHoaDon(hd).ToString(Constants.C,culture);
     
        }

        private void LoadDSMon()
        {      
            flpTatCaMon.Controls.Clear();

            List<SanPhamDTO> listSP = new List<SanPhamDTO>();

            string tuKhoa = gunatxtTimKiemMon.Text;

            if (gunacbbTimKiemTheo.SelectedIndex == Constants.NUMBER_DEFAULT_ZERO)
            {

                listSP = SanPhamBUS.Instance.TimMaSanPham(tuKhoa);
            }
            else if (gunacbbTimKiemTheo.SelectedIndex == Constants.ONE)
            {
                listSP = SanPhamBUS.Instance.TimDanhMucSanPham(tuKhoa);
            }
            else if (gunacbbTimKiemTheo.SelectedIndex == Constants.TWO) 
            {
                listSP = SanPhamBUS.Instance.TimTenSanPham(tuKhoa);
            }
            else if (gunacbbTimKiemTheo.SelectedIndex == Constants.THREE)
            {
                listSP = SanPhamBUS.Instance.TimDonViTinhSanPham(tuKhoa);
            }

            if (string.IsNullOrEmpty(gunatxtTimKiemMon.Text))
            {
                listSP = SanPhamBUS.Instance.LayDSSanPham();
            }
    
            uscThongTinMon[] myUs = new uscThongTinMon[listSP.Count];

            int i = Constants.COUNT_OBJECT_IN_LIST;

            foreach(SanPhamDTO item in listSP)
            {
                myUs[i] = new uscThongTinMon();
                myUs[i].MaSP = item.masp;
                myUs[i].TenSP = item.tensanpham;
                myUs[i].MaDanhMuc = item.madanhmuc;
                //Bitmap bm = new Bitmap(item.anhsp);
                //myUs[i].Anhsp = bm;//
                MemoryStream mmr = new MemoryStream(item.anhsp) == null ? null : new MemoryStream(item.anhsp);
                Image img = Image.FromStream(mmr);

                myUs[i].Anhsp= img;
                myUs[i].DonViTinh = item.donvitinh;
                CultureInfo culture = new CultureInfo(Constants.CULTURE);
                myUs[i].DonGiaL = item.donGiaL.ToString(Constants.C, culture);
                myUs[i].DonGiaM = item.donGiaM.ToString(Constants.C, culture);
                myUs[i].TrangThai= item.trangthai;
  
                flpTatCaMon.Controls.Add(myUs[i]);
                myUs[i].Click += new System.EventHandler(this.uscMon_Click);
                i++;
            }
        }

        private void uscMon_Click(object sender, System.EventArgs e)
        {
            gunabtnThem.Enabled = true;
            gunacbbSize.Enabled = true;
            if (banclick != Constants.NUMBER_DEFAULT_ZERO)
            {
                uscThongTinMon uscThongTinMon = (uscThongTinMon)sender;
                gunatxtTenMon.Text = uscThongTinMon.TenSP;
                gunatxtDonGia.Text = uscThongTinMon.DonGiaM;
                giaL = float.Parse(uscThongTinMon.DonGiaL, NumberStyles.Currency, culture);
                giaM = float.Parse(uscThongTinMon.DonGiaM, NumberStyles.Currency, culture);
                
                //gunaSua.Enabled = false;
                //gunaXoa.Enabled = false;
                gunacbbSize.SelectedIndex = Constants.NUMBER_DEFAULT_ZERO;
                gunanbrSoLuong.Value = Constants.ONE;
            }
            else
            {
                MessageBox.Show(Constants.PLS_SELECT_BAN);
            }
        }

        public void LamMoi()
        {
            gunatxtDonGia.Clear();
            gunatxtTenMon.Clear();
            gunatxtDonGia.Clear();
            gunanbrSoLuong.Value = Constants.NUMBER_DEFAULT_ZERO;
            gunanbrGiamGia.Value = Constants.NUMBER_DEFAULT_ZERO;
            gunacbbSize.DisplayMember = " ";
        }

        private void gunabtnThem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.ADD_MON, Constants.NOTIFICATION, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(gunatxtTenMon.Text))
                {
                    MessageBox.Show(Constants.SELECT_MON, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
                if (string.IsNullOrEmpty(gunacbbSize.Text))
                {
                    MessageBox.Show(Constants.SELECT_SIZE, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                int mahd = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick);// lấy hóa đơn của bàn được chọn

                HoaDonDTO hd = new HoaDonDTO
                {
                    ngayLapLapHD = DateTime.Now,
                    MaNV = frmDangNhap.manv,
                    TongTien = Constants.NUMBER_DEFAULT_ZERO,
                    GhiChu = Constants.SPAKE,
                    MaBan = Convert.ToInt32(banclick),
                    TrangThai = true
                };

                float thanhtien = Convert.ToInt32(gunanbrSoLuong.Text) * float.Parse(gunatxtDonGia.Text, NumberStyles.Currency, culture);
                float dongia = float.Parse(gunatxtDonGia.Text, NumberStyles.Currency, culture);//chuyen thành kiểu f
                float giamgia = (float.Parse(gunanbrGiamGia.Text) / Constants.ONE_HUNDRED);

                ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO
                {
                    MaHD = Convert.ToInt32(mahd),//max
                    MaSP = SanPhamBUS.Instance.LayMaSPTheoTen(gunatxtTenMon.Text),
                    SoLuong = Convert.ToInt32(gunanbrSoLuong.Text),
                    DonGia = dongia,
                    GiamGia = Convert.ToInt32(gunanbrGiamGia.Text),
                    ThanhTien = thanhtien - (giamgia * thanhtien),
                    Size = gunacbbSize.Text,
                    TrangThai = true
                };

                if (mahd == Constants.NUMBER_DEFAULT_MINUS_ONE)
                {
                    BanBUS.Instance.CapNhatBanCoNguoiOrKhongCoNguoi(banclick, true);

                    HoaDonBUS.Instance.ThemHoaDon(hd);

                    cthd.MaHD = HoaDonBUS.Instance.LayHoaDonMax();//câp nhât hóa đơn max

                    ChiTietHoaDonBUS.Instance.ThemCTHD(cthd);
                }
                else
                {
                    if (ChiTietHoaDonBUS.Instance.checkCTHDGiong(cthd))
                    {
                        ChiTietHoaDonBUS.Instance.SuaCTHD(cthd);
                    }
                    else
                    {
                        ChiTietHoaDonBUS.Instance.ThemCTHD(cthd);
                    }
                }

                HoaDonBUS.Instance.capNhatTongTien(cthd.MaHD);

                ShowHoaDon(banclick);
                LoadBan();
                LamMoi();
            }    
         
            //kiem tra ban có hóa đơn chưa
            //nếu chưa thì tạo hóa đơn và thêm cthd
            //nếu có thì thêm cthd
        }

        private void gunabtnTimKiemKhuVuc_Click(object sender, EventArgs e)
        {
            flpTatCaBan.Controls.Clear();
            List<BanDTO> list = new List<BanDTO>();

            if (gunacbbKhuVuc.SelectedIndex == Constants.NUMBER_DEFAULT_ZERO)
            {
                LoadBan();
                return;
            }    
            if(gunacbbKhuVuc.SelectedIndex == Constants.ONE)
            {
                list = BanBUS.Instance.LoadDSBanTheoKhuVuc(gunatxtTimKiem.Text);
            }    
            if(gunacbbKhuVuc.SelectedIndex == Constants.TWO)
            {
                list = BanBUS.Instance.TimKiemBan(gunatxtTimKiem.Text);
            }    

            uscBan[] myUS = new uscBan[list.Count];
            int i = Constants.COUNT_OBJECT_IN_LIST;
            foreach (BanDTO item in list)
            {
                myUS[i] = new uscBan();
                myUS[i].MaBan = item.MaBan;
                myUS[i].TenBan = item.TenBan;
                myUS[i].MaKhuVuc = item.MaKhuVuc;
                myUS[i].TrangThai = item.TrangThai;
                if (myUS[i].TrangThai)
                {
                    myUS[i].BackColor = Color.PowderBlue;
                }
                else
                {
                    myUS[i].BackColor = Color.Transparent;
                }

                flpTatCaBan.Controls.Add(myUS[i]);
                myUS[i].Click += new System.EventHandler(this.uscBan_Click);
                i++;
            }
        }

        private void gunatxtTimKiemMon_TextChanged(object sender, EventArgs e)
        {
            LoadDSMon();
        }

        private void gunaSua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.EDIT_MON, Constants.NOTIFICATION, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
				if (mahdcellclick == Constants.NUMBER_DEFAULT_ZERO && maspcellclick == Constants.NUMBER_DEFAULT_ZERO &&  string.IsNullOrEmpty(gunacbbSize.Text))
				{
					MessageBox.Show(Constants.EDIT_NOT_CTHD, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
					return;
				}

				if (string.IsNullOrEmpty(gunatxtTenMon.Text))
                {
                    MessageBox.Show(Constants.SELECT_MON_ORDER_TO_EDIT, Constants.NOTIFICATION, MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    return;
                }    

                float thanhtien = Convert.ToInt32(gunanbrSoLuong.Text) * float.Parse(gunatxtDonGia.Text, NumberStyles.Currency, culture);
                float dongia = float.Parse(gunatxtDonGia.Text, NumberStyles.Currency, culture);//chuyen thành kiểu f
                float giamgia = (float.Parse(gunanbrGiamGia.Text) / Constants.ONE_HUNDRED);

                ChiTietHoaDonDTO cthd = new ChiTietHoaDonDTO
                {
                    MaHD = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick),
                    MaSP = SanPhamBUS.Instance.LayMaSPTheoTen(gunatxtTenMon.Text),
                    SoLuong = Convert.ToInt32(gunanbrSoLuong.Text),
                    DonGia = dongia,
                    GiamGia = Convert.ToInt32(gunanbrGiamGia.Text),
                    ThanhTien = thanhtien - (giamgia * thanhtien),
                    Size = gunacbbSize.Text,
                    TrangThai = true
                };

                if (ChiTietHoaDonBUS.Instance.SuaCTHDKhiDaThem(cthd))
                {
                    MessageBox.Show(Constants.EDIT_MON_SUCCESSFUL);
                }
                else
                {
                    MessageBox.Show(Constants.EDIT_MON_FAILED);
                }
                HoaDonBUS.Instance.capNhatTongTien(cthd.MaHD);

                LoadBan();
                ShowHoaDon(banclick);
                LamMoi();
            }    
        }

        private void gunabtnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.QUESTION_THANHTOAN, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                if(string.IsNullOrEmpty(guna2txtTenBan.Text))
                {
                    MessageBox.Show(Constants.PLS_SELECT_BAN, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                int mahd = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick);

                if(mahd == Constants.NUMBER_DEFAULT_MINUS_ONE)
                {
                    MessageBox.Show(Constants.BAN_SELECT_NOT_EXIST_HD, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                frmThanhToan frm = new frmThanhToan(this, banclick);
                frm.Show();

                //int mahd = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick);

                BanBUS.Instance.CapNhatBanCoNguoiOrKhongCoNguoi(banclick, false);//cập nhật bàn đã thah toán

                HoaDonBUS.Instance.CapNhatHoaDonDaThanhToan(mahd, false);//Thanh toán

                ChiTietHoaDonBUS.Instance.XoaALLCTHD(mahd, false);//Xóa cthd của theo mã hd của bàn

                LoadBan();
                ShowHoaDon(banclick);
                gunacbbSize.Enabled = false;
                LamMoi();
            }

        }
        int mahdcellclick = Constants.NUMBER_DEFAULT_ZERO;
        int maspcellclick = Constants.NUMBER_DEFAULT_ZERO;
        private void gunaXoa_Click(object sender, EventArgs e)
        {
   
            DialogResult result = MessageBox.Show(Constants.DEL_MON, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
				if (mahdcellclick == Constants.NUMBER_DEFAULT_ZERO && maspcellclick == Constants.NUMBER_DEFAULT_ZERO && gunacbbSize.Text.Equals(""))
				{
					MessageBox.Show(Constants.DEL_NOT_CTHD, Constants.NOTIFICATION, MessageBoxButtons.OK, MessageBoxIcon.Question);
					return;
				}

				int mahdBanHienTai = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick);//lấy mã hđ bàn hiện tại

                ChiTietHoaDonBUS.Instance.XoaCTHD(mahdcellclick, maspcellclick, gunacbbSize.Text);

                float dongia = float.Parse(gunatxtDonGia.Text, NumberStyles.Currency, culture);

                HoaDonBUS.Instance.capNhatTongTien(mahdcellclick);

                ShowHoaDon(banclick);
                LamMoi();

                if (ChiTietHoaDonBUS.Instance.KiemTraHoaDonCoCTHDKhong(mahdBanHienTai) == false)
                {
                    HoaDonBUS.Instance.XoaHoaDonKhiChuyenban(mahdBanHienTai);

                    BanBUS.Instance.CapNhatBanCoNguoiOrKhongCoNguoi(banclick, false);

					lblMaHoaDon.Text = "Chưa hóa đơn";

					LoadBan();
                }
            }
        }
 
       
        private void gunadgvDSMonDuocGoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            //gunaSua.Enabled = false;
            //gunaXoa.Enabled = false;
            if(index > Constants.NUMBER_DEFAULT_MINUS_ONE)
            {
                //gunaSua.Enabled = true;
                //gunaXoa.Enabled = true;

                gunatxtTenMon.Text = gunadgvDSMonDuocGoi.Rows[index].Cells[Constants.NUMBER_DEFAULT_ZERO].Value.ToString();
                gunanbrSoLuong.Text = gunadgvDSMonDuocGoi.Rows[index].Cells[Constants.ONE].Value.ToString();
                gunatxtDonGia.Text = float.Parse(gunadgvDSMonDuocGoi.Rows[index].Cells[Constants.TWO].Value.ToString()).ToString(Constants.C,culture);
                gunacbbSize.Text = gunadgvDSMonDuocGoi.Rows[index].Cells[Constants.THREE].Value.ToString();
                gunanbrGiamGia.Value = Convert.ToInt32(gunadgvDSMonDuocGoi.Rows[index].Cells[Constants.FOUR].Value.ToString());

                mahdcellclick = Convert.ToInt32(gunadgvDSMonDuocGoi.Rows[index].Cells[Constants.FIVE].Value.ToString());
                maspcellclick = Convert.ToInt32(gunadgvDSMonDuocGoi.Rows[index].Cells[Constants.SIX].Value.ToString());

                gunabtnThem.Enabled = false;
            }    
            gunacbbSize.Enabled = false;    
        }

        float giaM = Constants.NUMBER_DEFAULT_ZERO;
        float giaL = Constants.NUMBER_DEFAULT_ZERO;

        private void gunacbbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gunacbbSize.SelectedIndex == Constants.ONE)
            {
                gunatxtDonGia.Text = giaL.ToString(Constants.C,culture);
            }
            if (gunacbbSize.SelectedIndex == Constants.NUMBER_DEFAULT_ZERO)
            {
                gunatxtDonGia.Text = giaM.ToString(Constants.C, culture);
            }
        }


        private void gunabtnChuyenBan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Constants.YOU_WANNA_MOVE_BAN, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if(banclick == Constants.DEFAULT_BAN_CLICK)
                {
                    MessageBox.Show(Constants.PLS_SELECT_BAN, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    return;
                }

                int mahdBanHienTai = HoaDonBUS.Instance.LayMaHoaDonCuaBan(banclick);//lấy mã hđ bàn hiện tại

                if(mahdBanHienTai == Constants.NUMBER_DEFAULT_MINUS_ONE)
                {
                    MessageBox.Show(Constants.NOT_HD, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    return;
                }
               
                List<ChiTietHoaDonDTO> listCthd = ChiTietHoaDonBUS.Instance.LayDSCTHDTheoMaHD(mahdBanHienTai);//ds các chi tiết hoas đơn của bàn

                int mahdBanChuyen = HoaDonBUS.Instance.LayMaHoaDonCuaBan(Convert.ToInt32(gunacbbChuyenBan.SelectedValue));

                List<ChiTietHoaDonDTO> listCthd2 = ChiTietHoaDonBUS.Instance.LayDSCTHDTheoMaHD(mahdBanChuyen);//ds các chi tiết hoas đơn của bàn


                if (mahdBanHienTai == mahdBanChuyen)
                {
                    MessageBox.Show(Constants.YOU_NOT_MOVE_BAN_SAME, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    return;
                }

                if (mahdBanChuyen == Constants.NUMBER_DEFAULT_MINUS_ONE)
                {
                    if (HoaDonBUS.Instance.SuaHoaDonKhiChuyenban(mahdBanHienTai, Convert.ToInt32(gunacbbChuyenBan.SelectedValue)))
                    {
                        BanBUS.Instance.CapNhatBanCoNguoiOrKhongCoNguoi(banclick, false);
                       
                        BanBUS.Instance.CapNhatBanCoNguoiOrKhongCoNguoi(Convert.ToInt32(gunacbbChuyenBan.SelectedValue), true);
                  
                        LoadBan();
                        ShowHoaDon(mahdBanHienTai);
                        LamMoi();
                    }
                }
                else
                {
                    if (ChiTietHoaDonBUS.Instance.KTSuaALLCTHDCuaBanChuyen1(listCthd, listCthd2) == false)
                    {
                        MessageBox.Show(Constants.NOT_PASS_IS_CTHD_SAME, Constants.NOTIFICATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        return;
                    }

                    ChiTietHoaDonBUS.Instance.SuaALLCTHDCuaBanChuyen(mahdBanHienTai, mahdBanChuyen);

                    HoaDonBUS.Instance.XoaHoaDonKhiChuyenban(mahdBanHienTai);

                    HoaDonBUS.Instance.capNhatTongTien(mahdBanChuyen);

                    BanBUS.Instance.CapNhatBanCoNguoiOrKhongCoNguoi(banclick, false);

                    BanBUS.Instance.CapNhatBanCoNguoiOrKhongCoNguoi(Convert.ToInt32(gunacbbChuyenBan.SelectedValue), true);

                    LoadBan();
                    ShowHoaDon(mahdBanHienTai);
                    LamMoi();
                }
            }
       
        }

		private void gunatxtTenMon_TextChanged(object sender, EventArgs e)
		{

		}

		private void flpTatCaMon_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
