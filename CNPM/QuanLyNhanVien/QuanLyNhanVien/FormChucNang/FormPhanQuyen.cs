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
using System.Xml.Linq;

namespace QuanLyNhanVien
{
    public partial class FormPhanQuyen : Form
    {
        private Data.DBContectQLNV db = new Data.DBContectQLNV();
        public FormPhanQuyen()
        {
            InitializeComponent();
        }

        private void LoadDuLieuPhanQuyen()
        {
            //Lấy dữ liệu từ DB
            List<Data.PhanQuyen> DuLieuPhanQuyen = db.PhanQuyen.ToList();

            List<ViewModel.PhanQuyenViewModel> DuLieuPhanQuyenViewModel = new List<ViewModel.PhanQuyenViewModel>();

            DuLieuPhanQuyenViewModel = DuLieuPhanQuyen.Select(s => new ViewModel.PhanQuyenViewModel
            {
                MaPhanQuyen = s.MaPhanQuyen,
                Quyen = s.Quyen,
            }).ToList();

            // Sắp xếp danh sách giảm dần
            DuLieuPhanQuyenViewModel = DuLieuPhanQuyenViewModel.OrderByDescending(pq => pq.MaPhanQuyen).ToList();
            dgvPhanQuyen.DataSource = DuLieuPhanQuyenViewModel;

        }

        private void Chon()
        {
            int Chon = dgvPhanQuyen.CurrentCell.RowIndex;

            // Khởi tạo các biến
            var MaPhanQuyen = "";
            var TenQuyen = "";

            if (Chon >= 0 && Chon < dgvPhanQuyen.Rows.Count)
            {
                MaPhanQuyen = dgvPhanQuyen.Rows[Chon].Cells[0].Value?.ToString() ?? "";
                TenQuyen = dgvPhanQuyen.Rows[Chon].Cells[1].Value?.ToString() ?? "";
            }

            txtMaPhanQuyen.Text = MaPhanQuyen;
            txtPhanQuyen.Text = TenQuyen;
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
            txtMaPhanQuyen.Text = "";
            txtPhanQuyen.Text = "";
        }
        private void FormPhanQuyen_Load(object sender, EventArgs e)
        {
            LoadDuLieuPhanQuyen();
            setButton(true);
            grbChiTiet.Enabled = false;
        }

        private void dgvPhanQuyen_SelectionChanged(object sender, EventArgs e)
        {
            Chon();
        }
        private bool KiemQuyenHopLe(string quyen)
        {
            // Kiểm tra chuỗi không chứa số hay ký tự đặc biệt
            string pattern = @"^[\p{L}\s]+$";  // Chỉ chấp nhận chữ cái tiếng Việt và khoảng trắng
            // Kiểm tra sự khớp của chuỗi với biểu thức chính quy
            bool isMatch = Regex.IsMatch(quyen, pattern);

            return isMatch;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaHet();
            txtMaPhanQuyen.Enabled = false;
            dgvPhanQuyen.Enabled = false;
            setButton(false);
            grbChiTiet.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setButton(false);
            dgvPhanQuyen.Enabled = false;
            txtMaPhanQuyen.ReadOnly = true;
            grbChiTiet.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhanQuyen.Enabled == false)
            {
                if (string.IsNullOrEmpty(txtPhanQuyen.Text))
                {
                    MessageBox.Show("Tên quyền không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Data.PhanQuyen Add = new Data.PhanQuyen();
                    string quyen = txtPhanQuyen.Text;
                    if(quyen.Length > 10)
                    {
                        MessageBox.Show("Tên quyền không vượt quá 10 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPhanQuyen.Text = "";
                        return;
                    }
                    else if (!KiemQuyenHopLe(quyen))
                    {
                        MessageBox.Show("Tên quyền không được chứa ký tự số hay ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPhanQuyen.Text = "";
                        return;
                    }
                    else
                    {
                        Add.Quyen = txtPhanQuyen.Text;
                    }
                    db.PhanQuyen.Add(Add);
                    db.SaveChanges();
                    LoadDuLieuPhanQuyen();
                    Chon();
                    setButton(true);
                    dgvPhanQuyen.Enabled = true;
                    grbChiTiet.Enabled = false;
                    txtMaPhanQuyen.Enabled = true;
                    txtMaPhanQuyen.ReadOnly = false;
                    MessageBox.Show("Thêm thành công");
                }                
            }
            else if(txtMaPhanQuyen.ReadOnly == true)
            {
                if (string.IsNullOrEmpty(txtPhanQuyen.Text))
                {
                    MessageBox.Show("Tên quyền không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    byte maPhanQuyen;
                    if (byte.TryParse(txtMaPhanQuyen.Text, out maPhanQuyen))
                    {
                        Data.PhanQuyen Update = db.PhanQuyen.FirstOrDefault(s => s.MaPhanQuyen == maPhanQuyen);
                        if (Update != null)
                        {
                            string quyen = txtPhanQuyen.Text;
                            if (quyen.Length > 10)
                            {
                                MessageBox.Show("Tên quyền không vượt quá 10 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPhanQuyen.Text = "";
                                return;
                            }
                            else if (!KiemQuyenHopLe(quyen))
                            {
                                MessageBox.Show("Tên quyền không được chứa ký tự số hay ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtPhanQuyen.Text = "";
                                return;
                            }
                            else
                            {
                                Update.Quyen = txtPhanQuyen.Text;
                            }
                            db.Entry(Update).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            LoadDuLieuPhanQuyen();
                            Chon();
                            setButton(true);
                            MessageBox.Show("Sửa thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy MaPhanQuyen trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("MaPhanQuyen không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                setButton(true);
                dgvPhanQuyen.Enabled = true;
                grbChiTiet.Enabled = false;
                txtMaPhanQuyen.ReadOnly = false;
                txtMaPhanQuyen.Enabled = true;
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
            Chon();
            dgvPhanQuyen.Enabled = true;
            grbChiTiet.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phân quyền này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                byte pq = byte.Parse(txtMaPhanQuyen.Text);
                var Delete = db.PhanQuyen.FirstOrDefault(nv => nv.MaPhanQuyen == pq);
                if (Delete != null)
                {
                    db.PhanQuyen.Remove(Delete);
                    db.SaveChanges();
                    LoadDuLieuPhanQuyen();
                    dgvPhanQuyen.Enabled = true;
                    txtMaPhanQuyen.Enabled = true;
                    txtMaPhanQuyen.ReadOnly = false;
                    grbChiTiet.Enabled = false;
                    setButton(true);
                    Chon();


                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phân quyền có mã " + pq);
                }
            }
        }

        private void FormPhanQuyen_FormClosing(object sender, FormClosingEventArgs e)
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
