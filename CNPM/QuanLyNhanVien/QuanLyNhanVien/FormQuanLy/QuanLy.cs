using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhanVien.ViewModel;

namespace QuanLyNhanVien
{
    public partial class QuanLy : Form
    {
        private Data.DBContectQLNV db = new Data.DBContectQLNV();
        private int MaKhuVuc; // Biến lưu mã khu vực

        public QuanLy()
        {
            InitializeComponent();
        }

        public QuanLy(int maKhuVuc) : this()
        {
            MaKhuVuc = maKhuVuc;
            LoadDuLieuNguoiDung();
        }

        private void LoadDuLieuNguoiDung()
        {
            List<Data.NguoiDung> nguoiDungList = db.NguoiDung
                .Where(nd => nd.MaKhuVuc == MaKhuVuc)
                .ToList();

            List<NhanVienViewModel> viewModelList = new List<NhanVienViewModel>();

            foreach (var nguoiDung in nguoiDungList)
            {
                viewModelList.Add(new NhanVienViewModel
                {
                    TenNguoiDung = nguoiDung.TenNguoiDung,
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

            dgvQuanLy.DataSource = viewModelList;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hỏi người dùng xem có chắc chắn muốn thoát không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", hủy việc đóng form
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLy_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            // Hỏi người dùng xem có chắc chắn muốn thoát không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn Đăng Xuất khỏi trang Quản Lý?", "Xác nhận Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", hủy việc đóng form
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
