using QuanLyNhanVien.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class DangKy : Form
    {
        private DBContectQLNV db = new DBContectQLNV();
        public DangKy()
        {
            InitializeComponent();
        }

        private void LoadCombobox()
        {
            var DSKhuVuc = db.KhuVuc.ToList();
            var DSChucVu = db.ChucVu.ToList();
            var DSPhanQuyen = db.PhanQuyen.ToList();
            var DSGioiTinh = db.GioiTinh.ToList();


            cbbKhuVuc.DataSource = DSKhuVuc;
            cbbKhuVuc.DisplayMember = "TenKhuVuc";
            cbbKhuVuc.ValueMember = "MaKhuVuc";

            // Lọc và hiển thị các Chức vụ với MaChucVu bắt đầu từ số 3
            var chucVuData = DSChucVu.Where(chucVu => chucVu.MaChucVu >= 3).ToList();

            cbbChucVu.DataSource = chucVuData;
            cbbChucVu.DisplayMember = "TenChucVu";
            cbbChucVu.ValueMember = "MaChucVu";

            cbbGioiTinh.DataSource = DSGioiTinh;
            cbbGioiTinh.DisplayMember = "LoaiGioiTinh";
            cbbGioiTinh.ValueMember = "MaGioiTinh";

       
        }
        private bool IsUsernameExists(string username)
        {
            string connectionString = "Data Source=DESKTOP-MKJK1H7\\SQLEXPRESS;Initial Catalog=QuanLyNhanVien;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM NguoiDung WHERE TaiKhoan = @TaiKhoan";

                    using (SqlCommand command = new SqlCommand(checkQuery, connection))
                    {
                        command.Parameters.AddWithValue("TaiKhoan", username);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra tên đăng nhập: " + ex.Message);
                return true; // Trả về true để đảm bảo không cho đăng ký khi có lỗi xảy ra.
            }
        }

        private string GetSHA256Hash(string MatKhau)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Chuyển đổi mật khẩu thành mảng byte
                byte[] inputBytes = Encoding.UTF8.GetBytes(MatKhau);

                // Mã hóa mảng byte
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Chuyển đổi kết quả mã hóa thành dạng hex string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private bool IsSpecialChar(char c)
        {
            return !char.IsLetterOrDigit(c);
        }


        private void DangKy_Load(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            // Hàm thêm ở đây
            Data.NguoiDung nguoiDungThem = new Data.NguoiDung();

            // Kiểm tra tài khoản
            string username = txtTenTaiKhoan.Text;
            if (username.Length < 5 || username.Length > 16)
            {
                MessageBox.Show("Tên đăng nhập phải có từ 5 đến 16 ký tự.");
                return;
            }
            else
            {
                // Kiểm tra tên đăng nhập trùng trong cơ sở dữ liệu
                if (IsUsernameExists(username))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác.");
                    return;
                }
                else
                {
                    nguoiDungThem.TaiKhoan = txtTenTaiKhoan.Text;
                }

            }
            // Kiểm tra họ tên
            string fullName = txtHoTen.Text;
            if (string.IsNullOrWhiteSpace(fullName) || fullName.Length > 35 || !Regex.IsMatch(fullName, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Họ tên không hợp lệ.");
                return;
            }
            else
            {
                nguoiDungThem.TenNguoiDung = txtHoTen.Text;
            }

            // Kiểm tra mật khẩu
            string password = txtMatKhau.Text;
            if (password.Length < 6 || password.Length > 64 ||
                !password.Any(char.IsUpper) || // ít nhất 1 chữ hoa
                !password.Any(char.IsLower) || // ít nhất 1 chữ thường
                !password.Any(char.IsDigit) || // ít nhất 1 số
                !password.Any(IsSpecialChar)) // ít nhất 1 ký tự đặc biệt
            {
                MessageBox.Show("Mật khẩu phải có từ 6 đến 64 ký tự và phải chứa ít nhất: 1 chữ hoa,1 chữ thường,1 ký số,1 ký tự đặc biệt ");
                return;
            }
            else
            {
                // Mã hóa mật khẩu
                string matKhau = txtMatKhau.Text;
                string hashedPassword = GetSHA256Hash(matKhau);
                nguoiDungThem.MatKhau = hashedPassword;
            }

            // Kiểm tra số điện thoại
            string phoneNumber = txtSDT.Text;
            if (phoneNumber.Length != 10 || !phoneNumber.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.");
                return;
            }
            else
            {
                nguoiDungThem.SoDienThoai = txtSDT.Text;
            }

            // Kiểm tra địa chỉ
            string address = txtDiaChi.Text;
            if (address.Length > 150)
            {
                MessageBox.Show("Địa chỉ không được quá 150 ký tự.");
                return;
            }
            else
            {
                nguoiDungThem.DiaChi = txtDiaChi.Text;
            }

            // Kiểm tra tuổi
            if (!int.TryParse(txtTuoi.Text, out int age) || age < 16 || age > 100)
            {
                MessageBox.Show("Tuổi không hợp lệ.");
                return;
            }
            else
            {
                nguoiDungThem.Tuoi = int.Parse(txtTuoi.Text);
            }


            GioiTinh gioiTinh = cbbGioiTinh.SelectedItem as GioiTinh;
            nguoiDungThem.MaGioiTinh = gioiTinh.MaGioiTinh;

            KhuVuc khuVuc = cbbKhuVuc.SelectedItem as KhuVuc;
            nguoiDungThem.MaKhuVuc = khuVuc.MaKhuVuc;

            ChucVu chucVu = cbbChucVu.SelectedItem as ChucVu;
            nguoiDungThem.MaChucVu = chucVu.MaChucVu;

            nguoiDungThem.MaPhanQuyen = 3;

            db.NguoiDung.Add(nguoiDungThem);
            db.SaveChanges();
            MessageBox.Show("Tạo tài khoản thành công");

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hỏi người dùng xem có chắc chắn muốn thoát không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi form Đăng Ký?", "Xác nhận Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", hủy việc đóng form
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
