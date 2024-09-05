using QuanLyNhanVien.Data;
using QuanLyNhanVien.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyNhanVien
{
    public partial class Admin : Form
    {
        private DBContectQLNV db = new DBContectQLNV();
        private bool isLocButtonClicked = false;

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadDuLieuNguoiDung();
            grBChiTiet.Enabled = false;
            cbbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbKhuVuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbGioiTinhLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbChucVuLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbKhuVucLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbQuyenLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            // Sự kiện chọn item chức vụ
            cbbChucVu.SelectedIndexChanged += cbbChucVu_SelectedIndexChanged;
            txtDoTuoiDiLam.Enabled = false;
            txtDoTuoiNghiHuu.Enabled = false;
            setButton(true);
        }

        private void LoadCombobox()
        {
            var DSKhuVuc = db.KhuVuc.ToList();
            var DSChucVu = db.ChucVu.ToList();
            var DSPhanQuyen = db.PhanQuyen.ToList();
            var DSGioiTinh = db.GioiTinh.ToList();

            // Thêm phần tử "Tất cả" vào mỗi ComboBox
            DSKhuVuc.Insert(0, new KhuVuc { MaKhuVuc = 0, TenKhuVuc = "Tất cả" });
            DSChucVu.Insert(0, new ChucVu { MaChucVu = 0, TenChucVu = "Tất cả" });
            DSPhanQuyen.Insert(0, new PhanQuyen { MaPhanQuyen = 0, Quyen = "Tất cả" });
            DSGioiTinh.Insert(0, new GioiTinh { MaGioiTinh = 0, LoaiGioiTinh = "Tất cả" });

            cbbKhuVuc.DataSource = DSKhuVuc;
            cbbKhuVuc.DisplayMember = "TenKhuVuc";
            cbbKhuVuc.ValueMember = "MaKhuVuc";

            cbbChucVu.DataSource = DSChucVu;
            cbbChucVu.DisplayMember = "TenChucVu";
            cbbChucVu.ValueMember = "MaChucVu";

            cbbQuyen.DataSource = DSPhanQuyen;
            cbbQuyen.DisplayMember = "Quyen";
            cbbQuyen.ValueMember = "MaPhanQuyen";

            cbbGioiTinh.DataSource = DSGioiTinh;
            cbbGioiTinh.DisplayMember = "LoaiGioiTinh";
            cbbGioiTinh.ValueMember = "MaGioiTinh";

            cbbKhuVucLoc.DataSource = DSKhuVuc;
            cbbKhuVucLoc.DisplayMember = "TenKhuVuc";
            cbbKhuVucLoc.ValueMember = "MaKhuVuc";

            cbbChucVuLoc.DataSource = DSChucVu;
            cbbChucVuLoc.DisplayMember = "TenChucVu";
            cbbChucVuLoc.ValueMember = "MaChucVu";

            cbbQuyenLoc.DataSource = DSPhanQuyen;
            cbbQuyenLoc.DisplayMember = "Quyen";
            cbbQuyenLoc.ValueMember = "MaPhanQuyen";

            cbbGioiTinhLoc.DataSource = DSGioiTinh;
            cbbGioiTinhLoc.DisplayMember = "LoaiGioiTinh";
            cbbGioiTinhLoc.ValueMember = "MaGioiTinh";
        }

        private void LoadNguoiDungDangChon()
        {
            // Cần biết người dùng chọn dòng dữ liệu nào?
            // Lấy ra stt dòng người dùng chọn 
            int DongChon = dgvDanhSachNguoiDung.CurrentCell.RowIndex;
            //Lấy dữ liệu người dùng chọn trên datagridview
            var TaiKhoan = dgvDanhSachNguoiDung.Rows[DongChon].Cells[0].Value;
            var TenNguoiDung = dgvDanhSachNguoiDung.Rows[DongChon].Cells[1].Value;
            var MatKhau = dgvDanhSachNguoiDung.Rows[DongChon].Cells[2].Value;
            var Tuoi = dgvDanhSachNguoiDung.Rows[DongChon].Cells[3].Value;
            var SoDienThoai = dgvDanhSachNguoiDung.Rows[DongChon].Cells[4].Value;
            var DiaChi = dgvDanhSachNguoiDung.Rows[DongChon].Cells[5].Value;
            var Quyen = dgvDanhSachNguoiDung.Rows[DongChon].Cells[6].Value;
            var TenChucVu = dgvDanhSachNguoiDung.Rows[DongChon].Cells[7].Value;
            var TenKhuVuc = dgvDanhSachNguoiDung.Rows[DongChon].Cells[8].Value;
            var LoaiGioiTinh = dgvDanhSachNguoiDung.Rows[DongChon].Cells[9].Value;
            var LuongCoBan = dgvDanhSachNguoiDung.Rows[DongChon].Cells[10].Value;
            txtTaiKhoan.Text = TaiKhoan.ToString();
            txtTenNguoiDung.Text = TenNguoiDung.ToString();
            txtMatKhau.Text = MatKhau.ToString();
            txtTuoi.Text = Tuoi.ToString();
            txtSoDienThoai.Text = SoDienThoai.ToString();
            txtDiaChi.Text = DiaChi.ToString();
            cbbQuyen.Text = Quyen.ToString();
            cbbChucVu.Text = TenChucVu.ToString();
            cbbKhuVuc.Text = TenKhuVuc.ToString();
            cbbGioiTinh.Text = LoaiGioiTinh.ToString();
            txtLuongCoBan.Text = LuongCoBan.ToString();
        }

        private void XoaTextBox()
        {
            txtTaiKhoan.Text = "";
            txtTenNguoiDung.Text = "";
            txtMatKhau.Text = "";
            txtTuoi.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            cbbQuyen.SelectedIndex = 0;
            cbbChucVu.SelectedIndex = 0;
            cbbKhuVuc.SelectedIndex = 0;
            cbbGioiTinh.SelectedIndex = 1;
            txtLuongCoBan.Text = "";
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
        private void LoadDuLieuNguoiDung()
        {
            List<NguoiDung> DuLieuNguoiDung = db.NguoiDung.ToList();

            if (!isLocButtonClicked)
            {
                // Hiển thị toàn bộ dữ liệu người dùng
                List<NguoiDungViewModel> DuLieuNguoiDungViewModel = GetNguoiDungViewModels(DuLieuNguoiDung);


                // Sắp xếp danh sách giảm dần
                DuLieuNguoiDungViewModel = DuLieuNguoiDungViewModel.OrderByDescending(nd => nd.TaiKhoan).ToList();

                dgvDanhSachNguoiDung.DataSource = DuLieuNguoiDungViewModel;
                return;
            }

            string TenNguoiDungLoc = txtTenNguoiDungLoc.Text;
            KhuVuc KhuVucLoc = cbbKhuVucLoc.SelectedItem as KhuVuc;
            ChucVu ChucVuLoc = cbbChucVuLoc.SelectedItem as ChucVu;
            PhanQuyen PhanQuyenLoc = cbbQuyenLoc.SelectedItem as PhanQuyen;
            GioiTinh GioiTinhLoc = cbbGioiTinhLoc.SelectedItem as GioiTinh;

            // Lọc dữ liệu người dùng dựa trên các điều kiện
            DuLieuNguoiDung = DuLieuNguoiDung.Where(s => s.TenNguoiDung.Contains(TenNguoiDungLoc)).ToList();
            if (KhuVucLoc.MaKhuVuc != 0)
            {
                DuLieuNguoiDung = DuLieuNguoiDung.Where(s => s.MaKhuVuc == KhuVucLoc.MaKhuVuc).ToList();
            }
            if (ChucVuLoc.MaChucVu != 0)
            {
                DuLieuNguoiDung = DuLieuNguoiDung.Where(s => s.MaChucVu == ChucVuLoc.MaChucVu).ToList();
            }
            if (PhanQuyenLoc.MaPhanQuyen != 0)
            {
                DuLieuNguoiDung = DuLieuNguoiDung.Where(s => s.MaPhanQuyen == PhanQuyenLoc.MaPhanQuyen).ToList();
            }
            if (GioiTinhLoc.MaGioiTinh != 0)
            {
                DuLieuNguoiDung = DuLieuNguoiDung.Where(s => s.MaGioiTinh == GioiTinhLoc.MaGioiTinh).ToList();
            }

            List<NguoiDungViewModel> DuLieuNguoiDungViewModelLoc = GetNguoiDungViewModels(DuLieuNguoiDung);


            // Sắp xếp danh sách giảm dần
            DuLieuNguoiDungViewModelLoc = DuLieuNguoiDungViewModelLoc.OrderByDescending(nd => nd.TaiKhoan).ToList();
            dgvDanhSachNguoiDung.DataSource = DuLieuNguoiDungViewModelLoc;
        }

        private List<NguoiDungViewModel> GetNguoiDungViewModels(List<NguoiDung> DuLieuNguoiDung)
        {
            return DuLieuNguoiDung.Select(s => new NguoiDungViewModel
            {
                TaiKhoan = s.TaiKhoan,
                TenNguoiDung = s.TenNguoiDung,
                MatKhau = s.MatKhau,
                Tuoi = s.Tuoi,
                SoDienThoai = s.SoDienThoai,
                DiaChi = s.DiaChi,
                MaPhanQuyen = s.MaPhanQuyen,
                Quyen = s.PhanQuyen.Quyen,
                MaChucVu = s.MaChucVu,
                TenChucVu = s.ChucVu.TenChucVu,
                MaKhuVuc = s.MaKhuVuc,
                TenKhuVuc = s.KhuVuc.TenKhuVuc,
                MaGioiTinh = s.MaGioiTinh,
                GioiTinh = s.GioiTinh.LoaiGioiTinh,
                LuongCoBan = s.ChucVu.LuongCoBan,
            }).ToList();
        }
        private void NhapNguoiDungTuExcel(string path)
        {
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];

                int startRow = excelWorksheet.Dimension.Start.Row + 1; // Bỏ qua dòng header
                int endRow = excelWorksheet.Dimension.End.Row;
                int startCol = excelWorksheet.Dimension.Start.Column;
                int endCol = excelWorksheet.Dimension.End.Column;

                for (int row = startRow; row <= endRow; row++)
                {
                    Data.NguoiDung nguoiDungThem = new Data.NguoiDung(); // Khởi tạo đối tượng mới cho mỗi dòng trong Excel

                    for (int col = startCol; col <= endCol; col++)
                    {
                        string columnName = excelWorksheet.Cells[1, col].Value.ToString(); // Lấy tên cột từ dòng header
                        object cellValue = excelWorksheet.Cells[row, col].Value;

                        // Gán giá trị từ file Excel vào đối tượng nguoiDungThem dựa trên tên cột
                        switch (columnName)
                        {
                            case "TaiKhoan":
                                nguoiDungThem.TaiKhoan = cellValue.ToString();
                                break;
                            case "TenNguoiDung":
                                nguoiDungThem.TenNguoiDung = cellValue.ToString();
                                break;
                            case "MatKhau":
                                nguoiDungThem.MatKhau = cellValue.ToString();
                                break;
                            case "Tuoi":
                                nguoiDungThem.Tuoi = Convert.ToInt32(cellValue);
                                break;
                            case "SoDienThoai":
                                nguoiDungThem.SoDienThoai = cellValue.ToString();
                                break;
                            case "DiaChi":
                                nguoiDungThem.DiaChi = cellValue.ToString();
                                break;
                            case "Quyen":
                                PhanQuyen phanQuyen = cbbQuyen.SelectedItem as PhanQuyen;
                                nguoiDungThem.MaPhanQuyen = phanQuyen.MaPhanQuyen;
                                break;
                            case "ChucVu":
                                ChucVu chucVu = cbbChucVu.SelectedItem as ChucVu;
                                nguoiDungThem.MaChucVu = chucVu.MaChucVu;
                                break;
                            case "Khu":
                                KhuVuc khuVuc = cbbKhuVuc.SelectedItem as KhuVuc;
                                nguoiDungThem.MaKhuVuc = khuVuc.MaKhuVuc;
                                break;
                            case "GioiTinh":
                                GioiTinh gioiTinh = cbbGioiTinh.SelectedItem as GioiTinh;
                                nguoiDungThem.MaGioiTinh = gioiTinh.MaGioiTinh;
                                break;
                            case "LuongCoBan":
                                
                                break;
                            default:
                                break;
                        }
                    }

                    db.NguoiDung.Add(nguoiDungThem); // Thêm đối tượng vào DbSet để sau đó thêm vào cơ sở dữ liệu
                }

                try
                {
                    db.SaveChanges(); // Thực hiện lưu thay đổi vào cơ sở dữ liệu
                    LoadDuLieuNguoiDung(); // Reload dữ liệu lên DataGridView sau khi đã thêm thành công
                    MessageBox.Show("Thêm thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm dữ liệu từ file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void XuatFileExcel(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            for(int i = 0; i < dgvDanhSachNguoiDung.Columns.Count; i++)
            {
                application.Cells[1, i + 1] = dgvDanhSachNguoiDung.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgvDanhSachNguoiDung.Rows.Count; i++)
            {
                for (int j = 0; j < dgvDanhSachNguoiDung.Columns.Count; j++)
                {
                    application.Cells[i + 2, j + 1] = dgvDanhSachNguoiDung.Rows[i].Cells[j].Value;
                }
            }
            application.Columns.AutoFit();
            application.ActiveWorkbook.SaveCopyAs(path);
            application.ActiveWorkbook.Saved = true;
        }

        private void NhapFileExcel(string path)
        {
            using (ExcelPackage excelPackage = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[0];
                DataTable dataTable = new DataTable();  
                for(int i = excelWorksheet.Dimension.Start.Column;i <= excelWorksheet.Dimension.End.Column;i++)
                {
                    dataTable.Columns.Add(excelWorksheet.Cells[1, i].Value.ToString());
                }
                for (int i = excelWorksheet.Dimension.Start.Row+1; i <= excelWorksheet.Dimension.End.Row; i++)
                {
                    List<string> listRows = new List<string>();
                    for (int j = excelWorksheet.Dimension.Start.Column; j <= excelWorksheet.Dimension.End.Column; j++) 
                    {
                        listRows.Add(excelWorksheet.Cells[i, j].Value.ToString());
                    }
                    dataTable.Rows.Add(listRows.ToArray());
                }
                dgvDanhSachNguoiDung.DataSource = dataTable;
            } 
        }

        private string GetSHA256Hash(string matKhau)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Chuyển đổi mật khẩu thành mảng byte
                byte[] inputBytes = Encoding.UTF8.GetBytes(matKhau);

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
        private bool KiemTraTrungTaiKhoan(string taiKhoan)
        {
            // Thực hiện truy vấn để kiểm tra
            var nguoiDung = db.NguoiDung.FirstOrDefault(nd => nd.TaiKhoan == taiKhoan);
            return nguoiDung != null;
        }

        private bool KiemTraDinhDangTuoi(string tuoi)
        {
            int result;
            return int.TryParse(tuoi, out result);
        }

        private bool KiemTraDinhDangSoDienThoai(string soDienThoai)
        {
            // Kiểm tra độ dài của số điện thoại
            if (soDienThoai.Length != 10)
            {
                return false;
            }

            // Kiểm tra xem số điện thoại chỉ chứa số
            foreach (char c in soDienThoai)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        private bool KiemTraTenNguoiDungHopLe(string tenNguoiDung)
        {
            // Biểu thức chính quy để kiểm tra chuỗi không chứa số hay ký tự đặc biệt
            string pattern = @"^[\p{L}\s]+$";  // Chỉ chấp nhận chữ cái tiếng Việt và khoảng trắng
            // Kiểm tra sự khớp của chuỗi với biểu thức chính quy
            bool isMatch = Regex.IsMatch(tenNguoiDung, pattern);

            return isMatch;
        }


        private void btnLoc_Click(object sender, EventArgs e)
        {
            isLocButtonClicked = true;
            LoadDuLieuNguoiDung();
        }

        private void dgvNguoiDungChon(object sender, EventArgs e)
        {

            LoadNguoiDungDangChon();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grBChiTiet.Enabled = false;
            dgvDanhSachNguoiDung.Enabled = true;
            XoaTextBox();
            LoadNguoiDungDangChon();
            setButton(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            grBChiTiet.Enabled = true;
            dgvDanhSachNguoiDung.Enabled = false;
            txtTaiKhoan.ReadOnly = true;
            setButton(false);
            txtMatKhau.Enabled = false;
            btnDoiMK.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            grBChiTiet.Enabled = true;
            XoaTextBox();
            dgvDanhSachNguoiDung.Enabled = false;
            txtTaiKhoan.ReadOnly = false;
            setButton(false);
            txtMatKhau.Enabled = true;
            btnDoiMK.Enabled = false;
        }

        private void cbbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Chọn giới tính sẽ set độ tuổi đi làm
            string gioiTinh = cbbGioiTinh.Text;

            if (gioiTinh == "Nam")
            {
                var gioiTinhNam = db.GioiTinh.FirstOrDefault(d => d.LoaiGioiTinh == "Nam");
                if (gioiTinhNam != null)
                {
                    txtDoTuoiDiLam.Text = gioiTinhNam.DoTuoiDiLam.ToString();
                    txtDoTuoiNghiHuu.Text = gioiTinhNam.DoTuoiNghiHuu.ToString();
                }
            }
            else if (gioiTinh == "Nữ")
            {
                var gioiTinhNu = db.GioiTinh.FirstOrDefault(d => d.LoaiGioiTinh == "Nữ");
                if (gioiTinhNu != null)
                {
                    txtDoTuoiDiLam.Text = gioiTinhNu.DoTuoiDiLam.ToString();
                    txtDoTuoiNghiHuu.Text = gioiTinhNu.DoTuoiNghiHuu.ToString();
                }
            }
            else if (gioiTinh == "Tất cả")
            {
                txtDoTuoiDiLam.Text = "";
                txtDoTuoiNghiHuu.Text = "";
            }
        }
        private void Sua()
        {
            Data.NguoiDung nguoiDungCanSua = db.NguoiDung.Where(s => s.TaiKhoan == txtTaiKhoan.Text).FirstOrDefault();

            // Kiểm tra dữ liệu nhập có rỗng hay không
            if (string.IsNullOrEmpty(txtTaiKhoan.Text) ||
                string.IsNullOrEmpty(txtTenNguoiDung.Text) ||
                string.IsNullOrEmpty(txtMatKhau.Text) ||
                string.IsNullOrEmpty(txtTuoi.Text) ||
                string.IsNullOrEmpty(txtSoDienThoai.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(cbbQuyen.Text) ||
                string.IsNullOrEmpty(cbbChucVu.Text) ||
                string.IsNullOrEmpty(cbbKhuVuc.Text) ||
                string.IsNullOrEmpty(cbbGioiTinh.Text))
            {
                MessageBox.Show("Dữ liệu trống hoặc không đúng định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra tên người dùng không chứa số hay ký tự đặc biệt
                // Kiểm tra tên người dùng không vượt quá 35 ký tự
                string tenNguoiDung = txtTenNguoiDung.Text;
                bool hopLe = KiemTraTenNguoiDungHopLe(tenNguoiDung);
                if (tenNguoiDung.Length > 35)
                {
                    MessageBox.Show("Tên người dùng không được vượt quá 35 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNguoiDung.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else if (!hopLe)
                {
                    // Chuỗi không hợp lệ, thông báo lỗi
                    MessageBox.Show("Tên người dùng không được chứa số hay ký tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNguoiDung.Text = "";
                    return;
                }
                else
                {
                    nguoiDungCanSua.TenNguoiDung = txtTenNguoiDung.Text;
                }

                // Kiểm tra mật khẩu không vượt quá 64 ký tự
                string matKhau = txtMatKhau.Text;
                if (matKhau.Length > 64)
                {
                    MessageBox.Show("Mật khẩu không được vượt quá 64 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else
                {
                    if(txtMatKhau.Enabled == true)
                    {
                        string hashedPassword = GetSHA256Hash(matKhau);
                        nguoiDungCanSua.MatKhau = hashedPassword;
                    }
                    else
                    {
                        nguoiDungCanSua.MatKhau = txtMatKhau.Text;
                    }
                }

                // Kiểm tra định dạng số điện thoại
                string soDienThoai = txtSoDienThoai.Text;
                if (!KiemTraDinhDangSoDienThoai(soDienThoai))
                {
                    MessageBox.Show("Số điện thoại không đúng định dạng. Vui lòng nhập 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoDienThoai.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else
                {
                    nguoiDungCanSua.SoDienThoai = txtSoDienThoai.Text;
                }

                // Kiểm tra địa chỉ không vượt quá 150 ký tự
                string diaChi = txtDiaChi.Text;
                if (diaChi.Length > 150)
                {
                    MessageBox.Show("Địa chỉ không được vượt quá 150 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiaChi.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else
                {
                    nguoiDungCanSua.DiaChi = txtDiaChi.Text;
                }

                // Check tuổi có nằm trong tuổi đi làm đối với Nam
                bool hasError = false;
                string KTGioiTinh = cbbGioiTinh.Text;
                if (KTGioiTinh == "Nam")
                {
                    var workingAge = db.GioiTinh.FirstOrDefault(d => d.MaGioiTinh == 1);
                    if (workingAge != null)
                    {
                        int DiLam = workingAge.DoTuoiDiLam ?? 0;
                        int NghiHuu = workingAge.DoTuoiNghiHuu ?? 0;

                        int Nhap = 0;
                        if (int.TryParse(txtTuoi.Text, out Nhap))
                        {
                            if (Nhap < DiLam)
                            {
                                MessageBox.Show("Chưa đủ tuổi đi làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hasError = true;
                            }
                            else if (Nhap > NghiHuu)
                            {
                                MessageBox.Show("Quá tuổi đi làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hasError = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập tuổi là một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                        }
                    }
                }
                // Check tuổi có nằm trong tuổi đi làm đối với Nữ
                else if (KTGioiTinh == "Nữ")
                {
                    var workingAge = db.GioiTinh.FirstOrDefault(d => d.MaGioiTinh == 2);
                    if (workingAge != null)
                    {
                        int DiLam = workingAge.DoTuoiDiLam ?? 0;
                        int NghiHuu = workingAge.DoTuoiNghiHuu ?? 0;

                        int Nhap = 0;
                        if (int.TryParse(txtTuoi.Text, out Nhap))
                        {
                            if (Nhap < DiLam)
                            {
                                MessageBox.Show("Chưa đủ tuổi đi làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hasError = true;
                            }
                            else if (Nhap > NghiHuu)
                            {
                                MessageBox.Show("Vui lòng nhập tuổi là một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hasError = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập tuổi là một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                        }
                    }
                }

                // Kiểm tra người dùng có đang chọn Tất cả
                PhanQuyen phanQuyen = cbbQuyen.SelectedItem as PhanQuyen;
                if (phanQuyen != null && phanQuyen.Quyen == "Tất cả")
                {
                    MessageBox.Show("Không thể chọn phân quyền 'Tất cả'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbQuyen.Text = "";
                    return;
                }
                else
                {
                    nguoiDungCanSua.MaPhanQuyen = phanQuyen.MaPhanQuyen;
                }

                // Kiểm tra người dùng có đang chọn Tất cả
                ChucVu chucVu = cbbChucVu.SelectedItem as ChucVu;
                if (chucVu != null && chucVu.TenChucVu == "Tất cả")
                {
                    MessageBox.Show("Không thể chọn chức vụ 'Tất cả'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbChucVu.Text = "";
                    return;
                }
                else
                {
                    nguoiDungCanSua.MaChucVu = chucVu.MaChucVu;
                }

                // Kiểm tra người dùng có đang chọn Tất cả
                KhuVuc khuVuc = cbbKhuVuc.SelectedItem as KhuVuc;
                if (khuVuc != null && khuVuc.TenKhuVuc == "Tất cả")
                {
                    MessageBox.Show("Không thể chọn khu vực 'Tất cả'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbKhuVuc.Text = "";
                    return;
                }
                else
                {
                    nguoiDungCanSua.MaKhuVuc = khuVuc.MaKhuVuc;
                }

                // Kiểm tra người dùng có đang chọn Tất cả
                GioiTinh gioiTinh = cbbGioiTinh.SelectedItem as GioiTinh;
                if (gioiTinh != null && gioiTinh.LoaiGioiTinh == "Tất cả")
                {
                    MessageBox.Show("Không thể chọn giới tính 'Tất cả'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbGioiTinh.Text = "";
                    return;
                }
                else
                {
                    nguoiDungCanSua.MaGioiTinh = gioiTinh.MaGioiTinh;
                }

                // Kiểm tra cờ có phải là false không
                if (!hasError)
                {
                    string tuoi = txtTuoi.Text;
                    // Kiểm tra định dạng tuổi
                    if (!KiemTraDinhDangTuoi(tuoi))
                    {
                        MessageBox.Show("Tuổi không đúng định dạng. Vui lòng nhập một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTuoi.Text = "";
                        return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                    }
                    else
                    {
                        nguoiDungCanSua.Tuoi = int.Parse(txtTuoi.Text);
                    }

                    // Báo cho DB biết là vừa sửa dữ liệu
                    db.Entry(nguoiDungCanSua).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    LoadDuLieuNguoiDung();
                    LoadNguoiDungDangChon();
                    MessageBox.Show("Sửa thành công");
                    setButton(true);
                    grBChiTiet.Enabled = false;
                    dgvDanhSachNguoiDung.Enabled = true;
                }
                else
                {
                    txtTuoi.Text = "";
                    return;
                }
            }
        }

        private void Them()
        {
            // Hàm thêm ở đây
            Data.NguoiDung nguoiDungThem = new Data.NguoiDung();


            // Kiểm tra dữ liệu nhập có rỗng hay không
            if (string.IsNullOrEmpty(txtTaiKhoan.Text) ||
                string.IsNullOrEmpty(txtTenNguoiDung.Text) ||
                string.IsNullOrEmpty(txtMatKhau.Text) ||
                string.IsNullOrEmpty(txtTuoi.Text) ||
                string.IsNullOrEmpty(txtSoDienThoai.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text) ||
                string.IsNullOrEmpty(cbbQuyen.Text) ||
                string.IsNullOrEmpty(cbbChucVu.Text) ||
                string.IsNullOrEmpty(cbbKhuVuc.Text) ||
                string.IsNullOrEmpty(cbbGioiTinh.Text))
            {
                MessageBox.Show("Dữ liệu trống hoặc không đúng định dạng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Kiểm tra tên người dùng không chứa số hay ký tự đặc biệt
                // Kiểm tra tên người dùng không vượt quá 35 ký tự
                string tenNguoiDung = txtTenNguoiDung.Text;
                bool hopLe = KiemTraTenNguoiDungHopLe(tenNguoiDung);
                if (tenNguoiDung.Length > 35)
                {
                    MessageBox.Show("Tên người dùng không được vượt quá 35 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNguoiDung.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else if (!hopLe)
                {
                    // Chuỗi không hợp lệ, thông báo lỗi
                    MessageBox.Show("Tên người dùng không được chứa số hay ký tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNguoiDung.Text = "";
                    return;
                }
                else
                {
                    nguoiDungThem.TenNguoiDung = txtTenNguoiDung.Text;
                }

                // Kiểm tra nếu txtTaiKhoan trùng với TaiKhoan trong CSDL
                // Kiểm tra tài khoản không vượt quá 16 ký tự
                string taiKhoan = txtTaiKhoan.Text;
                if (taiKhoan.Length > 16)
                {
                    MessageBox.Show("Tài khoản không được vượt quá 16 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else if (KiemTraTrungTaiKhoan(taiKhoan))
                {
                    MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTaiKhoan.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else
                {
                    nguoiDungThem.TaiKhoan = taiKhoan;
                }

                // Kiểm tra mật khẩu không vượt quá 64 ký tự
                string matKhau = txtMatKhau.Text;
                if (matKhau.Length > 64)
                {
                    MessageBox.Show("Mật khẩu không được vượt quá 64 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else
                {
                    string hashedPassword = GetSHA256Hash(matKhau);
                    nguoiDungThem.MatKhau = hashedPassword;

                }

                // Kiểm tra định dạng số điện thoại
                string soDienThoai = txtSoDienThoai.Text;
                if (!KiemTraDinhDangSoDienThoai(soDienThoai))
                {
                    MessageBox.Show("Số điện thoại không đúng định dạng. Vui lòng nhập 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoDienThoai.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else
                {
                    nguoiDungThem.SoDienThoai = txtSoDienThoai.Text;
                }

                // Kiểm tra địa chỉ không vượt quá 150 ký tự
                string diaChi = txtDiaChi.Text;
                if (diaChi.Length > 150)
                {
                    MessageBox.Show("Địa chỉ không được vượt quá 150 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiaChi.Text = "";
                    return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                }
                else
                {
                    nguoiDungThem.DiaChi = txtDiaChi.Text;
                }

                // Kiểm tra người dùng có đang chọn Tất cả
                PhanQuyen phanQuyen = cbbQuyen.SelectedItem as PhanQuyen;
                if (phanQuyen != null && phanQuyen.Quyen == "Tất cả")
                {
                    MessageBox.Show("Không thể chọn phân quyền 'Tất cả'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbQuyen.Text = "";
                    return;
                }
                else
                {
                    nguoiDungThem.MaPhanQuyen = phanQuyen.MaPhanQuyen;
                }

                // Kiểm tra người dùng có đang chọn Tất cả
                ChucVu chucVu = cbbChucVu.SelectedItem as ChucVu;
                if (chucVu != null && chucVu.TenChucVu == "Tất cả")
                {
                    MessageBox.Show("Không thể chọn chức vụ 'Tất cả'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbChucVu.Text = "";
                    return;
                }
                else
                {
                    nguoiDungThem.MaChucVu = chucVu.MaChucVu;
                }

                // Kiểm tra người dùng có đang chọn Tất cả
                KhuVuc khuVuc = cbbKhuVuc.SelectedItem as KhuVuc;
                if (khuVuc != null && khuVuc.TenKhuVuc == "Tất cả")
                {
                    MessageBox.Show("Không thể chọn khu vực 'Tất cả'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbKhuVuc.Text = "";
                    return;
                }
                else
                {
                    nguoiDungThem.MaKhuVuc = khuVuc.MaKhuVuc;
                }

                // Kiểm tra người dùng có đang chọn Tất cả
                GioiTinh gioiTinh = cbbGioiTinh.SelectedItem as GioiTinh;
                if (gioiTinh != null && gioiTinh.LoaiGioiTinh == "Tất cả")
                {
                    MessageBox.Show("Không thể chọn giời tính 'Tất cả'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    cbbGioiTinh.Text = "";
                    return;
                }
                else
                {
                    nguoiDungThem.MaGioiTinh = gioiTinh.MaGioiTinh;
                }

                // Check tuổi có nằm trong tuổi đi làm đối với Nam
                bool hasError = false;
                string KTGioiTinh = cbbGioiTinh.Text;
                if (KTGioiTinh == "Nam")
                {
                    var workingAge = db.GioiTinh.FirstOrDefault(d => d.MaGioiTinh == 1);
                    if (workingAge != null)
                    {
                        int DiLam = workingAge.DoTuoiDiLam ?? 0;
                        int NghiHuu = workingAge.DoTuoiNghiHuu ?? 0;

                        int Nhap = 0;
                        if (int.TryParse(txtTuoi.Text, out Nhap))
                        {
                            if (Nhap < DiLam)
                            {
                                MessageBox.Show("Chưa đủ tuổi đi làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hasError = true;
                            }
                            else if (Nhap > NghiHuu)
                            {
                                MessageBox.Show("Quá tuổi đi làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hasError = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập tuổi là một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                        }
                    }
                }
                // Check tuổi có nằm trong tuổi đi làm đối với Nữ
                else if (KTGioiTinh == "Nữ")
                {
                    var workingAge = db.GioiTinh.FirstOrDefault(d => d.MaGioiTinh == 2);
                    if (workingAge != null)
                    {
                        int DiLam = workingAge.DoTuoiDiLam ?? 0;
                        int NghiHuu = workingAge.DoTuoiNghiHuu ?? 0;

                        int Nhap = 0;
                        if (int.TryParse(txtTuoi.Text, out Nhap))
                        {
                            if (Nhap < DiLam)
                            {
                                MessageBox.Show("Chưa đủ tuổi đi làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hasError = true;
                            }
                            else if (Nhap > NghiHuu)
                            {
                                MessageBox.Show("Quá tuổi đi làm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hasError = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập tuổi là một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            hasError = true;
                        }
                    }
                }

                // Kiểm tra cờ có phải là false không
                if (!hasError)
                {
                    
                        string tuoi = txtTuoi.Text;
                        // Kiểm tra định dạng tuổi
                        if (!KiemTraDinhDangTuoi(tuoi))
                        {
                            MessageBox.Show("Tuổi không đúng định dạng. Vui lòng nhập một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTuoi.Text = "";
                            return; // Dừng lại để ngăn tiếp tục thực hiện lưu
                        }
                        else
                        {
                            nguoiDungThem.Tuoi = int.Parse(txtTuoi.Text);
                        }

                        db.NguoiDung.Add(nguoiDungThem);
                        db.SaveChanges();
                        LoadDuLieuNguoiDung();
                        LoadNguoiDungDangChon();
                        MessageBox.Show("Thêm thành công");
                        setButton(true);
                        grBChiTiet.Enabled = false;
                        dgvDanhSachNguoiDung.Enabled = true;  
                }
                else
                {
                    txtTuoi.Text = "";
                    return;
                }
            }  
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.ReadOnly == true)
            {
                Sua();
            }
            else
            {
                Them();
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            setButton(false);
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string tk = txtTaiKhoan.Text;
                var nguoiDungCanXoa = db.NguoiDung.FirstOrDefault(nv => nv.TaiKhoan == tk);
                if (nguoiDungCanXoa != null)
                {
                    db.NguoiDung.Remove(nguoiDungCanXoa);
                    db.SaveChanges();
                    LoadDuLieuNguoiDung();
                    XoaTextBox();
                    MessageBox.Show("Xóa thành công");
                    setButton(true);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng có " + tk);
                }
            }
        }

        private void txtTenNguoiDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLuongCoBan_TextChanged(object sender, EventArgs e)
        {
            txtLuongCoBan.ReadOnly = true;
        }

        private void cbbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra chức vụ đang chọn và lấy ra lương cơ bản tương ứng
            ChucVu selectedChucVu = cbbChucVu.SelectedItem as ChucVu;
            if (selectedChucVu != null)
            {
                txtLuongCoBan.Text = selectedChucVu.LuongCoBan.ToString();
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Hỏi người dùng xem có chắc chắn muốn thoát không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", hủy việc đóng form
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            cbbChucVuLoc.SelectedIndex = 0;
            cbbGioiTinhLoc.SelectedIndex = 0;
            cbbKhuVucLoc.SelectedIndex = 0;
            cbbQuyenLoc.SelectedIndex = 0;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            txtMatKhau.Enabled = true;
            txtMatKhau.Text = "";
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx|Excel 2016 (*.xls)|*.xls";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XuatFileExcel(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công !");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xuất file không thành công !");
                }
            }
        }

        private void btnNhapFileExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                NhapNguoiDungTuExcel(filePath); // Gọi hàm nhập dữ liệu từ file Excel với đường dẫn đã chọn
            }
            LoadDuLieuNguoiDung();
            LoadNguoiDungDangChon();
        }
    }

}

