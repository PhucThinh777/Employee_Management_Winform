using QuanLyNhanVien.Data;
using QuanLyNhanVien.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class FormNhanVien : Form
    {
        private Data.DBContectQLNV db = new Data.DBContectQLNV();

        public FormNhanVien(string taiKhoan, string hashedPassword, int maPhanQuyen)
        {
            InitializeComponent();

            // Load dữ liệu người dùng
            LoadDuLieuNguoiDung(taiKhoan, hashedPassword, maPhanQuyen);
        }

        private void LoadDuLieuNguoiDung(string taiKhoan, string hashedPassword, int maPhanQuyen)
        {
            List<Data.NguoiDung> nguoiDungList = db.NguoiDung
                .Where(nd => nd.TaiKhoan == taiKhoan && nd.MatKhau == hashedPassword && nd.MaPhanQuyen == maPhanQuyen)
                .ToList();

            List<NhanVienViewModel> viewModelList = new List<NhanVienViewModel>();

            foreach (var nguoiDung in nguoiDungList)
            {
                viewModelList.Add(new NhanVienViewModel
                {
                    TaiKhoan = nguoiDung.TaiKhoan,
                    TenNguoiDung = nguoiDung.TenNguoiDung,
                    MatKhau = nguoiDung.MatKhau,
                    Tuoi = nguoiDung.Tuoi,
                    SoDienThoai = nguoiDung.SoDienThoai,
                    DiaChi = nguoiDung.DiaChi,
                    Quyen = nguoiDung.PhanQuyen.Quyen,
                    TenChucVu = nguoiDung.ChucVu.TenChucVu,
                    TenKhuVuc = nguoiDung.KhuVuc.TenKhuVuc,
                    GioiTinh = nguoiDung.GioiTinh.LoaiGioiTinh,
                    LuongCoBan = nguoiDung.ChucVu.LuongCoBan,
                });
            }

            dgvNguoiDung.DataSource = viewModelList;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hỏi người dùng xem có chắc chắn muốn thoát không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn Đăng Xuất khỏi trang Nhân Viên?", "Xác nhận Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", hủy việc đóng form
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
