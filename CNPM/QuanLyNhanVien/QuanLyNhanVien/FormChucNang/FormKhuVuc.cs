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
    public partial class FormKhuVuc : Form
    {
        private Data.DBContectQLNV db = new Data.DBContectQLNV();
        public FormKhuVuc()
        {
            InitializeComponent();
        }
        private void LoadDuLieuKhuVuc()
        {
            //Lấy dữ liệu từ DB
            List<Data.KhuVuc> DuLieuKhuVuc = db.KhuVuc.ToList();

            List<ViewModel.KhuVucViewModel> DuLieuKhuVucViewModel = new List<ViewModel.KhuVucViewModel>();

            DuLieuKhuVucViewModel = DuLieuKhuVuc.Select(s => new ViewModel.KhuVucViewModel
            {
                MaKhuVuc = s.MaKhuVuc,
                TenKhuVuc = s.TenKhuVuc,
            }).ToList();

            // Sắp xếp danh sách giảm dần
            DuLieuKhuVucViewModel = DuLieuKhuVucViewModel.OrderByDescending(k => k.MaKhuVuc).ToList();
            dgvKhuVuc.DataSource = DuLieuKhuVucViewModel;

        }
        private void Chon()
        {
            int Chon = dgvKhuVuc.CurrentCell.RowIndex;

            // Khởi tạo các biến
            var MaKhuVuc = "";
            var TenKhuVuc = "";

            if (Chon >= 0 && Chon < dgvKhuVuc.Rows.Count)
            {
                MaKhuVuc = dgvKhuVuc.Rows[Chon].Cells[0].Value?.ToString() ?? "";
                TenKhuVuc = dgvKhuVuc.Rows[Chon].Cells[1].Value?.ToString() ?? "";
            }

            txtMaKhuVuc.Text = MaKhuVuc;
            txtTenKhuVuc.Text = TenKhuVuc;
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
            txtMaKhuVuc.Text = "";
            txtTenKhuVuc.Text = "";
        }

        private void FormKhuVuc_Load(object sender, EventArgs e)
        {
            LoadDuLieuKhuVuc();
            setButton(true);
            grbChiTiet.Enabled = false;
        }

        private void dgvKhuVuc_SelectionChanged(object sender, EventArgs e)
        {
            Chon();
        }
        private bool KiemKhuVucHopLe(string khu)
        {
            // Kiểm tra chuỗi không chứa số hay ký tự đặc biệt
            string pattern = @"^[\p{L}\s]+$";  // Chỉ chấp nhận chữ cái tiếng Việt và khoảng trắng
            // Kiểm tra sự khớp của chuỗi với biểu thức chính quy
            bool isMatch = Regex.IsMatch(khu, pattern);

            return isMatch;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaHet();
            txtMaKhuVuc.Enabled = false;
            dgvKhuVuc.Enabled = false;
            setButton(false);
            grbChiTiet.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setButton(false);
            dgvKhuVuc.Enabled = false;
            txtMaKhuVuc.ReadOnly = true;
            grbChiTiet.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhuVuc.Enabled == false)
            {
                if (string.IsNullOrEmpty(txtTenKhuVuc.Text))
                {
                    MessageBox.Show("Tên khu vực không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Data.KhuVuc Add = new Data.KhuVuc();
                    string khu = txtTenKhuVuc.Text;
                    if (khu.Length > 10)
                    {
                        MessageBox.Show("Tên khu vực không vượt quá 10 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenKhuVuc.Text = "";
                        return;
                    }
                    else if (!KiemKhuVucHopLe(khu))
                    {
                        MessageBox.Show("Tên khu vực không được chứa ký tự số hay ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenKhuVuc.Text = "";
                        return;
                    }
                    else
                    {
                        Add.TenKhuVuc = txtTenKhuVuc.Text;
                    }
                    Add.TenKhuVuc = txtTenKhuVuc.Text;
                    db.KhuVuc.Add(Add);
                    db.SaveChanges();
                    LoadDuLieuKhuVuc();
                    Chon();
                    setButton(true);
                    dgvKhuVuc.Enabled = true;
                    txtMaKhuVuc.Enabled = true;
                    txtMaKhuVuc.ReadOnly = false;
                    grbChiTiet.Enabled = false;
                    MessageBox.Show("Thêm thành công");
                }
            }
            else if (txtMaKhuVuc.ReadOnly == true)
            {
                if (string.IsNullOrEmpty(txtTenKhuVuc.Text))
                {
                    MessageBox.Show("Tên khu vực không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    byte maKhuVuc;
                    if (byte.TryParse(txtMaKhuVuc.Text, out maKhuVuc))
                    {
                        Data.KhuVuc Update = db.KhuVuc.FirstOrDefault(s => s.MaKhuVuc == maKhuVuc);
                        if (Update != null)
                        {
                            string khu = txtTenKhuVuc.Text;
                            if (khu.Length > 10)
                            {
                                MessageBox.Show("Tên khu vực không vượt quá 10 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtTenKhuVuc.Text = "";
                                return;
                            }
                            else if (!KiemKhuVucHopLe(khu))
                            {
                                MessageBox.Show("Tên khu vực không được chứa ký tự số hay ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtTenKhuVuc.Text = "";
                                return;
                            }
                            else
                            {
                                Update.TenKhuVuc = txtTenKhuVuc.Text;
                            }
                            db.Entry(Update).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            LoadDuLieuKhuVuc();
                            Chon();
                            MessageBox.Show("Sửa thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy MaKhuVuc trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("MaKhuVuc không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                setButton(true);
                dgvKhuVuc.Enabled = true;
                txtMaKhuVuc.ReadOnly = false;
                txtMaKhuVuc.Enabled = true;
                grbChiTiet.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
            Chon();
            dgvKhuVuc.Enabled = true;
            grbChiTiet.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khu vực này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                byte pq = byte.Parse(txtMaKhuVuc.Text);
                var Delete = db.KhuVuc.FirstOrDefault(nv => nv.MaKhuVuc == pq);
                if (Delete != null)
                {
                    db.KhuVuc.Remove(Delete);
                    db.SaveChanges();
                    LoadDuLieuKhuVuc();
                    dgvKhuVuc.Enabled = true;
                    txtMaKhuVuc.Enabled = true;
                    txtMaKhuVuc.ReadOnly = false;
                    grbChiTiet.Enabled=false;
                    setButton(true);
                    Chon();


                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khu vực có mã " + pq);
                }
            }
        }

        private void FormKhuVuc_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hỏi người dùng xem có chắc chắn muốn thoát không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", hủy việc đóng form
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
