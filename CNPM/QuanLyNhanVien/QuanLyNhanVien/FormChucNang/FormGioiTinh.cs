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
    public partial class FormGioiTinh : Form
    {
        private Data.DBContectQLNV db = new Data.DBContectQLNV();
        public FormGioiTinh()
        {
            InitializeComponent();
        }
        private void LoadDuLieuGioiTinh()
        {
            //Lấy dữ liệu từ DB
            List<Data.GioiTinh> DuLieuGioiTinh = db.GioiTinh.ToList();

            List<ViewModel.GioiTinhViewModel> DuLieuGioiTinhViewModel = new List<ViewModel.GioiTinhViewModel>();

            DuLieuGioiTinhViewModel = DuLieuGioiTinh.Select(s => new ViewModel.GioiTinhViewModel
            {
                MaGioiTinh = s.MaGioiTinh,
                LoaiGioiTinh = s.LoaiGioiTinh,
                DoTuoiDiLam = s.DoTuoiDiLam,
                DoTuoiNghiHuu = s.DoTuoiNghiHuu,
            }).ToList();


            // Sắp xếp danh sách giảm dần
            DuLieuGioiTinhViewModel = DuLieuGioiTinhViewModel.OrderByDescending(gt => gt.MaGioiTinh).ToList();

            dgvGioiTinh.DataSource = DuLieuGioiTinhViewModel;

        }
        private void FormGioiTinh_Load(object sender, EventArgs e)
        {
            LoadDuLieuGioiTinh();
            grbChiTiet.Enabled = false;
            setButton(true);
        }
        private void Chon()
        {
            int Chon = dgvGioiTinh.CurrentCell.RowIndex;

            // Khởi tạo các biến
            var MaGioiTinh = "";
            var LoaiGioiTinh = "";
            var TuoiDiLam = "";
            var TuoiNghiHuu = "";

            if (Chon >= 0 && Chon < dgvGioiTinh.Rows.Count)
            {
                MaGioiTinh = dgvGioiTinh.Rows[Chon].Cells[0].Value?.ToString() ?? "";
                LoaiGioiTinh = dgvGioiTinh.Rows[Chon].Cells[1].Value?.ToString() ?? "";
                TuoiDiLam = dgvGioiTinh.Rows[Chon].Cells[2].Value?.ToString() ?? "";
                TuoiNghiHuu = dgvGioiTinh.Rows[Chon].Cells[3].Value?.ToString() ?? "";
            }

            txtMaGioiTinh.Text = MaGioiTinh;
            txtLoaiGioiTinh.Text = LoaiGioiTinh;
            txtTuoiDiLam.Text = TuoiDiLam;
            txtTuoiNghiHuu.Text = TuoiNghiHuu;
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
        private bool KiemTraGioiTinhHopLe(string gioiTinh)
        {
            // Kiểm tra chuỗi không chứa số hay ký tự đặc biệt
            string pattern = @"^[\p{L}\s]+$";  // Chỉ chấp nhận chữ cái tiếng Việt và khoảng trắng
            // Kiểm tra sự khớp của chuỗi với biểu thức chính quy
            bool isMatch = Regex.IsMatch(gioiTinh, pattern);

            return isMatch;
        }
        private bool KiemTraTuoiDiLam(int tuoiDiLam, int tuoiNghiHuu)
        {
            // Kiểm tra tuổi đi làm
            if (tuoiDiLam > tuoiNghiHuu || tuoiDiLam < 16)
            {
                MessageBox.Show("Tuổi đi làm phải nhỏ hơn tuổi nghỉ hưu và không nhỏ hơn 16 tuổi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool KiemTraDinhDangTuoiDiLam(string chuoiDiLam)
        {
            foreach (char c in chuoiDiLam)
            {
                if (!Char.IsDigit(c))
                {
                    MessageBox.Show("Tuổi đi làm phải là kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }else if(chuoiDiLam.Length > 3)
                {

                    MessageBox.Show("Tuổi đi làm không vượt quá 3 số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;

        }

        private bool KiemTraTuoiNghiHuu(int tuoiDiLam, int tuoiNghiHuu)
        {
            // Kiểm tra tuổi nghỉ hưu
            if (tuoiNghiHuu < tuoiDiLam || tuoiNghiHuu > 70)
            {
                MessageBox.Show("Tuổi nghỉ hưu phải lớn hơn tuổi đi làm và không lớn hơn 70 tuổi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool KiemTraDinhDangTuoiNghiHuu(string chuoiNghiHuu)
        {
            foreach (char c in chuoiNghiHuu)
            {
                if (!Char.IsDigit(c))
                {
                    MessageBox.Show("Tuổi nghỉ hưu phải là kiểu số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (chuoiNghiHuu.Length > 3)
                {

                    MessageBox.Show("Tuổi nghỉ hưu không vượt quá 3 số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;

        }

        private void XoaHet()
        {
            txtMaGioiTinh.Text = "";
            txtLoaiGioiTinh.Text = "";
            txtTuoiDiLam.Text = "";
            txtTuoiNghiHuu.Text = "";
        }

        private void dgvGioiTinh_SelectionChanged(object sender, EventArgs e)
        {
            Chon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XoaHet();
            txtMaGioiTinh.Enabled = false;
            dgvGioiTinh.Enabled = false;
            grbChiTiet.Enabled = true;
            setButton(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setButton(false);
            dgvGioiTinh.Enabled = false;
            txtMaGioiTinh.ReadOnly = true;
            grbChiTiet.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaGioiTinh.Enabled == false)
            {
                if (string.IsNullOrEmpty(txtTuoiDiLam.Text)||
                    string.IsNullOrEmpty(txtTuoiNghiHuu.Text)||
                    string.IsNullOrEmpty(txtLoaiGioiTinh.Text)
                    )
                {
                    MessageBox.Show("Không được để trống ô nhập liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Data.GioiTinh Add = new Data.GioiTinh();
                    Add.LoaiGioiTinh = txtLoaiGioiTinh.Text;

                    string chuoiDiLam = txtTuoiDiLam.Text;
                    string chuoiNghiHuu = txtTuoiNghiHuu.Text;

                    // Tuổi đi làm
                    if (!KiemTraDinhDangTuoiDiLam(chuoiDiLam))
                    {
                        txtTuoiDiLam.Text = "";
                        return;
                    }
                    else
                    {
                        if (!KiemTraDinhDangTuoiNghiHuu(chuoiNghiHuu))
                        {
                            txtTuoiNghiHuu.Text = "";
                            return;
                        }
                        else
                        {
                            int tuoiDiLam = int.Parse(txtTuoiDiLam.Text);
                            int tuoiNghiHuu = int.Parse(txtTuoiNghiHuu.Text);

                            // Kiểm tra tuổi đi làm
                            if (!KiemTraTuoiDiLam(tuoiDiLam, tuoiNghiHuu))
                            {
                                txtTuoiDiLam.Text = "";
                                return;
                            }
                            else
                            {
                                Add.DoTuoiDiLam = byte.Parse(txtTuoiDiLam.Text);
                            }
                        }
                    }

                    // Tuổi nghỉ hưu
                    if (!KiemTraDinhDangTuoiNghiHuu(chuoiNghiHuu))
                    {
                        txtTuoiNghiHuu.Text = "";
                        return;
                    }
                    else
                    {
                        if (!KiemTraDinhDangTuoiDiLam(chuoiDiLam))
                        {
                            txtTuoiDiLam.Text = "";
                            return;
                        }
                        else
                        {
                            int tuoiDiLam = int.Parse(txtTuoiDiLam.Text);
                            int tuoiNghiHuu = int.Parse(txtTuoiNghiHuu.Text);
                            // Kiểm tra tuổi nghỉ hưu
                            if (!KiemTraTuoiNghiHuu(tuoiDiLam, tuoiNghiHuu))
                            {
                                txtTuoiNghiHuu.Text = "";
                                return;
                            }
                            else
                            {
                                Add.DoTuoiNghiHuu = byte.Parse(txtTuoiNghiHuu.Text);
                            }
                        }
                    }
                    
                   
                    // Kiểm tra giới tính
                    string gioiTinh = txtLoaiGioiTinh.Text;
                    if(gioiTinh.Length > 4)
                    {
                        MessageBox.Show("Giới tính không vượt quá 4 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLoaiGioiTinh.Text = "";
                        return;
                    }
                    else if (!KiemTraGioiTinhHopLe(gioiTinh))
                    {
                        MessageBox.Show("Giới tính không chứa số hoặc ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLoaiGioiTinh.Text = "";
                        return;
                    }
                    else
                    {
                        //db.GioiTinh.Add(Add);
                        Add.LoaiGioiTinh = txtLoaiGioiTinh.Text;
                    }

                    db.GioiTinh.Add(Add);
                    db.SaveChanges();
                    LoadDuLieuGioiTinh();
                    Chon();
                    setButton(true);
                    dgvGioiTinh.Enabled = true;
                    txtMaGioiTinh.Enabled = true;
                    txtMaGioiTinh.ReadOnly = false;
                    MessageBox.Show("Thêm thành công");
                }

            }

            // Hàm sửa
            else if (txtMaGioiTinh.ReadOnly == true)
            {
                if (string.IsNullOrEmpty(txtTuoiDiLam.Text) ||
                    string.IsNullOrEmpty(txtTuoiNghiHuu.Text) ||
                    string.IsNullOrEmpty(txtLoaiGioiTinh.Text)
                    )
                {
                    MessageBox.Show("Không được để trống ô nhập liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    byte maGioiTinh;
                    if (byte.TryParse(txtMaGioiTinh.Text, out maGioiTinh))
                    {
                        Data.GioiTinh Update = db.GioiTinh.FirstOrDefault(s => s.MaGioiTinh == maGioiTinh);
                        if (Update != null)
                        {
                            string chuoiDiLam = txtTuoiDiLam.Text;
                            string chuoiNghiHuu = txtTuoiNghiHuu.Text;

                            // Tuổi đi làm
                            if (!KiemTraDinhDangTuoiDiLam(chuoiDiLam))
                            {
                                txtTuoiDiLam.Text = "";
                                return;
                            }
                            else
                            {
                                if (!KiemTraDinhDangTuoiNghiHuu(chuoiNghiHuu))
                                {
                                    txtTuoiNghiHuu.Text = "";
                                    return;
                                }
                                else
                                {
                                    int tuoiDiLam = int.Parse(txtTuoiDiLam.Text);
                                    int tuoiNghiHuu = int.Parse(txtTuoiNghiHuu.Text);

                                    // Kiểm tra tuổi đi làm
                                    if (!KiemTraTuoiDiLam(tuoiDiLam, tuoiNghiHuu))
                                    {
                                        txtTuoiDiLam.Text = "";
                                        return;
                                    }
                                    else
                                    {
                                        Update.DoTuoiDiLam = byte.Parse(txtTuoiDiLam.Text);
                                    }
                                }
                            }

                            // Tuổi nghỉ hưu
                            if (!KiemTraDinhDangTuoiNghiHuu(chuoiNghiHuu))
                            {
                                txtTuoiNghiHuu.Text = "";
                                return;
                            }
                            else
                            {
                                if (!KiemTraDinhDangTuoiDiLam(chuoiDiLam))
                                {
                                    txtTuoiDiLam.Text = "";
                                    return;
                                }
                                else
                                {
                                    int tuoiDiLam = int.Parse(txtTuoiDiLam.Text);
                                    int tuoiNghiHuu = int.Parse(txtTuoiNghiHuu.Text);
                                    // Kiểm tra tuổi nghỉ hưu
                                    if (!KiemTraTuoiNghiHuu(tuoiDiLam, tuoiNghiHuu))
                                    {
                                        txtTuoiNghiHuu.Text = "";
                                        return;
                                    }
                                    else
                                    {
                                        Update.DoTuoiNghiHuu = byte.Parse(txtTuoiNghiHuu.Text);
                                    }
                                }
                            }


                            // Kiểm tra giới tính
                            string gioiTinh = txtLoaiGioiTinh.Text;
                            if (gioiTinh.Length > 4)
                            {
                                MessageBox.Show("Giới tính không vượt quá 4 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoaiGioiTinh.Text = "";
                                return;
                            }
                            else if (!KiemTraGioiTinhHopLe(gioiTinh))
                            {
                                MessageBox.Show("Giới tính không chứa số hoặc ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoaiGioiTinh.Text = "";
                                return;
                            }
                            else
                            {
                                Update.LoaiGioiTinh = txtLoaiGioiTinh.Text;
                            }

                            db.Entry(Update).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();
                            LoadDuLieuGioiTinh();
                            Chon();
                            grbChiTiet.Enabled = false;
                            MessageBox.Show("Sửa thành công");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy MaGioiTinh trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("MaGioiTinh không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                setButton(true);
                dgvGioiTinh.Enabled = true;
                txtMaGioiTinh.ReadOnly = false;
                txtMaGioiTinh.Enabled = true;
            }
                   
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {

            setButton(true);
            Chon();
            dgvGioiTinh.Enabled = true;
            grbChiTiet.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa giới tính này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                byte pq = byte.Parse(txtMaGioiTinh.Text);
                var Delete = db.GioiTinh.FirstOrDefault(nv => nv.MaGioiTinh == pq);
                if (Delete != null)
                {
                    db.GioiTinh.Remove(Delete);
                    db.SaveChanges();
                    LoadDuLieuGioiTinh();
                    dgvGioiTinh.Enabled = true;
                    txtMaGioiTinh.Enabled = true;
                    txtMaGioiTinh.ReadOnly = false;
                    grbChiTiet.Enabled = false;
                    Chon();


                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giới tính có mã " + pq);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGioiTinh_FormClosing(object sender, FormClosingEventArgs e)
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
