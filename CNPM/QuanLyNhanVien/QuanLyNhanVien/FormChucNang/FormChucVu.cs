using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class FormChucVu : Form
    {
        private Data.DBContectQLNV db = new Data.DBContectQLNV();
        public FormChucVu()
        {
            InitializeComponent();
        }
        private void LoadDuLieuChucVu()
        {
            //Lấy dữ liệu từ DB
            List<Data.ChucVu> DuLieuChucVu = db.ChucVu.ToList();

            List<ViewModel.ChucVuViewModel> DuLieuChucVuViewModel = new List<ViewModel.ChucVuViewModel>();

            DuLieuChucVuViewModel = DuLieuChucVu.Select(s => new ViewModel.ChucVuViewModel
            {
                MaChucVu = s.MaChucVu,
                TenChucVu = s.TenChucVu,
                LuongCoBan = s.LuongCoBan,
            }).ToList();

            // Sắp xếp danh sách giảm dần
            DuLieuChucVuViewModel = DuLieuChucVuViewModel.OrderByDescending(cv => cv.MaChucVu).ToList();

            dgvChucVu.DataSource = DuLieuChucVuViewModel;

        }
        private void FormChucVu_Load(object sender, EventArgs e)
        {
            LoadDuLieuChucVu();
            grbChiTiet.Enabled= false;
            setButton(true);
        }

        private void Chon()
        {
            int Chon = dgvChucVu.CurrentCell.RowIndex;

            // Khởi tạo các biến
            var MaChucVu = "";
            var TenChucVu = "";
            var LuongCoBan = "";

            if (Chon >= 0 && Chon < dgvChucVu.Rows.Count)
            {
                MaChucVu = dgvChucVu.Rows[Chon].Cells[0].Value?.ToString() ?? "";
                TenChucVu = dgvChucVu.Rows[Chon].Cells[1].Value?.ToString() ?? "";
                LuongCoBan = dgvChucVu.Rows[Chon].Cells[2].Value?.ToString() ?? "";
            }

            txtMaChucVu.Text = MaChucVu;
            txtTenChucVu.Text = TenChucVu;
            txtLuongCoBan.Text = LuongCoBan;
        }
        private void setButton(bool val)
        {
            btnThem.Enabled = val;
            btnXoa.Enabled = val;
            btnSua.Enabled = val;
            btnThoat.Enabled = val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
        }
        private void XoaHet()
        {
            txtMaChucVu.Text = "";
            txtTenChucVu.Text = "";
            txtLuongCoBan.Text = "";
        }

        private bool KiemTraChucVuHopLe(string chucVu)
        {
            // Kiểm tra chuỗi không chứa số hay ký tự đặc biệt
            string pattern = @"^[\p{L}\s]+$";  // Chỉ chấp nhận chữ cái tiếng Việt và khoảng trắng
            // Kiểm tra sự khớp của chuỗi với biểu thức chính quy
            bool isMatch = Regex.IsMatch(chucVu, pattern);

            return isMatch;
        }
        private bool KiemTraDinhDangLuong(string luong)
        {
            // Kiểm tra độ dài của Lương
            if (luong.Length > 9 || luong.Length < 4)
            {
                return false;
            }

            // Kiểm tra xem lương chỉ chứa số
            foreach (char c in luong)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
        private void dgvChucVu_SelectionChanged(object sender, EventArgs e)
        {
            Chon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaHet();
            grbChiTiet.Enabled = true;
            txtMaChucVu.Enabled = false;
            dgvChucVu.Enabled = false;
            setButton(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            grbChiTiet.Enabled = true;
            setButton(false);
            dgvChucVu.Enabled = false;
            txtMaChucVu.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Hàm thêm
            if (txtMaChucVu.Enabled == false)
            {
                // Kiểm tra xem lương hoặc tên chức vụ có đang để trống
                if (string.IsNullOrEmpty(txtTenChucVu.Text) ||
                    string.IsNullOrEmpty(txtLuongCoBan.Text)){
                    MessageBox.Show("Tên chức vụ hoặc Lương cơ bản không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Data.ChucVu Add = new Data.ChucVu();
                    string tenChucVu = txtTenChucVu.Text;
                    // Kiểm tra xem tên chức vụ có hợp lệ
                    if (tenChucVu.Length > 15)
                    {
                        MessageBox.Show("Tên chức không vượt quá 15 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenChucVu.Text = "";
                        return;
                    }
                    else if (!KiemTraChucVuHopLe(tenChucVu))
                    {
                        MessageBox.Show("Tên chức vụ không chứa ký tự đặc biệt hoặc số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenChucVu.Text = "";
                        return;
                    }
                    else
                    {
                        Add.TenChucVu = txtTenChucVu.Text;
                    }

                    // Kiểm tra xem lương có hợp lệ
                    string luongCoBan = txtLuongCoBan.Text;
                    if (!KiemTraDinhDangLuong(luongCoBan)){
                        MessageBox.Show("Lương cơ bản phải đúng định dạng số và nằm trong khoảng quy định 1000đ đến 999.999.999đ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLuongCoBan.Text = "";
                        return;
                    }
                    else
                    {
                        Add.LuongCoBan = int.Parse(txtLuongCoBan.Text);
                    }

                    // Thêm chức vụ vào db
                    db.ChucVu.Add(Add);
                    db.SaveChanges();
                    LoadDuLieuChucVu();
                    Chon();
                    setButton(true);
                    dgvChucVu.Enabled = true;
                    grbChiTiet.Enabled = false;
                    txtMaChucVu.Enabled = true;
                    txtMaChucVu.ReadOnly = false;
                    MessageBox.Show("Thêm thành công");
                }
                
            }
            // Hàm Sửa
            else if (txtMaChucVu.ReadOnly == true)
            {
                // Kiểm tra xem lương hoặc tên chức vụ có đang để trống
                if (string.IsNullOrEmpty(txtTenChucVu.Text) ||
                    string.IsNullOrEmpty(txtLuongCoBan.Text))
                {
                    MessageBox.Show("Tên chức vụ hoặc Lương cơ bản không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    byte maChucVu;
                    if (byte.TryParse(txtMaChucVu.Text, out maChucVu))
                    {
                        Data.ChucVu Update = db.ChucVu.FirstOrDefault(s => s.MaChucVu == maChucVu);
                        if (Update != null)
                        {
                            string tenChucVu = txtTenChucVu.Text;
                            // Kiểm tra xem tên chức vụ có hợp lệ
                            if (tenChucVu.Length > 15)
                            {
                                MessageBox.Show("Tên chức không vượt quá 15 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtTenChucVu.Text = "";
                                return;
                            }
                            else if (!KiemTraChucVuHopLe(tenChucVu))
                            {
                                MessageBox.Show("Tên chức vụ không chứa ký tự đặc biệt hoặc số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtTenChucVu.Text = "";
                                return;
                            }
                            else
                            {
                                Update.TenChucVu = txtTenChucVu.Text;
                            }

                            // Kiểm tra xem lương có hợp lệ
                            string luongCoBan = txtLuongCoBan.Text;
                            if (!KiemTraDinhDangLuong(luongCoBan))
                            {
                                MessageBox.Show("Lương cơ bản phải đúng định dạng số và nằm trong khoảng quy định 1000đ đến 999.999.999đ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLuongCoBan.Text = "";
                                return;
                            }
                            else
                            {
                                Update.LuongCoBan = int.Parse(txtLuongCoBan.Text);
                            }

                            db.Entry(Update).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            LoadDuLieuChucVu();
                            Chon();
                            grbChiTiet.Enabled = false;
                            MessageBox.Show("Sửa thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy MaChucVu trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("MaChucVu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            setButton(true);
            dgvChucVu.Enabled = true;
            txtMaChucVu.ReadOnly = false;
            txtMaChucVu.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
            Chon();
            grbChiTiet.Enabled = false;
            dgvChucVu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chức vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                byte pq = byte.Parse(txtMaChucVu.Text);
                var Delete = db.ChucVu.FirstOrDefault(nv => nv.MaChucVu == pq);
                if (Delete != null)
                {
                    db.ChucVu.Remove(Delete);
                    db.SaveChanges();
                    LoadDuLieuChucVu();
                    dgvChucVu.Enabled = true;
                    txtMaChucVu.Enabled = true;
                    txtMaChucVu.ReadOnly = false;
                    grbChiTiet.Enabled = false;
                    Chon();


                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chức vụ có mã " + pq);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChucVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hỏi người dùng xem có chắc chắn muốn thoát không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", hủy việc đóng form
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
