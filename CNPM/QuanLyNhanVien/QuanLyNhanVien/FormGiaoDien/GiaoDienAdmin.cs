using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class GiaoDienAdmin : Form
    {
        //Kiểm tra xem form đã tồn tại hay chưa
        private Form KiemTraFormCon(Form frmKiemTra)
        {
            foreach (var form in this.MdiChildren)
            {
                if (form.Name == frmKiemTra.Name)
                {
                    return form;
                }
            }
            return null;
        }
        public GiaoDienAdmin()
        {
            InitializeComponent();
        }

        private void GiaoDienAdmin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuNguoiDung_Click(object sender, EventArgs e)
        {
            var KiemTra = KiemTraFormCon(new Admin());

            if (KiemTra == null)
            {
                Admin fAdmin = new Admin();
                fAdmin.MdiParent = this;
                fAdmin.Show();
            }
            else
            {
                KiemTra.Activate();
            }
        }

        private void menuPhanQuyen_Click(object sender, EventArgs e)
        {
            var KiemTra = KiemTraFormCon(new FormPhanQuyen());

            if (KiemTra == null)
            {
                FormPhanQuyen fPhanQuyen = new FormPhanQuyen();
                fPhanQuyen.MdiParent = this;
                fPhanQuyen.Show();
            }
            else
            {
                KiemTra.Activate();
            }
        }

        private void menuChucVu_Click(object sender, EventArgs e)
        {
            var KiemTra = KiemTraFormCon(new FormChucVu());

            if (KiemTra == null)
            {
                FormChucVu fChucVu = new FormChucVu();
                fChucVu.MdiParent = this;
                fChucVu.Show();
            }
            else
            {
                KiemTra.Activate();
            }
        }

        private void menuKhuVuc_Click(object sender, EventArgs e)
        {
            var KiemTra = KiemTraFormCon(new FormKhuVuc());

            if (KiemTra == null)
            {
                FormKhuVuc fKhuVuc = new FormKhuVuc();
                fKhuVuc.MdiParent = this;
                fKhuVuc.Show();
            }
            else
            {
                KiemTra.Activate();
            }
        }

        private void menuGioiTinh_Click(object sender, EventArgs e)
        {
            var KiemTra = KiemTraFormCon(new FormGioiTinh());

            if (KiemTra == null)
            {
                FormGioiTinh fGioiTinh = new FormGioiTinh();
                fGioiTinh.MdiParent = this;
                fGioiTinh.Show();
            }
            else
            {
                KiemTra.Activate();
            }
        }

        private void menuHD_Click(object sender, EventArgs e)
        {
            var KiemTra = KiemTraFormCon(new FormHuongDan());

            if (KiemTra == null)
            {
                FormHuongDan fHuongDan = new FormHuongDan();
                fHuongDan.MdiParent = this;
                fHuongDan.Show();
            }
            else
            {
                KiemTra.Activate();
            }
        }

        private void menuThongTinThem_Click(object sender, EventArgs e)
        {
            var KiemTra = KiemTraFormCon(new FormThongTinThem());

            if (KiemTra == null)
            {
                FormThongTinThem fThongTinThem = new FormThongTinThem();
                fThongTinThem.MdiParent = this;
                fThongTinThem.Show();
            }
            else
            {
                KiemTra.Activate();
            }
        }

        private void GiaoDienAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Hỏi người dùng xem có chắc chắn muốn thoát không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn Đăng Xuất khỏi Admin?", "Xác nhận Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "No", hủy việc đóng form
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
