using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class frmDangNhap : Form
    {
        // Chuỗi kết nối Database
        private string connectionString = "Data Source=DESKTOP-MKJK1H7\\SQLEXPRESS;Initial Catalog=QuanLyNhanVien;Integrated Security=True";

        // Kiểm tra tài khoản
        private bool KiemTraTaiKhoan(string TaiKhoan, string MatKhau, int MaPhanQuyen)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM NguoiDung WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau AND MaPhanQuyen = @MaPhanQuyen";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                command.Parameters.AddWithValue("@MatKhau", MatKhau);
                command.Parameters.AddWithValue("@MaPhanQuyen", MaPhanQuyen);

                int count = (int)command.ExecuteScalar();

                // Trả về true nếu đúng, false nếu sai
                return count > 0;
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

        private int LayMaKhuVucTuTaiKhoan(string TaiKhoan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MaKhuVuc FROM NguoiDung WHERE TaiKhoan = @TaiKhoan";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);

                object result = command.ExecuteScalar();

                // Kiểm tra nếu result null hoặc không phải kiểu int thì trả về giá trị mặc định là 0
                return result != null && int.TryParse(result.ToString(), out int maKhuVuc) ? maKhuVuc : 0;
            }
        }

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Gán giá trị lấy từ textbox cho biến
            string TaiKhoan = txtTaiKhoan.Text;
            string MatKhau = txtMatKhau.Text;
            string hashedPassword = GetSHA256Hash(MatKhau);
            int MaPhanQuyen = 0; // Khởi tạo biến MaPhanQuyen

            if (KiemTraTaiKhoan(TaiKhoan, hashedPassword, 1))
            {
                MessageBox.Show("Đăng nhập thành công!");
                GiaoDienAdmin admin = new GiaoDienAdmin();
                admin.ShowDialog();
            }
            else if (KiemTraTaiKhoan(TaiKhoan, hashedPassword, 2))
            {
                MessageBox.Show("Đăng nhập thành công!");
                // Lấy mã khu vực để hiển thị ra các nhân viên tương ứng
                int maKhuVuc = LayMaKhuVucTuTaiKhoan(TaiKhoan);
                QuanLy ql = new QuanLy(maKhuVuc);
                ql.ShowDialog();
            }
            else if (KiemTraTaiKhoan(TaiKhoan, hashedPassword, 3))
            {
                MessageBox.Show("Đăng nhập thành công!");
                MaPhanQuyen = 3; // Gán mã phân quyền của nhân viên
                FormNhanVien nv = new FormNhanVien(TaiKhoan, hashedPassword, MaPhanQuyen);
                nv.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Nếu đăng nhập không thành công, thoát khỏi sự kiện
            }

            // Tạo form NhanVien và truyền thông tin người dùng
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !checkMatKhau.Checked;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Mở form đăng ký
            DangKy dangky = new DangKy();
            dangky.ShowDialog();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hỏi người dùng xem có chắc chắn muốn thoát không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi form Đăng Nhập?", "Xác nhận Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", hủy việc đóng form
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

